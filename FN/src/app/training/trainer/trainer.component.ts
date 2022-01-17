import { AfterViewInit, Component, OnDestroy, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DataTableDirective } from 'angular-datatables';
import axios from 'axios';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { AppServiceService } from '../../app-service.service';
import { Subject } from 'rxjs';

// DBCC CHECKIDENT ('HRGIS.dbo.tr_trainer', RESEED, 0)

@Component({
  selector: 'app-trainer',
  templateUrl: './trainer.component.html',
  styleUrls: ['./trainer.component.scss']
})
export class TrainerComponent implements OnInit {

  // @ViewChild(DataTableDirective, {static: false});
  // dtElements: QueryList<DataTableDirective>;

  @ViewChildren(DataTableDirective)
  dtElements: QueryList<DataTableDirective>;

  dtOptions: any = {};
  trainer: any = {};
  errors: any;
  dtElement: DataTableDirective;
  dtInstance: Promise<DataTables.Api>;

  constructor(private service: AppServiceService) { }

  // ngOnDestroy(): void {
  //   this.dtTrigger.unsubscribe();
  // }
  // ngAfterViewInit(): void {
  //   this.dtTrigger.next();
  // }

  ngOnInit(): void {

    this.trainer.trainer_type = 'Internal';

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
      "processing": true,
      ajax: {
        url: environment.API_URL+"Trainers",
        dataSrc: "",
      },
      detroy: true,
      columns:
      [
        { 
          "data": "trainer_no",
          "render": function ( data, type, row ) {
            return `<input type="checkbox" value=${data}>`
          },
        },
        { "data": "emp_no" },
        { "data": "sname_en" },
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
            return `
              <a href="javascript:;" data-trainer-no="${data}"><i class="far fa-edit"></i></a>
              <a href="javascript:;" data-trainer-no="${data}"><i class="far fa-trash-alt"></i></a>`
          },
        },
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
      order: [[7, 'desc'],[1, 'asc']],
      rowGroup: {
        dataSrc: "trainer_type"
      },
      columnDefs: [ 
        {
          targets: [ 0,8,9],
          orderable: false 
        } 
      ],
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
      drawCallback: () => {
        $('.fa-edit').on('click', () => {
          console.log($(this))
          alert($(this).data('trainer-no'))  
          this.edit_trainer($(this).data('trainer-no'));
        });
        $('.fa-trash-alt').on('click', () => {  
          this.delete_trainer($(this).data('trainer-no'));
        });
      }
    };
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
    try {
      const response = await axios.get(`${environment.API_URL}Employees/${this.trainer.emp_no}`, { headers: { Authorization: 'Bearer ' + localStorage.getItem('token'), Pragma: 'no-cache' } });
      this.trainer = response
      this.trainer.trainer_type='Internal';
      return response;
    } 
    catch (error) {
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

  async change_trainer_type(event: any) {
    this.reset_form_trainer()
    this.trainer.trainer_type = event;
  }

  async save_trainer() {
    this.trainer.sname_en = this.trainer.sname_eng
    this.trainer.gname_en = this.trainer.gname_eng
    this.trainer.fname_en = this.trainer.fname_eng
    const instance = axios.create({
      baseURL: environment.API_URL,
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
        'Content-Type': 'application/json'
      }
    });
    const response = await instance.post('Trainers',this.trainer);
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
    this.reload_datatable()
    return response;
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
      try{
      if (result.value) {
        let response = await this.service.axios_delete(`Trainers/${trainer_no}`, 'Delete data success.');
        console.log(response);
        this.reload_datatable()
      }
    }
    catch(error){
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data
      })
    }
    })
  }

  async edit_trainer(event: any) {
    alert("Edit")
  }


  reload_datatable(): void {
    alert("Reload")
    this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
      dtInstance.ajax.reload()
    });
  }
}

