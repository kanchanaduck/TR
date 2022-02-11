import { Component, OnInit, ViewChild } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { HttpClient } from '@angular/common/http';
import axios from 'axios';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-course-map',
  templateUrl: './course-map.component.html',
  styleUrls: ['./course-map.component.scss']
})
export class CourseMapComponent implements OnInit {

  course_map: any = [];
  org_code: string = "2230";
  employed_status: string = "employed";

  dtOptions: any = {};
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
  group_by_parent_org_code_fn: (item: any) => any;
  group_value_parent_org_code_fn: (_: string, children: any[]) => { org_abb: any; org_code: any; };
  compare_org: (item: any, selected: any) => boolean;


  constructor(private httpClient: HttpClient) { }

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
            ]
          },
        ],
      },
      /* order: [ [0, 'asc'],[2, 'desc'], [1, 'asc']],*/ 
      columnDefs: [ 
        {
          targets: [ 'nosort' ],
          orderable: false 
        },
      ],  
      container: "#example_wrapper .col-md-6:eq(0)",
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
    };

    this.get_course_map()
    this.get_departments()
  }



  async get_course_map(){
    let self = this
    await this.httpClient.get(`${environment.API_URL}Employees/Course/${self.org_code}/${self.employed_status}`, this.headers)
    .subscribe((response: any) => {
      self.course_map = response;
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

  async get_departments() {
    let self = this
    await axios.get(`${environment.API_URL}Organization/Level/Department/Parent`, this.headers)
    .then(function (response) {
      self.departments = response
      //console.log(response)
      self.group_by_parent_org_code_fn = (item) => item.parent_org_code;
      self.group_value_parent_org_code_fn = (_: string, children: any[]) => ({ org_abb: children[0].parent_org.org_abb, org_code: children[0].parent_org.org_code });
      self.compare_org = (item, selected) => {
        if (selected.Grouby_parent_org_code_fn && item.Groupvalue_parent_org_code_fn) {
            return item.Grouby_parent_org_code_fn === selected.Grouby_parent_org_code_fn;
        }
        if (item.oeg_abb && selected.oeg_abb) {
            return item.oeg_abb === selected.oeg_abb;
        }
        return false;
      };
    })
    .catch(function (error) {
      //console.log(error)
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data
      })
    });
  }

}
