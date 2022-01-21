import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-center',
  templateUrl: './center.component.html',
  styleUrls: ['./center.component.scss']
})
export class CenterComponent implements OnInit {
  dtOptions: any = {};
  constructor() { }

  ngOnInit(): void {
    this.dtOptions = {
      "processing": true,
      ajax: {
        url: environment.API_URL+"Center",
        dataSrc: "",
      },
      columns:
      [
        { 
          "data": "center_no",
          "render": function ( data, type, row ) {
            return `<input type="checkbox" value=${data}>`
          },
        },
        { "data": "emp_no" },
        { "data": "sname_en" },
        { "data": "gname_en" },
        { "data": "fname_en" },
        { "data": "postion_ename" },
        { "data": "div_abb_name" },
        { "data": "dept_abb_name" },
        { 
          "data": "center_no",
          "className": "text-center",
          "render": function ( data, type, row ) {
            return `<a href="javascript:;"><i class="far fa-eye"></i></a>`
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
      filter:{
        "dom":{
          "container": {
            tag: "div",
            className: "dt-buttons btn-group flex-wrap float-left"
          },
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
            className: "btn btn-outline-indigo"
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
          {
            text: '<i class="fas fa-plus"></i> New</button>',
            action: () => {
              console.log()
            }
          }
        ],
      },
      order: [ [1, 'asc']],
      /* rowGroup: {
        dataSrc: [ 1 ]
      }, */
      columnDefs: [ {
        targets: [ 0, 8 ],
        "orderable": false
      } ],

      container: "#example_wrapper .col-md-6:eq(0)",
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
    };

  }

  
  fn_delete() {
    // console.log('fn_delete', item);
    Swal.fire({
      title: 'Are you sure?',
      text: 'you want to delete this record',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes',
      cancelButtonText: 'No'
    }).then(async (result) => {
      if (result.value) {
        // let datas = {
        //   "id": dt.id,
        //   "confirm_by": this.user
        // }
        // //console.log("btndelete data:", datas)
      }
    })

  }

}
