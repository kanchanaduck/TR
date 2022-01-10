import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import { Trainer } from 'src/app/interfaces/trainer';

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

  constructor(
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
      order: [[5, 'desc']],
      rowGroup: {
        dataSrc: [ 5 ]
      },
      columnDefs: [ 
        {
          targets: [ 0,6,7],
          orderable: false 
        } 
      ],

      container: "#example_wrapper .col-md-6:eq(0)",
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
    };
  }

  fillEmpNo(event: any) { 
      let response;
      if(this.emp_no.length==6){
        const body = {
          command: `SELECT * FROM admin.v_emp_data_all_cpt WHERE emp_no='${this.emp_no}' ORDER BY emp_no ASC, band DESC`
        }
        response = axios.post('http://cptsvs531:1000/middleware/oracle/hrms', body);
     this.internal_trainer = response;
     console.log(response)
     }
  }

}
