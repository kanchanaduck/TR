import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { SelectionModel } from '@angular/cdk/collections';
import axios from 'axios';
import Swal from 'sweetalert2';
import { AbstractControl, FormBuilder, FormControl, FormGroup, RequiredValidator, Validators } from '@angular/forms';

@Component({
  selector: 'app-course-score',
  templateUrl: './course-score.component.html',
  styleUrls: ['./course-score.component.scss']
})
export class CourseScoreComponent implements OnInit {
  data_grid: any = [];
  dtOptions: any = {};

  @ViewChild("txtcourse_no") txtcourse_no;
  @ViewChild("txtcourse_name_en") txtcourse_name_en;
  @ViewChild("txtgroup") txtgroup;
  @ViewChild("txtdate_from") txtdate_from;
  @ViewChild("txtdate_to") txtdate_to;

  @ViewChild("txtfull_name") txtfull_name;
  @ViewChild("txtdept") txtdept;
  @ViewChild("txtposition") txtposition;
  @ViewChild("txtband") txtband;
  @ViewChild("txtpre_test_grade") txtpre_test_grade;
  @ViewChild("txtpost_test_grade") txtpost_test_grade;

  form: FormGroup;
  submitted = false;

  constructor(private modalService: NgbModal, private formBuilder: FormBuilder) {
    
  }

  ngOnInit() {
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
      }, filter: {
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

    this.form = this.formBuilder.group(
      {
        frm_course: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(20)]],
        frm_emp_no: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(7)]],
        frm_pre_test_score: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(3)]],
        frm_post_test_score: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(3)]],
      },
    );
  }
  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }

  fn_save() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }
    console.log(JSON.stringify(this.form.value, null, 2));

    Swal.fire({
      toast: true,
      position: 'top-end',
      icon: 'success',
      title: 'Update data success.',
      showConfirmButton: false,
      timer: 2000
    })
  }
  fn_clear() {
    this.form.controls['frm_emp_no'].setValue("");
    this.txtfull_name.nativeElement.value = "";
    this.txtdept.nativeElement.value = "";
    this.txtposition.nativeElement.value = "";
    this.txtband.nativeElement.value = "";
    this.form.controls['frm_pre_test_score'].setValue("");
    this.txtpre_test_grade.nativeElement.value = "";
    this.form.controls['frm_post_test_score'].setValue("");
    this.txtpost_test_grade.nativeElement.value = "";
  }
  fn_edit(item) {
    console.log('fn_edit', item);
  }
  fn_delete(item) {
    console.log('fn_edit', item);
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

  onKeyCourse(event: any) { // console.log(event.target.value);
    if (event.target.value.length >= 11) {
      this.txtcourse_name_en.nativeElement.value = "QC BASIC";
      this.txtgroup.nativeElement.value = "MTP";
      this.txtdate_from.nativeElement.value = "2021-12-03";
      this.txtdate_to.nativeElement.value = "2021-12-03";
    } else if (event.target.value.length == 0) {
      this.txtcourse_name_en.nativeElement.value = "";
      this.txtgroup.nativeElement.value = "";
      this.txtdate_from.nativeElement.value = "";
      this.txtdate_to.nativeElement.value = "";
    }
  }
  onKeyEmpno(event: any) {
    if (event.target.value.length >= 6 && event.target.value.length <= 7) {
      this.searchHR(event.target.value);
    }
  }
  async searchHR(empno: any) {
    try {
      const instance = axios.create({
        headers: {
          'Content-Type': 'application/json'
        }
      });
      const body = {
        command: "SELECT band, emp_no, sname_eng, gname_eng, fname_eng, posn_ename, dept_code, dept_abb_name " +
          "FROM admin.v_emp_data_all_cpt WHERE emp_no = '" + empno + "'" +
          "ORDER BY emp_no ASC, band DESC"
      }
      const response = await instance.post('http://cptsvs531:1000/middleware/oracle/hrms', body);
      // console.log('1. oracle response: ', response); //1
      const customer = response['data']['data'][0];

      let values = response['data']['data'][0];
      console.log('1. oracle response: ', values); //1
      if (response['data']['data'].length > 0) {
        this.txtfull_name.nativeElement.value = values.SNAME_ENG + " " + values.GNAME_ENG + " " + values.FNAME_ENG;
        this.txtdept.nativeElement.value = values.DEPT_CODE + ":" + values.DEPT_ABB_NAME;
        this.txtposition.nativeElement.value = values.POSN_ENAME;
        this.txtband.nativeElement.value = values.BAND;
      } else {
        this.txtfull_name.nativeElement.value = "";
        this.txtdept.nativeElement.value = "";
        this.txtposition.nativeElement.value = "";
        this.txtband.nativeElement.value = "";
      }

      return response.data;
    } catch (error) {
      console.log('RES ERROR: ', error.response);
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data
      })
    }
  }
  onKey_pre_test_score(event) {

  }
  onKey_post_test_score(event) {

  }

  open(content){
    this.modalService.open(content, {
      size: 'mb' //sm, mb, lg
    });
  }
}

export interface PeriodicElement {
  emp_no: string;
  sname_eng: string;
  gname_eng: string;
  fname_eng: string;
  band: string;
  dept_code: string;
  dept_abb_name: string;
  prob_date: string;
  resn_date: string;
  pre_test_score: number;
  pre_test_grade: string;
  post_test_score: number;
  post_test_grade: string;
  status: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    emp_no: '014748',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA', band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    prob_date: '2021-01-01',
    resn_date: '',
    pre_test_score: 80,
    pre_test_grade: 'A',
    post_test_score: 90,
    post_test_grade: 'A',
    status: '',
  }, {
    emp_no: '014748',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA', band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    prob_date: '2021-01-01',
    resn_date: '',
    pre_test_score: 80,
    pre_test_grade: 'A',
    post_test_score: 90,
    post_test_grade: 'A',
    status: '',
  }, {
    emp_no: '014748',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA', band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    prob_date: '2021-01-01',
    resn_date: '',
    pre_test_score: 80,
    pre_test_grade: 'A',
    post_test_score: 90,
    post_test_grade: 'A',
    status: '',
  }, {
    emp_no: '014748',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA', band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    prob_date: '2021-01-01',
    resn_date: '',
    pre_test_score: 80,
    pre_test_grade: 'A',
    post_test_score: 90,
    post_test_grade: 'A',
    status: '',
  }, {
    emp_no: '014748',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA', band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    prob_date: '2021-01-01',
    resn_date: '',
    pre_test_score: 80,
    pre_test_grade: 'A',
    post_test_score: 90,
    post_test_grade: 'A',
    status: '',
  }, {
    emp_no: '014748',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA', band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    prob_date: '2021-01-01',
    resn_date: '',
    pre_test_score: 80,
    pre_test_grade: 'A',
    post_test_score: 90,
    post_test_grade: 'A',
    status: '',
  }, {
    emp_no: '014748',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA', band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    prob_date: '2021-01-01',
    resn_date: '',
    pre_test_score: 80,
    pre_test_grade: 'A',
    post_test_score: 90,
    post_test_grade: 'A',
    status: '',
  },
];

