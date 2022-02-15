import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import axios from 'axios';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';
import { AppServiceService } from '../../app-service.service';
import { Subject } from 'rxjs';
import { DataTableDirective } from 'angular-datatables';
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
  errors: any = {};
  course_masters_bands: any = [];
  dtTrigger: Subject<any> = new Subject();
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  isDtInitialized: boolean = false;
  headers: any = {
    headers: {
    Authorization: 'Bearer ' + localStorage.getItem('token_hrgis'),
      'Content-Type': 'application/json'
    }
  }
  departments: any;
  edit_mode: boolean = false;
  _getjwt: any;
  _dept_code: any;


  constructor(
    private service: AppServiceService, 
    private httpClient: HttpClient
  ) {}

  ngOnInit() {

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
      order: [ [3, 'asc'], [0, 'asc']],
      rowGroup: {
        dataSrc: [3]
      },
      columnDefs: [ 
        {
          targets: [ 0,8 ],
          "orderable": false
        },
        {
          targets: [ 3 ],
          visible: false 
        } 
      ],

      container: "#example_wrapper .col-md-6:eq(0)",
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
    };
    this._getjwt = this.service.service_jwt();  // get jwt
    this._dept_code = this._getjwt.user.dept_code; // set emp_no


    this.get_courses("")
    this.get_bands()
    this.get_departments()

    
  }

  custom_search_org_fn(term: string, item: any) {
    term = term.toLowerCase();
    return item.org_code.toLowerCase().indexOf(term) > -1 ||  item.org_abb.toLowerCase().indexOf(term) > -1 ||item.org_abb.toLowerCase() === term;
  }

  custom_search_course_fn(term: string, item: any) {
    term = term.toLowerCase();
    return item.course_no.toLowerCase().indexOf(term) > -1 ||  item.course_name_th.toLowerCase().indexOf(term) > -1 ||  item.course_name_.toLowerCase().indexOf(term) > -1;
  }

  group_by_parent_org_code_fn = (item) => item.parent_org_code;
  group_value_parent_org_code_fn = (_: string, children: any[]) => ({ org_abb: children[0].parent_org.org_abb, org_code: children[0].parent_org.org_code });
  
  compare_org = (item, selected) => {
    if (item.org_code && selected) {
      return item.org_code === selected;
    }
    return false;
  };

  isInCourseMaster(band:string){
    return this.courses.some(function(el){
      return el.band === band;
    }); 
  }

  async reset_form_course_master(){
    this.errors = {};
    this.course = {};
    this.get_bands();
    this.edit_mode = false;
  }

  async get_courses(org_code){
    let self = this
    if(org_code==undefined || org_code==""){
      org_code = ""
    }
    await this.httpClient.get(`${environment.API_URL}CourseMasters/${org_code}`, this.headers)
    .subscribe((response: any) => {
      self.courses = response;
      if (this.isDtInitialized) {
        this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
          dtInstance.destroy();
          this.dtTrigger.next();
        });
      } 
      else {
        this.isDtInitialized = true
        this.dtTrigger.next();
      }
    },
    (error: any) => {
      console.log(error);
    });
  }


  async get_course(course_no: number) {
    console.log(course_no)
    this.errors = [];
    let self = this
    self.get_bands()
    this.edit_mode = true;
    await axios.get(`${environment.API_URL}CourseMasters/${course_no}`, this.headers)
      .then(function (response) {
        self.course = response
        console.log(response)
        console.log(self.course)
        self.course.course_masters_bands.forEach(element => {
          element.isChecked= false
        });

        console.log(self.course.course_masters_bands)

        for (const i of self.course.course_masters_bands) {
          console.log(i)
          self.bands.find(v => v.band === i.band).isChecked = true;
        }

      }) 
      .catch(function (error) {
        Swal.fire({
          icon: 'error',
          title: error.response.status,
          text: error.response.data
        })
    })
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
    let self = this
    axios.get(`${environment.API_URL}Bands`, this.headers).then(response => (
      self.bands = response
    ));

    self.bands.forEach(element => {
      element.isChecked= false
    });
  }

  async get_departments() {
    let self = this
    await axios.get(`${environment.API_URL}Organization/Level/Department/Parent`, this.headers)
    .then(function (response) {
      self.departments = response
    })
    .catch(function (error) {
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data
      })
    });
  }
  
  save_course_master(){
    // console.log(this.bands)
    // console.log(this.course)

    this.course.course_masters_bands = this.bands.filter(element => element.isChecked == true);

    console.log(this.course.course_masters_bands)

    let self = this
    self.errors = null;

    if(self.edit_mode){
      axios.put(`${environment.API_URL}CourseMasters/${self.course.course_no}`, this.course, this.headers)
      .then(function (response) {
        Swal.fire({
          toast: true,
          position: 'top-end',
          icon: 'success',
          title: "Success",
          showConfirmButton: false,
          timer: 2000
        })
        self.reset_form_course_master();
        self.get_courses("");
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
      });
  }
  else{
    axios.post(`${environment.API_URL}CourseMasters`, this.course, this.headers)
    .then(function (response) {
      Swal.fire({
        toast: true,
        position: 'top-end',
        icon: 'success',
        title: "Success",
        showConfirmButton: false,
        timer: 2000
      })
      self.reset_form_course_master();
      self.get_courses("");
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
    });
  }

  }

}
