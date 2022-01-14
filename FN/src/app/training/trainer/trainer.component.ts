import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import { Subject } from 'rxjs';
import { Trainer } from 'src/app/interfaces/trainer';
import { AppServiceService } from '../../app-service.service';

@Component({
  selector: 'app-trainer',
  templateUrl: './trainer.component.html',
  styleUrls: ['./trainer.component.scss']
})
export class TrainerComponent implements OnInit {

  dtOptions: any = {};
  external = false;
  emp_no = '';
  internal_trainer: any = {};
  trainers: any = [];

  constructor(private service: AppServiceService) { }

  ngOnInit(): void {
    this.get_trainers()

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

  async fillEmpNo(event: any) { 
    if(this.emp_no.length==6){
      this.get_employees()
    }
  }
   
   async get_employees() {
    this.internal_trainer = await this.service.axios_get(`Employees/${this.emp_no}`);
    console.log('data: ', this.internal_trainer);
  }

  async get_trainers() {
    this.trainers = await this.service.axios_get('Trainers');
    console.log('data: ', this.trainers);
  }

}
