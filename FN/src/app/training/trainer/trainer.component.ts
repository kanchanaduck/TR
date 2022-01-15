import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import axios from 'axios';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { AppServiceService } from '../../app-service.service';

@Component({
  selector: 'app-trainer',
  templateUrl: './trainer.component.html',
  styleUrls: ['./trainer.component.scss']
})
export class TrainerComponent implements OnInit {

  dtOptions: any = {};
  trainer: any = {};
  trainers: any = [];
  errors: any;
  formData: FormGroup;

  constructor(private service: AppServiceService) { }

  ngOnInit(): void {

    this.trainer.trainer_type = 'Internal';
    this.get_trainers()

    /* this.formData = new FormGroup({
      name: new FormControl('', Validators.required)),
      street: new FormControl('', Validators.minLength(3)),
      city: new FormControl('', Validators.maxLength(10)),
      zip: new FormControl('', Validators.pattern('[A-Za-z]{5}'))
    });
 */

    this.formData= new FormGroup({
      trainer_type: new FormControl(this.trainer.trainer_type, [
        Validators.required
      ]),
      // alterEgo: new FormControl(this.hero.alterEgo),
      // power: new FormControl(this.hero.power, Validators.required)
    });

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
                {
                    text: '<i class="far fa-file-excel"></i> History</button>',
                    action: function ( e, dt, node, config ) {
                       alert('เอาไว้ดาวน์โหลดประวัติการสอนค่าาา')
                    }
                },
            ]
          },
        ],
      },
      "destroy": true,
      order: [[7, 'desc']],
      rowGroup: {
        dataSrc: [ 7 ]
      },
      columnDefs: [ 
        {
          targets: [ 0,8,9],
          orderable: false 
        } 
      ],

      container: "#example_wrapper .col-md-6:eq(0)",
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
    };
  }

  async reset_form_trainer() { 
    this.trainer = {};
    this.trainer.trainer_type='Internal';
  }

  async fillEmpNo(event: any) { 
    if(this.trainer.emp_no.length==6){
      this.get_employees()
    }
  }
   
   async get_employees() {
    // this.trainer = await this.service.axios_get(`Employees/${this.trainer.emp_no}`);
    try {
      const response = await axios.get(`${environment.API_URL}Employees/${this.trainer.emp_no}`, { headers: { Authorization: 'Bearer ' + localStorage.getItem('token'), Pragma: 'no-cache' } });
      this.trainer = response
      this.trainer.trainer_type='Internal';
      return response;
    } catch (error) {
      console.error(error.stack);
      this.errors = error
      this.reset_form_trainer()
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: "Data not found"
      })
    }
    console.log('data: ', this.trainer);
  }

  async get_trainers() {
    this.trainers = await this.service.axios_get('Trainers');
    console.log('data: ', this.trainers);
  }

  async change_trainer_type(event: any) {
    this.reset_form_trainer()
    this.trainer.trainer_type = event;
  }

  async save_trainer() {
    this.trainer.sname_en = this.trainer.sname_eng
    this.trainer.gname_en = this.trainer.gname_eng
    this.trainer.fname_en = this.trainer.fname_eng
    const formData = this.trainer
    // await this.service.axios_post('Trainers',formData, "Save data success");
    try {
      const instance = axios.create({
        baseURL: environment.API_URL,
        headers: {
          Authorization: 'Bearer ' + localStorage.getItem('token'),
          'Content-Type': 'application/json'
        }
      });
      const response = await instance.post('Trainers',formData);
      this.trainer = response
      this.trainer.trainer_type='Internal';
      Swal.fire({
        toast: true,
        position: 'top-end',
        icon: 'success',
        title: "Success",
        showConfirmButton: false,
        timer: 2000
      })

      return response;
    } catch (error) {
      this.errors = error
      console.error(error.stack);
      this.reset_form_trainer()
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data
      })
    }
  }

  async delete_trainer(trainer_no: number) {
    Swal.fire({
      title: 'Are you sure?',
      text: 'you want to delete this record',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes',
      cancelButtonText: 'No'
    }).then(async (result) => {
      if (result.value) {
        let response = await this.service.axios_delete(`Trainers/${trainer_no}`, 'Delete data success.');
        console.log(response);
        // this.get_trainers();
      }
    })
  }

  async edit_trainer(event: any) {
    alert("Edit")
    // await this.service.axios_delete(`Trainers/${id}`,"Delete");
    // console.log('data: ');
  }

}
