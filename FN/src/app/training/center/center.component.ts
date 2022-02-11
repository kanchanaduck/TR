import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import axios from 'axios';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { AppServiceService } from 'src/app/app-service.service';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-center',
  templateUrl: './center.component.html',
  styleUrls: ['./center.component.scss']
})
export class CenterComponent implements OnInit {

  centers: any= [];
  center: any = {};
  errors: any;
  dtOptions: any = {};
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

  constructor(private service: AppServiceService, private httpClient: HttpClient) { }

  ngOnInit(): void {
    this.dtOptions = {
      "processing": true,
      dom: "<'row'<'col-sm-12 col-md-4'f><'col-sm-12 col-md-8'B>>" +
      "<'row'<'col-sm-12'tr>>" +
      "<'row'<'col-sm-12 col-md-4'i><'col-sm-12 col-md-8'p>>",
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
      order: [ [1, 'asc']],
      columnDefs: [ {
        targets: [ 0, 8 ],
        "orderable": false
      } ],

      container: "#example_wrapper .col-md-6:eq(0)",
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
    };


  this.get_centers()
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  async get_centers(){
    await this.httpClient.get(`${environment.API_URL}Center`, this.headers)
    .subscribe((response: any) => {
      this.centers = response;
        if (this.isDtInitialized) {
        this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
          dtInstance.destroy();
          this.dtTrigger.next();
        });
      } else {
        this.isDtInitialized = true
        this.dtTrigger.next();
      }
    });
  }

  async save_center() {  
    let self = this
    await axios.post(`${environment.API_URL}Center`,this.center,this.headers)
    .then(function (response) {
      self.get_centers()
      self.reset_form_center()
      Swal.fire({
        toast: true,
        position: 'top-end',
        icon: 'success',
        title: "Success",
        showConfirmButton: false,
        timer: 2000
      })
    })
    .catch(function (error) {
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data
      })
    });
  }

  async delete_center(emp_no: string) { 
    let self =this
    Swal.fire({
      title: 'Are you sure?',
      text: 'you want to delete this record',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes',
      cancelButtonText: 'No'
    })
    .then(async (result) => {
      if (result.value) {
        await axios.delete(`${environment.API_URL}Center/${emp_no}`, this.headers)
        .then(function (response) {
          console.log(response)
          self.get_centers()
        }) 
        .catch(function (error) {
          console.log(error)
          Swal.fire({
            icon: 'error',
            title: error.response.status,
            text: error.response.data
          })
        })
      }
    })
  }

  async reset_form_center() { 
    this.center = {};
  }

  async fillEmpNo() { 
    if(this.center.emp_no.length>=6){
      this.get_employee()
    }
  }
   
   async get_employee() {
    let self =this
    await axios.get(`${environment.API_URL}Employees/${this.center.emp_no}`,this.headers)
    .then(function (response) {
      console.log(response)
      self.center = response
    }) 
    .catch(function (error) {
      console.log(error)
      self.reset_form_center()
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data
      })
    }) 
  }

}


