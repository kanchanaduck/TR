import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import Swal from 'sweetalert2';
import axios from 'axios';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';
import { AppServiceService } from '../../app-service.service'

@Component({
  selector: 'app-stakeholder',
  templateUrl: './stakeholder.component.html',
  styleUrls: ['./stakeholder.component.scss']
})
export class StakeholderComponent implements OnInit {

  dtOptions: any = {};
  closeResult = '';
  stakeholders: any = [];
  stakeholder: any = {};
  
  departments: any;
  employees: any = [];
  errors: any;
  formData: any = [];

  dtTrigger: Subject<any> = new Subject();
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  isDtInitialized: boolean = false;
  headers: any = {
    headers: {
    Authorization: 'Bearer ' + localStorage.getItem('token_hrgis'),
      'Content-Type': 'application/json'
    }
  }

  constructor(
    private service: AppServiceService, 
    private httpClient: HttpClient
  ) { }

  ngOnInit(): void {
    this.dtOptions = {
      /* ajax: {
        url: environment.API_URL+"Stakeholder",
        dataSrc: "",
      },
      columns:
      [
        {
          data: "org_abb",
          className: "tx-bold",
          "render": function ( data, type, row ) {
            return row.parent_org.org_abb==null? `${data}`: `${row.parent_org.org_abb}`
          }
        },
        { 
          "data": "org_abb",
          className: "pl-5",
          "render": function ( data, type, row ) {
            return row.parent_org.org_abb==null? ``: `${data}`
          }
        },
        { 
          "data": "level_name",
          "render": function ( data, type, row ) {
            return data
          }
        },
        { 
          "data": "stakeholders",
          "render": function ( data, type, row ) {
            const st = data.find(function(el){
              return el.role === "Committee"
            } )
            if(st!== undefined){
              return `${st.employee.emp_no}: ${st.employee.fullname_eng} (${st.employee.dept_abb_name})`;
            }
            else{
              return '';
            }
          }  
        },
        { 
          "data": "stakeholders",
          "render": function ( data, type, row ) {
            const st = data.find(function(el){
              return el.role === "Approver"
            } )
            if(st!== undefined){
              return `${st.employee.emp_no}: ${st.employee.fullname_eng} (${st.employee.dept_abb_name})`;
            }
            else{
              return '';
            }
          }  
        },
        { 
          "data": "org_abb",
          className: 'text-center',
          "render": function ( data, type, row ) {
            // return data;
            return  '<a href="javascript:;"><i class="far fa-edit"></i></a>'
          },
        },
      ], */
      dom: "<'row'<'col-sm-12 col-md-4'f><'col-sm-12 col-md-8'B>>" +
      "<'row'<'col-sm-12'tr>>" +
      "<'row'<'col-sm-12 col-md-4'i><'col-sm-12 col-md-8'p>>",
      language: {
        paginate: {
          next: '<i class="icon ion-ios-arrow-forward"></i>', // or '→'
          previous: '<i class="icon ion-ios-arrow-back"></i>' // or '←' 
        }
      },
      buttons: {
        "dom":{
          "container": {
            tag: "div",
            className: "dt-buttons btn-group flex-wrap float-right"
          },
          "button": {
            tag: "button",
            className: "btn btn-outline-indigo btn-sm"
          },
        },
        "buttons": [
          {
            extend:'pageLength',
          },
          {
            extend: 'collection',
            text: '<i class="fas fa-cloud-download-alt"></i> Download</button>',
            buttons: [
              {
                  extend: 'excel',
                  text: '<i class="far fa-file-excel"></i> Excel</button>',
              },
            ]
          },
        ],
      },
      order: [ [0, 'asc'],[2, 'desc'], [1, 'asc']],
      columnDefs: [ 
        {
          targets: [ 4 ],
          orderable: false 
        },
      ],  
      container: "#example_wrapper .col-md-6:eq(0)",
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
    };
  
    this.get_stakeholders();
    this.get_departments();
    // this.get_employees();
  
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }


  async get_stakeholders(){
    let self = this
    await this.httpClient.get(`${environment.API_URL}Stakeholder`, this.headers)
    .subscribe((response: any) => {
      self.stakeholders = response;
      if (this.isDtInitialized) {
        this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
          dtInstance.destroy();
          this.dtTrigger.next();
        });
      } 
      else {
        this.isDtInitialized = true
        this.dtTrigger.next();
      }
    },
    (error: any) => {
      console.log(error);
    });
  }

  async get_employees() {
    try {
      const response = await axios.get(`${environment.API_URL}Employees`, this.headers);
      this.employees = response
      return response;
    } 
    catch (error) {
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: "Data not found"
      })
    }
  }

  async get_departments() {
    try {
      const response = await axios.get(`${environment.API_URL}Organization/Level/Department`, this.headers);
      this.departments = response
      return response;
    } 
    catch (error) {
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: "Data not found"
      })
    }
  }

  async get_stakeholder(org_code: string) {
    const self = this;
    // this.stakeholder = data
    try {
      const response = await axios.get(`${environment.API_URL}Stakeholder/${org_code}`, this.headers);
      this.stakeholder = response
      console.log(this.stakeholder)
      console.log(self.stakeholder.stakeholders)

      const committee = self.stakeholder.stakeholders.find(function(el){
        return el.role === "COMMITTEE"
      })

      const approver = self.stakeholder.stakeholders.find(function(el){
        return el.role === "APPROVER"
      })

      console.log(approver);
      console.log(committee)

      approver.forEach(element => {
        self.stakeholder.committees.push(element.emp_no)
      });

      committee.forEach(element => {
        self.stakeholder.approvers.push(element.emp_no)
      });


      // self.stakeholder.push(committee, approver) 
    } 
    catch (error) {
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: "Data not found"
      })
    }
    // console.log('data: ', this.stakeholder);
  }

  async save_stakeholders(){
    this.formData = [];

    this.stakeholder.committees.forEach(element => {
      let c = {
        emp_no: element,
        org_code: this.stakeholder.org_code,
        role: 'COMMITTEE'
      }
      this.formData.push(c)
    });

    this.stakeholder.approvers.forEach(element => {
      let a = {
        emp_no: element,
        org_code: this.stakeholder.org_code,
        role: 'APPROVER'
      }
      this.formData.push(a)
    });
    
    console.log(this.formData)


    await axios.post(`${environment.API_URL}Stakeholder`,this.formData, this.headers)
    .then(function (response) {
      Swal.fire({
        toast: true,
        position: 'top-end',
        icon: 'success',
        title: "Success",
        showConfirmButton: false,
        timer: 2000
      })
      alert("Reload")
    })
    .catch(function (error) {
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data
      })
    });
    // this.reset_form_stakeholders()
  }





}

