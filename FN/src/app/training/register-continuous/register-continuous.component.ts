import { Component, OnInit, ViewChild } from '@angular/core';
import Swal from 'sweetalert2';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AppServiceService } from '../../app-service.service';
import { ExportService } from '../../export.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-register-continuous',
  templateUrl: './register-continuous.component.html',
  styleUrls: ['./register-continuous.component.scss']
})
export class RegisterContinuousComponent implements OnInit {
  data_grid: any = [];
  dt_options: any = {};

  @ViewChild("txtcourse_name_en") txtcourse_name_en;
  @ViewChild("txtgroup") txtgroup;
  @ViewChild("txtqty") txtqty;
  @ViewChild("txtdate_from") txtdate_from;
  @ViewChild("txtdate_to") txtdate_to;
  @ViewChild("txtplace") txtplace;
  @ViewChild("txtpre_test_grade") txtpre_test_grade;
  @ViewChild("txtpost_test_grade") txtpost_test_grade;
  @ViewChild("txttotal") txttotal;
  ck_e: boolean = false;
  ck_j1: boolean = false;
  ck_j2: boolean = false;
  ck_j3: boolean = false;
  ck_j4: boolean = false;
  ck_m1: boolean = false;
  ck_m2: boolean = false;
  dept_abb_name = 'ICD';

  form: FormGroup;
  submitted = false;

  constructor(private formBuilder: FormBuilder, private service: AppServiceService, private exportexcel: ExportService) {

  }

