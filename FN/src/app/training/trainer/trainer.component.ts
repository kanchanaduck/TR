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



  @ViewChildren(DataTableDirective)
  dtElement: DataTableDirective;

  dtOptions: any = {};
  // dtOptions: DataTables.Settings = {};
  trainer: any = {};
  dtInstance: Promise<DataTables.Api>;
  dtTrigger: Subject<any> = new Subject();

  constructor(private service: AppServiceService) { }


  ngOnInit(): void {
    this.trainer.trainer_type = 'Internal';

    this.dtOptions = {
      dom: "<'row'<'col-sm-12 col-md-4'f><'col-sm-12 col-md-8'B>>" +
      "<'row'<'col-sm-12'tr>>" +
      "<'row'<'col-sm-12 col-md-4'i><'col-sm-12 col-md-8'p>>",
      ajax: {
        url: environment.API_URL+"Trainers",
        dataSrc: "",
      },
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
            let edit_icon = `<a href="javascript:;"><i class="far fa-edit"></i></a>`
            let delete_icon = `<a href="javascript:;"><i class="far fa-trash-alt"></i></a>`
            return row.trainer_type=="Internal"? `${delete_icon}`:`${edit_icon}${delete_icon}`
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
      rowCallback: (row: Node, data: any[] | Object, index: number) => {
        const self = this;
        $('.fa-trash-alt', row).off('click');
        $('.fa-trash-alt', row).on('click', () => {
          self.delete_trainer(data);
        });
        $('.fa-edit', row).off('click');
        $('.fa-edit', row).on('click', () => {
          self.get_trainer(data);
        });
        return row;
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
      const response = await axios.get(`${environment.API_URL}Employees/${this.trainer.emp_no}`, { headers: { Authorization: 'Bearer ' + localStorage.getItem('token_hrgis'), Pragma: 'no-cache' } });
      this.trainer = response
      this.trainer.sname_en = this.trainer.sname_eng
      this.trainer.gname_en = this.trainer.gname_eng
      this.trainer.fname_en = this.trainer.fname_eng
      this.trainer.trainer_type='Internal';
      return response;
    } 
    catch (error) {
      console.error(error.stack);
      this.reset_form_trainer()
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: "Data not found"
      })
    }
    console.log('data: ', this.trainer);
  }

  async get_trainer(data: any) {
    this.trainer = data
    try {
      const response = await axios.get(`${environment.API_URL}Trainers/${this.trainer.trainer_no}`, { headers: { Authorization: 'Bearer ' + localStorage.getItem('token_hrgis'), Pragma: 'no-cache' } });
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
    console.log('data: ', this.trainer);
  }

  async change_trainer_type(event: any) {
    this.reset_form_trainer()
    this.trainer.trainer_type = event;
  }

  async save_trainer() {
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
      alert("Reload")
    })
    .catch(function (error) {
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data
      })
    });
    this.reset_form_trainer()
  }

  async delete_trainer(data: any) {
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
        let response = await this.service.axios_delete(`Trainers/${data.trainer_no}`, 'Delete data success.');
        console.log(response);
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

}

