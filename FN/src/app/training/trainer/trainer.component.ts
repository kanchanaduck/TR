import { AfterViewInit, Component, OnDestroy, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import axios from 'axios';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { AppServiceService } from '../../app-service.service'
import { Subject } from 'rxjs';

// DBCC CHECKIDENT ('HRGIS.dbo.tr_trainer', RESEED, 0)

@Component({
  selector: 'app-trainer',
  templateUrl: './trainer.component.html',
  styleUrls: ['./trainer.component.scss']
})
export class TrainerComponent implements OnInit {

  trainers: any= [];
  trainer: any = {};
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

  constructor(
    private service: AppServiceService, 
    private httpClient: HttpClient
  ) { }


  ngOnInit(): void {
    this.trainer.trainer_type = 'Internal';

    this.dtOptions = {
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
                {
                    text: '<i class="far fa-file-excel"></i> History</button>',
                    action: function ( e, dt, node, config ) {
                      location.href = `${environment.API_URL}Trainers/HistoryExcel`
                    }
                },
            ]
          },
        ],
      },
      order: [[6, 'desc'],[0, 'asc']],
      rowGroup: {
        dataSrc: 6
      },
      columnDefs: [ 
        {
          targets: [ 0,7,8],
          orderable: false 
        } 
      ],
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
    };

    this.get_trainers()

  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }


  async get_trainers(){
    let self = this
    await this.httpClient.get(`${environment.API_URL}Trainers`, this.headers)
    .subscribe((response: any) => {
      self.trainers = response;
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

  async reset_form_trainer() { 
    this.trainer = {};
    this.trainer.trainer_type='Internal';
  }

  async fillEmpNo(event: any) { 
    if(this.trainer.emp_no.length==6){
      this.get_employee()
    }
  }
   
  async get_employee() {
    let self =this
    await axios.get(`${environment.API_URL}Employees/${this.trainer.emp_no}`,this.headers)
    .then(function (response) {
      console.log(response)
      self.trainer = response
      self.trainer.trainer_type = "Internal"
      self.trainer.sname_en = self.trainer.sname_eng
      self.trainer.gname_en = self.trainer.gname_eng
      self.trainer.fname_en = self.trainer.fname_eng
    }) 
    .catch(function (error) {
      console.log(error)
      self.reset_form_trainer()
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data
      })
    }) 
  }

  async get_trainer(trainer_no: number) {
    try {
      const response = await axios.get(`${environment.API_URL}Trainers/${trainer_no}`, this.headers);
      this.trainer = response
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

  async change_trainer_type(event: any) {
    this.reset_form_trainer()
    this.trainer.trainer_type = event;
    this.errors = {};
  }

  async save_trainer() {
    let self = this
    await axios.post(`${environment.API_URL}Trainers`,this.trainer)
    .then(function (response) {
      Swal.fire({
        toast: true,
        position: 'top-end',
        icon: 'success',
        title: "Success",
        showConfirmButton: false,
        timer: 2000
      })
    this.reset_form_trainer()
    })
    .catch(function (error) {
      if(error.response.status==400){
        self.errors = error.response.data.errors
        Swal.fire({
          icon: 'error',
          title: error.response.status,
          text: error.response.data.title
        })
      }
      else{
        Swal.fire({
          icon: 'error',
          title: error.response.status,
          text: error.response.data
        })
      }
    });
    this.get_trainers()
  }

  async delete_trainer(trainer_no: number) {
    let self = this
    Swal.fire({
      title: 'Are you sure?',
      text: 'you want to delete this record',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes',
      cancelButtonText: 'No'
    }).then(async (result) => {
      if (result.value) {
        await axios.delete(`${environment.API_URL}Trainers/${trainer_no}`, this.headers)
        .then(function (response) {
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
        self.get_trainers()
      }
    })
  }

}

