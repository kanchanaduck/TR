import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { SelectionModel } from '@angular/cdk/collections';
import axios from 'axios';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { AppServiceService } from '../../app-service.service';
@Component({
  selector: 'app-course-master',
  templateUrl: './course-master.component.html',
  styleUrls: ['./course-master.component.scss'],
})
export class CourseMasterComponent implements OnInit {

  dtOptions: any = {};
  courses: any = [];
  course: any = {};
  bands: any = [];
  errors: any;
  course_masters_bands: any = [];


  constructor(private service: AppServiceService) {
  }

  ngOnInit() {

    this.course.dept_abb_name = 'MTP'

    this.dtOptions = {
      ajax: {
        url: `${environment.API_URL}CourseMasters`,
        headers: {
          Authorization: 'Bearer ' + localStorage.getItem('token_hrgis')
        },
        dataSrc: "",
      },
      columns:
      [
        { 
          "data": "course_no",
          "className": "text-center",
          "render": function ( data, type, row ) {
            return `<input type="checkbox" value=${data}>`
          },
        },
        { 
          "data": "course_no" 
        },
        { 
          "data": "course_name_th" 
        },
        { 
          "data": "course_name_en" 
        },
        { 
          "data": "dept_abb_name",
          "className": "text-center"
        },
        { 
          "data": "capacity",
          "className": "text-right"
        },
        { 
          "data": "prev_course_no"
        },
        { 
          "data": "days",
          "className": "text-right"
        },
        { 
          "data": "category" 
        },
        { 
          "data": "level" 
        },
        { 
          "data": "course_no",
          "className": "text-center",
          "render": function ( data, type, row ) {
            return `<a href="javascript:;"><i class="far fa-edit">
            </i></a><a href="javascript:;"><i class="far fa-trash-alt"></i></a>`
          },
        },
      ],
      dom: "<'row'<'col-sm-12 col-md-4'f><'col-sm-12 col-md-8'B>>" +
      "<'row'<'col-sm-12'tr>>" +
      "<'row'<'col-sm-12 col-md-4'i><'col-sm-12 col-md-8'p>>",
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
            ]
          },
        ],
      },
      order: [ [1, 'asc']],
      columnDefs: [ {
        targets: [ 0, 10 ],
        "orderable": false
      } ],

      container: "#example_wrapper .col-md-6:eq(0)",
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
      rowCallback: (row: Node, data: any[] | Object, index: number) => {
        const self = this;
        $('.fa-trash-alt', row).off('click');
        $('.fa-trash-alt', row).on('click', () => {
          self.delete_course(data);
        });
        $('.fa-edit', row).off('click');
        $('.fa-edit', row).on('click', () => {
          self.get_course(data);
        });
        return row;
      }
    };


    this.get_courses()
    this.get_bands()
    

  }

  isInCourseMaster(band:string){
      return this.courses.some(function(el) {
          return el.band === band;
      }); 
  }

  
  async get_courses() {
    let self = this
    self.errors = null;
    try {
      const response = await axios.get(`${environment.API_URL}CourseMasters/`, { headers: { Authorization: 'Bearer ' + localStorage.getItem('token_hrgis'), Pragma: 'no-cache' } });
      this.courses = response
      return response;
    } 
    catch (error) {
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: "Data not found"
      })
    }
    console.log('data: ', this.course);
  }

  async get_course(data: any) {
    let self = this
    self.errors = null;
    try {
      const response = await axios.get(`${environment.API_URL}CourseMasters/${data.course_no}`, { headers: { Authorization: 'Bearer ' + localStorage.getItem('token_hrgis'), Pragma: 'no-cache' } });
      this.course = response
      return response;
    } 
    catch (error) {
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: "Data not found"
      })
    }
    console.log('data: ', this.course);
  }

  delete_course(data: any) {
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
        let response = await this.service.axios_delete(`CourseMasters/${data.course_no}`, 'Delete data success.');
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
  
  get_bands(){
    axios.get(`${environment.API_URL}Bands`).then(response => (
      this.bands = response
    ));
  }

  trackByIdx(index: number, obj: any): any {
    return index;
  }
  
  save_course_master(){
    console.log(this.course)
    /* let self = this
    self.errors = null;
    axios.post(`${environment.API_URL}CourseMasters`,this.course)
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
      self.errors = error.response.data.errors
      if(error.response.status==400){
        Swal.fire({
          icon: 'error',
          title: error.response.status,
          text: error.response.data.title
        })
      }
      else{
        Swal.fire({
          icon: 'error',
          title: error.response.status,
          text: error.response.data
        })        
      }

    }); */
    // alert("reload")
  }

}
