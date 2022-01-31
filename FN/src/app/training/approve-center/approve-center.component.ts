import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { SelectionModel } from '@angular/cdk/collections';
import Swal from 'sweetalert2';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../../environments/environment';
import { AppServiceService } from '../../app-service.service';
import { ExportService } from '../../export.service';

@Component({
  selector: 'app-approve-center',
  templateUrl: './approve-center.component.html',
  styleUrls: ['./approve-center.component.scss']
})
export class ApproveCenterComponent implements OnInit {
  data_grid: any = [];
  dtOptions: any = {};
  @ViewChild("txtgroup") txtgroup: any;
  @ViewChild("txtqty") txtqty: any;
  v_capacity = 0;
  @ViewChild("txtdate_from") txtdate_from: any;
  @ViewChild("txtdate_to") txtdate_to: any;
  @ViewChild("txtposition") txtposition: any;
  @ViewChild("txtband") txtband: any;
  @ViewChild("txtdept") txtdept: any;
  _getjwt: any;
  dept_abb_name = '';
  checkboxesDataList: any[];
  not_pass: boolean = false;
  disabled_chkall: boolean = false;
  txt_not_pass = '';
  v_regis: number = 0;
  v_wait: number = 0;
  v_total: number = 0;

  form: FormGroup;
  submitted = false;

  constructor(private modalService: NgbModal, private formBuilder: FormBuilder, private service: AppServiceService, private exportexcel: ExportService) {

  }

