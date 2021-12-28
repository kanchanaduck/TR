import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { SelectionModel } from '@angular/cdk/collections';
import axios from 'axios';
import Swal from 'sweetalert2';
import { AbstractControl, FormBuilder, FormControl, FormGroup, NgForm, RequiredValidator, Validators } from '@angular/forms';

@Component({
  selector: 'app-course-open',
  templateUrl: './course-open.component.html',
  styleUrls: ['./course-open.component.scss']
})
export class CourseOpenComponent implements OnInit {
  switch1 = false;

  data_grid: any = [];
  dtOptions: any = {};

  @ViewChild("txtgroup") txtgroup;
  @ViewChild("txtdate_from") txtdate_from;
  @ViewChild("txtdate_to") txtdate_to;
  ck_allow: boolean = false;
  ck_e: boolean = false;
  ck_j1: boolean = false;
  ck_j2: boolean = false;
  ck_j3: boolean = false;
  ck_j4: boolean = false;
  ck_m1: boolean = false;
  ck_m2: boolean = false;
  ddl_hh: any = [];
  ddl_mm: any = [];

  form: FormGroup;
  submitted = false;

  variableTrainer: any = variableTrainer;
  selectedPersonId = '';
  selectedTrainerMultiple: string[];

  today: any = Date.now();

