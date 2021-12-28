import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-course-target',
  templateUrl: './course-target.component.html',
  styleUrls: ['./course-target.component.scss']
})
export class CourseTargetComponent implements OnInit {
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
}

export interface PeriodicElement {
  emp_no: string;
  status_eng: string;
  gname_eng: string;
  fname_eng: string;
  posn_name: string;
  dept_abb_name: string;
  div_abb_name: string;
  status_th: string;
  gname_th: string;
  fname_th: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    emp_no: '014748',
    status_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA',
    posn_name: 'PROGRAMMER',
    dept_abb_name: 'ICD',
    div_abb_name: 'CPD',
    status_th: 'นางสาว',
    gname_th: 'นุตยา',
    fname_th: 'กัลลา',
  },{
    emp_no: '014205',
    status_eng: 'MR.',
    gname_eng: 'KHETCHANA',
    fname_eng: 'KETSAUAONG',
    posn_name: 'TECHNICIAN',
    dept_abb_name: 'ICD',
    div_abb_name: 'CPD',
    status_th: 'นาย',
    gname_th: 'เขตชนะ',
    fname_th: 'เกษสาวงค์',
  },
];
