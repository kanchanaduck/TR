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
  committees: any = [];
  committee: any = {};
  approver: any = {};
  approvers: any = [];
  
  departments: any;
  employees: any = [];
  errors: any;
  formData: any = [];

  group_by_parent_org_code_fn: any;
  group_value_parent_org_code_fn: any;
  compare_org: any;

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

  async get_employees(org_code) {
    let self = this
    await axios.get(`${environment.API_URL}Employees/Organization/${org_code}`,this.headers)
    .then(function (response) {
      self.employees = response
    })
    .catch(function (error) {
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data
      })
    });
  }

  async get_departments() {
    let self = this
    await axios.get(`${environment.API_URL}Organization/Level/Department/Parent`, this.headers)
    .then(function (response) {
      self.departments = response
      //console.log(response)
      self.group_by_parent_org_code_fn = (item) => item.parent_org_code;
      self.group_value_parent_org_code_fn = (_: string, children: any[]) => ({ org_abb: children[0].parent_org.org_abb, org_code: children[0].parent_org.org_code });
      self.compare_org = (item, selected) => {
        if (selected.Grouby_parent_org_code_fn && item.Groupvalue_parent_org_code_fn) {
            return item.Grouby_parent_org_code_fn === selected.Grouby_parent_org_code_fn;
        }
        if (item.oeg_abb && selected.oeg_abb) {
            return item.oeg_abb === selected.oeg_abb;
        }
        return false;
      };
    })
    .catch(function (error) {
      //console.log(error)
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data
      })
    });
  }

  async get_stakeholder(org_code: string) {
    console.log(org_code)
    const self = this;
    self.get_employees(org_code)

    await axios.get(`${environment.API_URL}Stakeholder/${org_code}`, this.headers)
      .then(function (response) {
        self.stakeholder = response
      })
      .catch(function (error) {
        Swal.fire({
          icon: 'error',
          title: error.response.status,
          text: error.response.data
        })
    });

    //console.log(self.stakeholder)
    //console.log(self.stakeholder.stakeholders)
    //console.log(self.stakeholder.stakeholders.length)

    if(self.stakeholder.stakeholders.length>0){
      const committees = self.stakeholder.stakeholders.filter(function(el){
        //console.log(el)
        return el.role === "COMMITTEE"
      })
      //console.log(committees);
      //console.log(committees.length);

      const approvers = self.stakeholder.stakeholders.filter(function(el){
        //console.log(el)
        return el.role === "APPROVER"
      })
      //console.log(approvers);
      //console.log(approvers.length);

      if(approvers.length>0){
        //console.log(approvers);
        self.stakeholder.approvers = [];
        approvers.forEach(element => {
          self.stakeholder.approvers.push(element.emp_no)
        });
      }
      else{
        //console.log("Approvers = 0")
      }

      if(committees.length>0){
        //console.log(committees)
        self.stakeholder.committees = [];
        committees.forEach(element => {
          self.stakeholder.committees.push(element.emp_no)
        });
      }
      else{
        //console.log("Committees = 0")
      }        
    }

  }

  async reset_form_stakeholder(){
    this.stakeholder = {};
  }

  async save_stakeholders(){
    let self = this
    self.formData = [];
    //console.log("Committee: ", self.stakeholder.committees)
    //console.log("Approver: ", self.stakeholder.approvers)

    if(self.stakeholder.committees!==undefined){
      self.stakeholder.committees.forEach(element => {
        let c = {
          emp_no: element,
          org_code: self.stakeholder.org_code,
          role: 'COMMITTEE'
        }
        self.formData.push(c)
      });      
    }

    if(self.stakeholder.approvers!==undefined){
      self.stakeholder.approvers.forEach(element => {
        let a = {
          emp_no: element,
          org_code: self.stakeholder.org_code,
          role: 'APPROVER'
        }
        self.formData.push(a)
      });
    }

    //console.log(self.formData)

    if(self.formData.length>0)
    {
      await axios.post(`${environment.API_URL}Stakeholder`,self.formData, self.headers)
      .then(function (response) {
        Swal.fire({
          toast: true,
          position: 'top-end',
          icon: 'success',
          title: "Success",
          showConfirmButton: false,
          timer: 2000
        })
        self.reset_form_stakeholder()
        self.get_stakeholders()
      })
      .catch(function (error) {
        Swal.fire({
          icon: 'error',
          title: error.response.status,
          text: error.response.data
        })
      });      
    }
    else
    {
      await axios.post(`${environment.API_URL}Stakeholder/Reset/${self.stakeholder.org_code}`, [], self.headers)
      .then(function (response) {
        Swal.fire({
          toast: true,
          position: 'top-end',
          icon: 'success',
          title: "Success",
          showConfirmButton: false,
          timer: 2000
        })
        self.reset_form_stakeholder()
        self.get_stakeholders()
      })
      .catch(function (error) {
        Swal.fire({
          icon: 'error',
          title: error.response.status,
          text: error.response.data
        })
      });   
    }
    
    self.reset_form_stakeholder()

  }





}