  constructor(private modalService: NgbModal, config: NgbModalConfig, private formBuilder: FormBuilder) {
    config.backdrop = 'static';
    config.keyboard = false;
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
            className: "btn btn-outline-indigo"
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
        ],
      },
      container: "#example_wrapper .col-md-6:eq(0)",
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
    };

    this.form = this.formBuilder.group(
      {
        frm_course: ['', [Validators.required, Validators.minLength(7), Validators.maxLength(20)]],
        frm_course_th: ['', [Validators.required]],
        frm_course_en: ['', [Validators.required]],
        frm_day: ['', [Validators.required]],
        frm_qty: ['', [Validators.required]],
        frm_time_in_hh: ['', [Validators.required]],
        frm_time_in_mm: ['', [Validators.required]],
        frm_time_out_hh: ['', [Validators.required]],
        frm_time_out_mm: ['', [Validators.required]],
        frm_place: ['', [Validators.required]],
        frm_trainer: ['', [Validators.required]],
      },
    );

    for (var i = 0; i <= 23; i++) {
      let theOption: any = {};
      theOption.name = ("0" + i).slice(-2).toString();
      theOption.value = i.toString();
      this.ddl_hh.push(theOption);
    }
    for (var i = 0; i <= 55; i++) {
      let theOption: any = {};
      theOption.name = ("0" + (i)).slice(-2).toString();
      theOption.value = i.toString();
      this.ddl_mm.push(theOption);
      i = i + 4;
    }
  }
  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }

  ngAfterViewInit() {
    this.txtgroup.nativeElement.value = "ICD";
    this.txtdate_to.nativeElement.value = formatDate(this.today).toString();
    this.txtdate_from.nativeElement.value = formatDate(this.today).toString();
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
    this.form.controls['frm_course'].setValue("");
    this.form.controls['frm_course_th'].setValue("");
    this.form.controls['frm_course_en'].setValue("");
    this.form.controls['frm_day'].setValue("");
    this.form.controls['frm_qty'].setValue("");
    this.txtgroup.nativeElement.value = "";
    this.txtdate_to.nativeElement.value = formatDate(this.today).toString();
    this.txtdate_from.nativeElement.value = formatDate(this.today).toString();
    this.form.controls['frm_time_in_hh'].setValue("");
    this.form.controls['frm_time_in_mm'].setValue("");
    this.form.controls['frm_time_out_hh'].setValue("");
    this.form.controls['frm_time_out_mm'].setValue("");
    this.form.controls['frm_place'].setValue("");
    this.form.controls['frm_trainer'].setValue("");
    this.ck_allow = false;
    this.ck_e = false;
    this.ck_j1 = false;
    this.ck_j2 = false;
    this.ck_j3 = false;
    this.ck_j4 = false;
  }

  fn_edit(item) {
    console.log('fn_edit', item);
    this.form.controls['frm_course'].setValue(item.course_no);
    this.form.controls['frm_course_th'].setValue(item.course_name_tha);
    this.form.controls['frm_course_en'].setValue(item.course_name_en);
    this.form.controls['frm_day'].setValue(item.qty);
    this.form.controls['frm_qty'].setValue(item.day);
    this.txtgroup.nativeElement.value = item.dept_abb_name;
    this.txtdate_from.nativeElement.value = item.start_date;
    this.txtdate_to.nativeElement.value = item.end_date;
    this.form.controls['frm_place'].setValue(item.place);

    this.ck_allow = item.allow_register;
    this.ck_e = true;
    this.ck_j1 = true;
    this.ck_j2 = true;
    this.ck_j3 = true;
    this.ck_j4 = true;

    // console.log('fn_edit', item.time_in.substr(0, 2));
    // console.log('fn_edit', item.time_in.substr(item.time_in.length - 2));
    // console.log('fn_edit', item.time_out.substr(0, 2));
    // console.log('fn_edit', item.time_out.substr(item.time_out.length - 2));
    this.form.controls['frm_time_in_hh'].setValue(parseInt(item.time_in.substr(0, 2)).toString());
    this.form.controls['frm_time_in_mm'].setValue(parseInt(item.time_in.substr(item.time_in.length - 2)).toString());
    this.form.controls['frm_time_out_hh'].setValue(parseInt(item.time_out.substr(0, 2)).toString());
    this.form.controls['frm_time_out_mm'].setValue(parseInt(item.time_out.substr(item.time_out.length - 2)).toString());
    
    let array = [];
    for (const iterator of item.trainer) {
      // console.log('iterator: ', iterator);
      var newArray = variableTrainer.filter(function (el) {
        return el.name == iterator;
      });
      array.push(newArray[0].emp_no);
    }
    // console.log('array: ',array);
    this.selectedTrainerMultiple = array;
    // this.selectedTrainerMultiple = ["014748","013380"];
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
  startsWithSearchFn(item, term) {
    return item.startsWith(term);
  }

  open(content) {
    this.modalService.open(content, {
      size: 'mb' //sm, mb, lg
    });
  }

  onKeyCourse(event: any) { // console.log(event.target.value);
    if (event.target.value.length >= 7) {
      this.form.controls['frm_course_th'].setValue("ความรู้พื้นฐานในกา…");
      this.form.controls['frm_course_en'].setValue("QC BASIC");
      this.form.controls['frm_day'].setValue("2");
      this.form.controls['frm_qty'].setValue("10");
      this.txtgroup.nativeElement.value = "MTP";
      this.txtdate_from.nativeElement.value = "2021-12-03";
      this.txtdate_to.nativeElement.value = "2021-12-03";
    } else if (event.target.value.length == 0) {
      this.form.controls['frm_course_th'].setValue("");
      this.form.controls['frm_course_en'].setValue("");
      this.form.controls['frm_day'].setValue("");
      this.form.controls['frm_qty'].setValue("");
      this.txtgroup.nativeElement.value = "";
      this.txtdate_from.nativeElement.value = "";
      this.txtdate_to.nativeElement.value = "";
    }
  }
  onDateSelectTo(event) {
    console.log('onDateSelectTo: ', event);
  }
  onDateSelectFrom(event) {
    console.log('onDateSelectFrom: ', event);
  }

  // Start Check box
  selection = new SelectionModel<PeriodicElement>(true, []);
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

  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: PeriodicElement): string {
    if (!row) {
      return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.course_no + 1}`;
  }

  checkCheckBoxvalue(data, event) {
    console.log('check box: ', data);
    if (event.checked == true || event.checked2 == true) {
      // this.checkedIDs.push(data.id);
      // this.part_dupp.push(data.dupp_part);
    }
    else {
      // this.checkedIDs.splice(this.checkedIDs.indexOf(data.id), 1)
      // this.part_dupp.splice(this.part_dupp.indexOf(data.dupp_part), 1)
    }
  }
  // End Check box

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

export interface PeriodicElement {
  course_no: string;
  course_name_tha: string;
  course_name_en: string;
  dept_abb_name: string;
  qty: number;
  day: number;
  allow_register: boolean;
  band: string[];
  start_date: string;
  end_date: string;
  time_in: string;
  time_out: string;
  place: string;
  trainer: string[];
  previous_course: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    course_no: 'CPT-001-001',
    course_name_tha: 'ความรู้พื้นฐานในกา…',
    course_name_en: 'QC BASIC',
    dept_abb_name: 'MTP',
    qty: 10,
    day: 2,
    allow_register: true,
    band: ["E", "J1", "J2", "J3", "J4"],
    start_date: '2021-11-01',
    end_date: '2021-11-01',
    time_in: '09:00',
    time_out: '16:55',
    place: 'VIP RM.',
    trainer: ["NUCHCHANAT S.", "KANCHANA S."],
    previous_course: '',
  }, {
    course_no: 'CPT-001-002',
    course_name_tha: 'ความรู้พื้นฐานในกา…',
    course_name_en: 'QC BASIC',
    dept_abb_name: 'MTP',
    qty: 15,
    day: 2,
    allow_register: false,
    band: ["E", "J1", "J2", "J3", "J4"],
    start_date: '2021-11-05',
    end_date: '2021-11-05',
    time_in: '09:00',
    time_out: '16:50',
    place: 'VIP RM.',
    trainer: ["CHINTANA C."],
    previous_course: '',
  }
];

const variableTrainer = [
  {
    id: 1,
    'emp_no': '013364',
    'name': 'NUCHCHANAT S.'
  }, {
    id: 2,
    'emp_no': '014748',
    'name': 'NUTTAYA K.'
  }, {
    id: 3,
    'emp_no': '014749',
    'name': 'NATIRUT D.'
  }, {
    id: 4,
    'emp_no': '014205',
    'name': 'KHETCHANA K.'
  }, {
    id: 5,
    'emp_no': '013380',
    'name': 'CHINTANA C.'
  }, {
    id: 6,
    'emp_no': '014496',
    'name': 'KANCHANA S.'
  }
]