import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import Swal from 'sweetalert2';
import axios from 'axios';

@Component({
  selector: 'app-stakeholder',
  templateUrl: './stakeholder.component.html',
  styleUrls: ['./stakeholder.component.scss']
})
export class StakeholderComponent implements OnInit {

  dtOptions: any = {};
  closeResult = '';
  stakeholder: any = {};
  
  departments: any;
  employees: any = [];
  errors: any;
  formData: any;

  constructor(private modalService: NgbModal) { }

  ngOnInit(): void {
    this.dtOptions = {
      ajax: {
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
      ],
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
      rowCallback: (row: Node, data: any[] | Object, index: number) => {
        const self = this;
        $('.fa-edit', row).off('click');
        $('.fa-edit', row).on('click', () => {
          self.get_stakeholder(data);
        });
        return row;
      }
    };
  
    this.get_departments();
    this.get_employees();
  
  }

  async get_employees() {
    try {
      const response = await axios.get(`${environment.API_URL}Employees`, { headers: { Authorization: 'Bearer ' + localStorage.getItem('token_hrgis'), Pragma: 'no-cache' } });
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
    // console.log('data: ', this.stakeholder);
  }

  async get_departments() {
    try {
      const response = await axios.get(`${environment.API_URL}Organization/Level/Department`, { headers: { Authorization: 'Bearer ' + localStorage.getItem('token_hrgis'), Pragma: 'no-cache' } });
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
    // console.log('data: ', this.stakeholder);
  }

  async get_stakeholder(data: Object | any[]) {
    const self = this;
    this.stakeholder = data
    try {
      const response = await axios.get(`${environment.API_URL}Stakeholder/${this.stakeholder.org_abb}`, { headers: { Authorization: 'Bearer ' + localStorage.getItem('token_hrgis'), Pragma: 'no-cache' } });
      this.stakeholder = response
      console.log(this.stakeholder)

      const committee = self.stakeholder.find(function(el){
        return el.role === "Committee"
      } )

      const approver = self.stakeholder.find(function(el){
        return el.role === "Approver"
      } )
      

      self.stakeholder.push(committee, approver)

      return response;
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
    console.log(this.stakeholder)
    this.formData = [
    {
      org_code: this.stakeholder.org_code,
      emp_no: this.stakeholder.committee,
      role: "Committee"
    },
    { 
      org_code: this.stakeholder.org_code,
      emp_no: this.stakeholder.approver,
      role: "Approver"
    }]
    console.log(this.formData)

    await axios.post(`${environment.API_URL}Stakeholder`,this.formData)
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

