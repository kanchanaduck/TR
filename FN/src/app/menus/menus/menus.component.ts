import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-menus',
  templateUrl: './menus.component.html',
  styleUrls: ['./menus.component.scss']
})
export class MenusComponent implements OnInit {

  menus: any = [];
  menu: any = {};
  dtOptions: any = {};

  constructor() { }

  ngOnInit(): void {

    this.dtOptions = {
      dom: "<'row'<'col-sm-12 col-md-4'f><'col-sm-12 col-md-8'B>>" +
      "<'row'<'col-sm-12'tr>>" +
      "<'row'<'col-sm-12 col-md-4'i><'col-sm-12 col-md-8'p>>",
      ajax: {
        url: environment.API_URL+"Menus",
        dataSrc: "",
      },
      columns:
      [
        { 
          "data": "menu_code",
          "className": "text-center",
          "render": function ( data, type, row ) {
            return `<input type="checkbox" value=${data}>`
          },
        },
        { "data": "menu_code" },
        { "data": "menu_name" },
        /* { "data": "children.menu_code" },
        { "data": "gname_en" },
        { "data": "fname_en" },
        { 
          "data": "organization",
          "render": function ( data, type, row ) {
            if(row.div_abb_name==null){
              return row.organization
            }
            else{
              return `${row.div_abb_name} - ${row.dept_abb_name}`
            }
          },
        },
        { "data": "employed_status" },
        { "data": "trainer_type" },
        { 
          "data": "trainer_no",
          "className": "text-center",
          "render": function ( data, type, row ) {
            return `<a href="javascript:;"><i class="far fa-eye"></i></a>`
          },
        },
        { 
          "data": "trainer_no",
          "className": "text-center",
          "render": function ( data, type, row ) {
            let edit_icon = `<a href="javascript:;"><i class="far fa-edit"></i></a>`
            let delete_icon = `<a href="javascript:;"><i class="far fa-trash-alt"></i></a>`
            return row.trainer_type=="Internal"? `${delete_icon}`:`${edit_icon}${delete_icon}`
          },
        }, */
      ],
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
      // order: [[7, 'desc'],[1, 'asc']],
      rowGroup: {
        dataSrc: "parent_menu_code"
      },
      columnDefs: [ 
        {
          targets: [ 0],
          orderable: false 
        } 
      ],
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
      rowCallback: (row: Node, data: any[] | Object, index: number) => {
        const self = this;
        $('.fa-trash-alt', row).off('click');
        $('.fa-trash-alt', row).on('click', () => {
          self.delete_menu(data);
        });
        $('.fa-edit', row).off('click');
        $('.fa-edit', row).on('click', () => {
          self.get_menu(data);
        });
        return row;
      }
    };
  }

  delete_menu(data: Object | any[]) {
    throw new Error('Method not implemented.');
  }

  async get_menu(data: any) {
    this.menu = data
    try {
      const response = await axios.get(`${environment.API_URL}Menus`, { headers: { Authorization: 'Bearer ' + localStorage.getItem('token_hrgis'), Pragma: 'no-cache' } });
      this.menu = response
      return response;
    } 
    catch (error) {
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: "Data not found"
      })
    }
    console.log('data: ', this.menu);
  }

}