  ngOnInit() {
    this.form = this.formBuilder.group(
      {
        frm_course: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(20)]],
        frm_course_name: ['', [Validators.required]],
        frm_emp_no: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(7)]],
        frm_emp_name: ['', [Validators.required]],
      },
    );
    // console.log(this.barChartData2);

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
      filter: {
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
          }, {
            text: '<i class="fas fa-check"></i> Approve</button>',
            key: '1',
            action: () => {
              this.fnApproved();
            }
          }
        ],
      },
      container: "#example_wrapper .col-md-6:eq(0)",
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
      order: [[1, 'asc']],
      columnDefs: [
        {
          targets: [0, 9],
          orderable: false
        }
      ],
      // responsive: true
    };

    this.fnGetband();
    this._getjwt = this.service.service_jwt();
    this.dept_abb_name = this._getjwt.user.dept_abb_name == 'MTP' ? environment.text.all : this._getjwt.user.dept_abb_name;
  }
  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }

  barChartData2 = [{
    label: '# of Votes',
    data: [12, 39, 20, 10, 25, 18],
  }];
  barChartLabels = ['ACC', 'CAO', 'ICD', 'MTP', 'PGA-1', 'PGA-2'];
  barChartOptions = {
    scales: {
      yAxes: [{
        ticks: {
          beginAtZero: true,
          fontSize: 10,
          min: 0,
          max: 80
        }
      }],
      xAxes: [{
        barPercentage: 0.6,
        ticks: {
          beginAtZero: true,
          fontSize: 11
        }
      }]
    },
    legend: {
      display: false
    },
    elements: {
      point: {
        radius: 0
      }
    }
  };
  barChartColors2 = [
    {
      borderColor: '#560bd0', //'#560bd0', 'rgba(0,123,255,.5)'
      backgroundColor: '#560bd0'
    }
  ];

  async fnSave() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }
    // console.log(JSON.stringify(this.form.value, null, 2));

    if (this._dept != this.dept_abb_name) {
      Swal.fire({
        icon: 'error',
        title: "",
        text: "Invalid department."
        // ไม่สามารถเพิ่มข้อมูลได้ เนื่องจากพนักงานไม่ได้อยู่ใน DEPARTMENT ของคุณ.
      })

      return;
    }

    if (!this.arr_band.some(x => x.band == this.txtband.nativeElement.value)) {
      Swal.fire({
        icon: 'error',
        title: "",
        text: "Unequal band."
        // ไม่สามารถเพิ่มข้อมูลได้ เนื่องจากพนักงานไม่อยู่ใน band ที่กำหนด.
      })

      return;
    }

    const send_data = {
      course_no: this.form.controls['frm_course'].value,
      emp_no: this.form.controls['frm_emp_no'].value,
      last_status: (this.data_grid.length + 1) > this.txtqty.nativeElement.value ? environment.text.wait : null,
      remark: this.txt_not_pass
    }
    // console.log(send_data);
    await this.service.axios_post('Registration', send_data, environment.text.success);
    await this.fnGet(this.form.controls['frm_course'].value, this.dept_abb_name);
  }
  fnApproved() {
    Swal.fire({
      text: 'Approve ?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes',
      cancelButtonText: 'No'
    }).then(async (result) => {
      if (result.value) {
        // if (this.array_grid.length > 0) {

        Array.prototype.push.apply(this.array_grid, this.data_grid); // console.log(this.array_grid);
        this.array_grid = removeDuplicateObjectFromArray(this.array_grid, 'emp_no'); // console.log(removeDuplicateObjectFromArray(this.array_grid, 'emp_no'));

        const send_data = {
          course_no: this.form.controls['frm_course'].value,
          capacity: this.txtqty.nativeElement.value,
          array: this.array_grid
        }
        console.log('send data: ', send_data);

        this.selection.clear();
        this.array_grid = [];
        await this.service.axios_put('/Registration/CenterApprove/' + this.form.controls['frm_course'].value, send_data, environment.text.success);
        await this.fnGet(this.form.controls['frm_course'].value, this.dept_abb_name);
        // }
      }
    })
  }


  fnClear() {
    this.form.controls['frm_emp_no'].setValue("");
    this.form.controls['frm_emp_name'].setValue("");
    this.txtdept.nativeElement.value = "";
    this.txtposition.nativeElement.value = "";
    this.txtband.nativeElement.value = "";
    this.txt_not_pass = "";
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
        await this.service.axios_delete('Registration/' + item.course_no + '/' + item.emp_no + '/' + this.txtqty.nativeElement.value, environment.text.delete);
        this.fnGet(item.course_no, this.dept_abb_name);
      }
    })
  }

  res_course: any = [];
  arr_band: any;
  async onKeyCourse(event: any) { // console.log(event.target.value);
    if (event.target.value.length >= 11 && event.target.value.length < 12) {
      this.res_course = await this.service.axios_get('CourseOpen/' + event.target.value);
      if (this.res_course != undefined) {
        this.form.controls['frm_course_name'].setValue(this.res_course.course_name_en);
        this.txtgroup.nativeElement.value = this.res_course.dept_abb_name;
        this.txtqty.nativeElement.value = this.res_course.capacity;
        this.v_capacity = this.res_course.capacity;
        this.txtdate_from.nativeElement.value = formatDate(this.res_course.date_start).toString() + ' ' + this.res_course.time_in;
        this.txtdate_to.nativeElement.value = formatDate(this.res_course.date_end).toString() + ' ' + this.res_course.time_out;

        this.arr_band = this.res_course.courses_bands; // console.log(this.arr_band);

        var nameArr = this.res_course.courses_bands; // console.log(nameArr);
        for (const iterator of nameArr) {
          this.array_chk.find(v => v.band === iterator.band).isChecked = true;
        } // console.log(this.array_chk);
        this.checkboxesDataList = this.array_chk;

        await this.fnGet(event.target.value, this.dept_abb_name);
      }
    } else if (event.target.value.length < 11) {
      this.form.controls['frm_course_name'].setValue("");
      this.txtgroup.nativeElement.value = "";
      this.txtqty.nativeElement.value = "";
      this.txtdate_from.nativeElement.value = "";
      this.txtdate_to.nativeElement.value = "";
      this.checkboxesDataList.forEach((value, index) => {
        value.isChecked = false;
      });
      this.fnClear();
    }
  }

  onKeyEmpno(event: any) {
    if (event.target.value.length >= 6 && event.target.value.length <= 7) {
      this.searchEmp(event.target.value);
      this.searchPrevCourse(event.target.value);
    } else if (event.target.value.length == 0) {
      this.fnClear();
    }
  }

  res_emp: any = [];
  _dept: any = '';
  async searchEmp(empno: any) {
    this.res_emp = await this.service.axios_get('Employees/' + empno); // console.log('searchEmp: ', this.res_emp);
    if (this.res_emp != null || this.res_emp != undefined) {
      this.form.controls['frm_emp_name'].setValue(this.res_emp.sname_eng + " " + this.res_emp.gname_eng + " " + this.res_emp.fname_eng);
      this._dept = this.res_emp.dept_abb_name;
      this.txtdept.nativeElement.value = this.res_emp.dept_code + ":" + this.res_emp.dept_abb_name;
      this.txtposition.nativeElement.value = this.res_emp.posn_ename;
      this.txtband.nativeElement.value = this.res_emp.band;
    } else {
      this.form.controls['frm_emp_name'].setValue("");
      this.txtdept.nativeElement.value = "";
      this.txtposition.nativeElement.value = "";
      this.txtband.nativeElement.value = "";
    }
  }
  res_prev: any;
  async searchPrevCourse(empno: any) {
    let frm = this.form.value;
    this.res_prev = await this.service.axios_get('Registration/GetPrevCourse/' + frm.frm_course + '/' + empno); // console.log('searchPrevCourse: ', this.res_prev);
    if (this.res_prev != "" || this.res_prev != null) {
      this.txt_not_pass = this.res_prev;
      this.not_pass = true;
    }
  }

  /** File Upload, Download */
  dowloadFormat() {
    const link = document.createElement('a');
    link.setAttribute('target', '_blank');
    link.setAttribute('href', 'assets/format/format input training.xlsx');
    link.setAttribute('download', `format input training.xlsx`);
    document.body.appendChild(link);
    link.click();
    link.remove();
  }
  nameFile: string = 'Choose file';
  file: any;
  fileName: any;
  chooseFile(e: any) {
    if (e.target.files && e.target.files[0]) {
      const file = e.target.files[0];
      const reader = new FileReader();
      reader.readAsDataURL(file);
      this.file = e.target.files[0];
      this.fileName = e.target.files[0].name;
      console.log(this.file);
      console.log(this.fileName);
      this.nameFile = this.fileName;
    }
  }
  result: any;
  async upload() {
    if (this.form.controls['frm_course'].value == "") {
      return;
    }

    let formData = new FormData();
    if (this.file !== undefined && this.file !== "" && this.file !== null) {
      formData.append('file_form', this.file)
      formData.append('file_name', this.fileName)
      formData.append('dept_abb_name', this.dept_abb_name)
      formData.append('capacity', this.txtqty.nativeElement.value)
    }

    this.result = await this.service.axios_formdata_post('/Registration/UploadCourseRegistration/' + this.form.controls['frm_course'].value, formData, environment.text.success);
    // console.log('result: ', this.result.data);
    if (this.result.data.length > 0) {
      let element = this.result.data;
      this.exportexcel.exportJSONToExcel(element, 'ResultRegistration');
    }

    this.nameFile = 'Choose file';
    await this.fnGet(this.form.controls['frm_course'].value, this.dept_abb_name);
  }
  /** End File Upload, Download */

  // Start Check box
  selection = new SelectionModel<DataTablesResponse>(true, []);
  array_grid = [];
  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.data_grid.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    if (this.isAllSelected()) {
      this.selection.clear();
      return;
    }

    this.selection.select(...this.data_grid);
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: DataTablesResponse): string {
    if (!row) {
      this.array_grid = this.selection.selected;

      return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.emp_no + 1}`;
  }

  toggleSelection(row) {
    if ((this.selection.selected.length < this.v_capacity) || this.selection.isSelected(row)) {
      this.selection.toggle(row);
    }

    this.array_grid = this.selection.selected;
    // console.log(this.array_grid);
  }
  // End Check box

  open(content) {
    if (this.form.controls['frm_course_name'].value != "") {
      this.modalService.open(content, {
        size: 'lg' //sm, mb, lg, xl
      });
    }
  } // Popup chart

  res_get: any;
  async fnGet(course_no, dept_abb_name) {
    this.res_get = await this.service.axios_get('Registration/GetGridView/' + course_no + '/' + dept_abb_name);
    // console.log('res_get: ', this.res_get);
    this.data_grid = this.res_get.your;

    this.v_regis = this.res_get.your.filter(x => x.last_status != environment.text.wait).length;
    this.v_wait = this.res_get.your.filter(x => x.last_status == environment.text.wait).length;
    this.v_total = this.res_get.your.length;

    let chk_true = this.res_get.your.filter(x => x.center_approved_checked == true);
    if (chk_true.length > 0) {
      this.selection = new SelectionModel<DataTablesResponse>(true, chk_true)
      // console.log("1", this.selection.selected);
    }
  }

  array_chk:any;
  async fnGetband() {
    this.array_chk = await this.service.axios_get('CourseMasters/GetBand'); //console.log(this.array_chk);
    this.array_chk.forEach(object => {
      object.isChecked = false;
    }); //console.log(this.array_chk);
    this.checkboxesDataList = this.array_chk; //console.log(this.checkboxesDataList);
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
function displayTime(ticksInSecs) {
  // console.log(ticksInSecs);
  var min = ticksInSecs.Minutes < 10 ? "0" + ticksInSecs.Minutes : ticksInSecs.Minutes;
  var sec = ticksInSecs.Seconds < 10 ? "0" + ticksInSecs.Seconds : ticksInSecs.Seconds;
  var hour = ticksInSecs.Hours < 10 ? "0" + ticksInSecs.Hours : ticksInSecs.Hours;
  // return hour + ':' + min + ':' + sec;
  return hour + ':' + min;
}
function removeDuplicateObjectFromArray(array, key) {
  return array.filter((obj, index, self) =>
    index === self.findIndex((el) => (
      el[key] === obj[key]
    ))
  )
}

class DataTablesResponse {
  band: string;
  center_approved_checked: boolean;
  course_name_en: string;
  course_no: string;
  dept_abb_name: string;
  dept_code: string;
  emp_no: string;
  fname_eng: string;
  gname_eng: string;
  last_status: string;
  manager_approved_checked: boolean;
  posn_code: string;
  posn_ename: string;
  remark: string;
  seq_no: number;
  sname_eng: string;
}

export interface PeriodicElement2 {
  emp_no: string;
  sname_eng: string;
  gname_eng: string;
  fname_eng: string;
  posn_ename: string;
  band: string;
  dept_code: string;
  dept_abb_name: string;
  last_status: string;
  remark: string;
  course_name_en: string;
}
const ELEMENT_DATA: PeriodicElement2[] = [
  {
    emp_no: '014748',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: '',
    remark: 'Not passed CPT-001',
    course_name_en: 'Basic Excel'
  }, {
    emp_no: '014749',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: 'Wait',
    remark: 'Not passed CPT-001',
    course_name_en: 'Basic Excel'
  }, {
    emp_no: '014748',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: '',
    remark: 'Not passed CPT-001',
    course_name_en: 'Basic Excel'
  }, {
    emp_no: '014749',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: 'Wait',
    remark: 'Not passed CPT-001',
    course_name_en: 'Basic Excel'
  }, {
    emp_no: '014748',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: '',
    remark: 'Not passed CPT-001',
    course_name_en: 'Basic Excel'
  }, {
    emp_no: '014749',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: 'Wait',
    remark: 'Not passed CPT-001',
    course_name_en: 'Basic Excel'
  }, {
    emp_no: '014750',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: '',
    remark: '',
    course_name_en: ''
  }, {
    emp_no: '014751',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: 'Wait',
    remark: '',
    course_name_en: ''
  }, {
    emp_no: '014752',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: '',
    remark: '',
    course_name_en: ''
  }, {
    emp_no: '014753',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: 'Wait',
    remark: '',
    course_name_en: ''
  }, {
    emp_no: '014754',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: 'Wait',
    remark: '',
    course_name_en: ''
  }, {
    emp_no: '014755',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: '',
    remark: '',
    course_name_en: ''
  }, {
    emp_no: '014756',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: 'Wait',
    remark: '',
    course_name_en: ''
  }, {
    emp_no: '014757',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: 'Wait',
    remark: '',
    course_name_en: ''
  }, {
    emp_no: '014758',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: '',
    remark: '',
    course_name_en: ''
  }, {
    emp_no: '014759',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: 'Wait',
    remark: '',
    course_name_en: ''
  }, {
    emp_no: '014760',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: 'Wait',
    remark: '',
    course_name_en: ''
  }, {
    emp_no: '014761',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: '',
    remark: '',
    course_name_en: ''
  }, {
    emp_no: '014762',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    last_status: 'Wait',
    remark: '',
    course_name_en: ''
  },
];
