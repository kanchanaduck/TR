import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-trainee-count',
  templateUrl: './trainee-count.component.html',
  styleUrls: ['./trainee-count.component.scss']
})
export class TraineeCountComponent implements OnInit {
  data_grid: any = [];
  dtOptions: any = {};

  constructor() { }

  ngOnInit(): void {
    this.data_grid = ELEMENT_DATA;

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
      filter: {
        "dom": {
          "container": {
            tag: "div",
            className: "dt-buttons btn-group flex-wrap float-left"
          },
        }
      },
      buttons: {
        "dom": {
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
            extend: 'pageLength',
          },
          {
            extend: 'copy',
            text: '<i class="fas fa-copy"></i> Copy</button>',
          },
          {
            extend: 'print',
            text: '<i class="fas fa-print"></i> Print</button>',
          },
          {
            extend: 'collection',
            text: '<i class="fas fa-cloud-download-alt"></i> Download</button>',
            split: ['csv', 'pdf', 'excel'],
          }
        ],
      },
      container: "#example_wrapper .col-md-6:eq(0)",
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
    };
  }
  onDateSelectTo(event) {
    console.log('onDateSelectTo: ', event);
  }
  onDateSelectFrom(event) {
    console.log('onDateSelectFrom: ', event);
  }
}

export interface PeriodicElement {
  course_no: string;
  course_name_th: string;
  course_name_en: string;
  start_date: string;
  end_date: string;
  place: string;
  count: number;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    course_no: 'PTM-001-001',
    course_name_th: 'ข้อบังคับการทำงาน',
    course_name_en: 'COMPANY RULES',
    start_date: '2013-10-30',
    end_date: '2013-10-30',
    place: 'TRAINING ROOM 2',
    count: 48,
  }, {
    course_no: 'PTM-001-002',
    course_name_th: 'ข้อบังคับการทำงาน',
    course_name_en: 'COMPANY RULES',
    start_date: '2014-05-03',
    end_date: '2014-05-03',
    place: 'TRAINING ROOM 1',
    count: 16,
  }, {
    course_no: 'PTM-002-001',
    course_name_th: 'การพัฒนาทักษะหัวหน้างาน',
    course_name_en: 'MANAGEMENT & LEADERSHIP SKILL DEVELOPMENT',
    start_date: '2013-11-08',
    end_date: '2013-11-09',
    place: 'CHOLAPRUEK RES ...',
    count: 22,
  }, {
    course_no: 'PTM-003-001',
    course_name_th: 'การอบรบพนักงานหลังการทดลองงาน',
    course_name_en: 'TRAINING OF EMP. PASS PROBATION',
    start_date: '2015-01-28',
    end_date: '2015-01-28',
    place: 'TRAINING ROOM 2',
    count: 16,
  }, 
];