  ngOnInit() {
    // this.data_grid = ELEMENT_DATA;

    this.dt_options = {
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
          }, {
            extend: 'collection',
            text: '<i class="fas fa-cloud-download-alt"></i> Download</button>',
            buttons: [
              {
                extend: 'excel',
                text: '<i class="far fa-file-excel"></i> Excel</button>',
              },
              {
                extend: 'csv',
                text: '<i class="far fa-file-excel"></i> Csv</button>',
              },
              {
                extend: 'pdf',
                text: '<i class="far fa-file-pdf"></i> Pdf</button>',
              },
            ]
          }
        ],
      },
      container: "#example_wrapper .col-md-6:eq(0)",
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
    };

    this.form = this.formBuilder.group(
      {
        frm_course: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(20)]],
        frm_emp_no_from: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(7)]],
        frm_emp_no_to: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(7)]],
        frm_pre_test_score: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(3)]],
        frm_post_test_score: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(3)]],
      },
    );

    this.fnGetEmp();
  }
  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }

  async fnSave() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }
    console.log(JSON.stringify(this.form.value, null, 2));

    let frm = this.form.value;
    var n = parseInt(frm.frm_emp_no_from);
    var x = parseInt(frm.frm_emp_no_to);
    var array = [];
    var array_non = [];

    while (n <= x) {
      const result = {}
      const result_non = {}
      const padded = n.toString().padStart(6, '0');
      let filters = this.res_emp.filter(x => x.emp_no == padded); // console.log(filters);

      if (filters.length > 0) { // ตรวจสอบข้อมูลระหว่าง emp_no ที่กรอก กับข้อมูลใน employee
        let filter_conf = this.res_conflict.filter(x => x.emp_no == padded); console.log('filter_conf: ', filter_conf);
        if (filter_conf.length > 0) { // ตรวจสอบข้อมูลระหว่าง emp_no ที่กรอก กับข้อมูลในที่ถูก register ไปแล้ว
          result_non["emp_no"] = padded;
          result_non["remark"] = environment.text.duplication;
          array_non.push(result_non);
        } else {
          result["emp_no"] = padded;
          array.push(result);
        }
      } else if (filters.length == 0) {
        result_non["emp_no"] = padded;
        result_non["remark"] = "The employee do not match with database.";
        array_non.push(result_non);
      }
      result["pre_test_score"] = frm.frm_pre_test_score;
      result["pre_test_grade"] = this.txtpre_test_grade.nativeElement.value;
      result["post_test_score"] = frm.frm_post_test_score;
      result["post_test_grade"] = this.txtpost_test_grade.nativeElement.value;

      n++;
    }
    console.log(array);
    console.log(array_non);

    const send_data = {
      course_no: frm.frm_course,
      array: array
    }
    console.log(send_data);

    if (array.length > 0) {
      await this.service.axios_post("RegisterScore", send_data, environment.text.success);
    }

    if (array_non.length > 0) {
      let element = array_non;
      this.exportexcel.exportJSONToExcel(element, 'ResultRegisterContinuous');
    }

    this.fnGet(frm.frm_course);
  }
  fnClear() {
    this.form.controls['frm_emp_no_from'].setValue("");
    this.form.controls['frm_emp_no_to'].setValue("");
    this.form.controls['frm_pre_test_score'].setValue("");
    this.txtpre_test_grade.nativeElement.value = "";
    this.form.controls['frm_post_test_score'].setValue("");
    this.txtpost_test_grade.nativeElement.value = "";
    this.txttotal.nativeElement.value = "";
  }
  fnDelete(item) {
    Swal.fire({
      title: 'Are you sure?',
      text: 'you want to delete this record',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes',
      cancelButtonText: 'No'
    }).then(async (result) => {
      if (result.value) {
        await this.service.axios_delete('RegisterScore/' + item.course_no + '/' + item.emp_no , environment.text.delete);
        this.fnGet(item.course_no);
      }
    })
  }

  res_course: any = [];
  arr_band: any;
  async onKeyCourse(event: any) { // console.log(event.target.value);
    if (event.target.value.length >= 11 && event.target.value.length < 12) {
      this.res_course = await this.service.axios_get('CourseOpen/' + event.target.value);
      if (this.res_course != undefined) {
        this.txtcourse_name_en.nativeElement.value = this.res_course.course_name_en;
        this.txtgroup.nativeElement.value = this.res_course.dept_abb_name;
        this.txtqty.nativeElement.value = this.res_course.capacity;
        this.txtdate_from.nativeElement.value = formatDate(this.res_course.date_start).toString() + ' ' + this.res_course.time_in;
        this.txtdate_to.nativeElement.value = formatDate(this.res_course.date_end).toString() + ' ' + this.res_course.time_out;
        this.txtplace.nativeElement.value = this.res_course.place;

        this.arr_band = this.res_course.courses_bands; // console.log(this.arr_band);
        var nameArr = this.res_course.courses_bands; //console.log(nameArr);
        this.ck_e = nameArr.some(item => item.band === "E");
        this.ck_j1 = nameArr.some(item => item.band === "J1");
        this.ck_j2 = nameArr.some(item => item.band === "J2");
        this.ck_j3 = nameArr.some(item => item.band === "J3");
        this.ck_j4 = nameArr.some(item => item.band === "J4");
        this.ck_m1 = nameArr.some(item => item.band === "M1");
        this.ck_m2 = nameArr.some(item => item.band === "M2");

        this.fnGet(event.target.value);
        this.fnGetConflict(event.target.value);
      }
    } else if (event.target.value.length < 11) {
      this.txtcourse_name_en.nativeElement.value = "";
      this.txtgroup.nativeElement.value = "";
      this.txtqty.nativeElement.value = "";
      this.txtdate_from.nativeElement.value = "";
      this.txtdate_to.nativeElement.value = "";
      this.txtplace.nativeElement.value = "";
      this.ck_e = false;
      this.ck_j1 = false;
      this.ck_j2 = false;
      this.ck_j3 = false;
      this.ck_j4 = false;
      this.ck_m1 = false;
      this.ck_m2 = false;
      this.fnClear();
    }
  }
  onKeyEmpNoFrom(event) {
    let check;
    check = fnEmpNoTotal(event.target.value, this.form.controls['frm_emp_no_to'].value);
    if (check >= 0) {
      this.txttotal.nativeElement.value = fnEmpNoTotal(event.target.value, this.form.controls['frm_emp_no_to'].value);
      this.form.get('frm_emp_no_to').setErrors(null);
    } else {
      this.txttotal.nativeElement.value = fnEmpNoTotal(event.target.value, this.form.controls['frm_emp_no_to'].value);
      this.form.get('frm_emp_no_from').setErrors({ someErrorFrom: true });
    }
  }
  onKeyEmpNoTo(event) {
    let check;
    check = fnEmpNoTotal(this.form.controls['frm_emp_no_from'].value, event.target.value);
    if (check >= 0) {
      this.txttotal.nativeElement.value = fnEmpNoTotal(this.form.controls['frm_emp_no_from'].value, event.target.value);
      this.form.get('frm_emp_no_from').setErrors(null);
    } else {
      this.txttotal.nativeElement.value = fnEmpNoTotal(this.form.controls['frm_emp_no_from'].value, event.target.value);
      this.form.get('frm_emp_no_to').setErrors({ someErrorTo: true });
    }
  }
  onKeyPreTestScore(event) {
    console.log(event.target.value);
    this.txtpre_test_grade.nativeElement.value = fnGrade(event.target.value);
  }
  onKeyPostTestScore(event) {
    this.txtpost_test_grade.nativeElement.value = fnGrade(event.target.value);
  }

  res_get: any;
  async fnGet(course_no) {
    this.res_get = await this.service.axios_get('RegisterScore/' + course_no);
    console.log('res_get: ', this.res_get);
    this.data_grid = await this.res_get;
  }
  res_conflict: any;
  async fnGetConflict(course_no) {
    this.res_conflict = await this.service.axios_get('RegisterScore/' + course_no);
    console.log('res_conflict: ', this.res_conflict);
  }
  res_emp: any;
  async fnGetEmp() {
    this.res_emp = await this.service.axios_get('Employees');
    console.log('res_emp: ', this.res_emp);
  }
}

function formatDate(date) {
  var d = new Date(date),
    month = '' + (d.getMonth() + 1),
    day = '' + d.getDate(),
    year = d.getFullYear();

  if (month.length < 2)
    month = '0' + month;
  if (day.length < 2)
    day = '0' + day;

  return [year, month, day].join('-');
}

function fnEmpNoTotal(start, end) {
  // console.log('start: ', parseInt(start), ' end: ', parseInt(end));
  let total = 0;
  total = parseInt(end) - parseInt(start);
  return isNaN(total) ? 0 : total;
}
function fnGrade(score) {
  let grade = "Fail";

  if (score == "") { grade = ""; }
  else if (score >= 80 && score <= 100) { grade = "A"; }
  else if (score >= 70 && score <= 79) { grade = "B"; }
  else if (score >= 60 && score <= 69) { grade = "C"; }
  else if (score >= 50 && score <= 59) { grade = "D"; }
  else if (score >= 1 && score <= 49) { grade = "E"; }
  else if (score == 0) { grade = "F"; }

  return grade;
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
    emp_no: '014749',
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
    emp_no: '014750',
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
    emp_no: '014751',
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
    emp_no: '014752',
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
    emp_no: '014753',
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
    emp_no: '014754',
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
    emp_no: '014755',
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
    emp_no: '014756',
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
    emp_no: '014757',
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
    emp_no: '014758',
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
    emp_no: '014759',
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
    emp_no: '014760',
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
