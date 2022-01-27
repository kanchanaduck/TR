import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-stakeholder',
  templateUrl: './stakeholder.component.html',
  styleUrls: ['./stakeholder.component.scss']
})
export class StakeholderComponent implements OnInit {

  dtOptions: any = {};
  closeResult = '';
  stakeholder: any = {};
  
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
          "data": "org_abb",
          "render": function ( data, type, row ) {
            if (row.level_name == 'division'){
              return `<div class="tx-bold">${data}</div>`
            }
            else if (row.level_name == 'department'){
              // return `<div class="tx-bold">${data}</div>`
              
              return `<div class="pl-3">${row.parent_org.org_abb} - ${data}</div>`
            }
            else if (row.level_name == 'center'){
              return row.org_name
            }
          },
        },
        { 
          "data": "level_name",
          className: 'text-uppercase',
        },
        { 
          "data": "stakeholders.role",
          "render": function ( data, type, row ) {
              /* if (row.stakeholders.role == 'committee'){
                return `<div class="tx-bold">${row.stakeholders.emp_no}</div>`
              } */
          },
        },
        { 
          "data": "stakeholders.role",
          "render": function ( data, type, row ) {
            /* if (row.stakeholders.role == 'approver'){
              return `<div class="tx-bold">${row.stakeholders.emp_no}</div>`
            } */
          },
        },
        { 
          "data": "org_abb",
          className: 'text-center',
          "render": function ( data, type, row ) {
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
      order: [ [0, 'asc'],[1, 'desc']],
      columnDefs: [ {
        targets: [ 4 ],
          orderable: false 
      } ],  
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
  }

  get_stakeholder(data: Object | any[]) {
    throw new Error('Method not implemented.');
  }

save_stakeholder(){
  
}



}

