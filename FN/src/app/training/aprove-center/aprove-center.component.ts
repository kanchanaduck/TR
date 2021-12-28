import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { SelectionModel } from '@angular/cdk/collections';
import axios from 'axios';
import Swal from 'sweetalert2';
import { AbstractControl, FormBuilder, FormControl, FormGroup, RequiredValidator, Validators } from '@angular/forms';

@Component({
  selector: 'app-aprove-center',
  templateUrl: './aprove-center.component.html',
  styleUrls: ['./aprove-center.component.scss']
})
export class AproveCenterComponent implements OnInit {
  data_grid: any = [];
  dtOptions: any = {};
  // dtOptions: DataTables.Settings = {};

  @ViewChild("txtcourse_name") txtcourse_name: any;
  @ViewChild("txtgroup") txtgroup: any;
  @ViewChild("txtqty") txtqty: any;
  @ViewChild("txtdate_from") txtdate_from: any;
  @ViewChild("txtdate_to") txtdate_to: any;
  @ViewChild("txtfull_name") txtfull_name: any;
  @ViewChild("txtposition") txtposition: any;
  @ViewChild("txtband") txtband: any;
  @ViewChild("txtdept") txtdept: any;
  ck_e: boolean = false;
  ck_j1: boolean = false;
  ck_j2: boolean = false;
  ck_j3: boolean = false;
  ck_j4: boolean = false;
  ck_m1: boolean = false;
  ck_m2: boolean = false;

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
            split: ['csv', 'pdf', 'excel'],
          }, {
            text: '<i class="fas fa-check"></i> Approve</button>',
            key: '1',
            action: () => {

            }
          }
        ],
      },
      container: "#example_wrapper .col-md-6:eq(0)",
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
    };

    this.form = this.formBuilder.group(
      {
        frm_course: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(20)]],
        frm_emp_no: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(7)]],
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
      this.txtcourse_name.nativeElement.value = "Basic Excel";
      this.txtgroup.nativeElement.value = "MTP";
      this.txtqty.nativeElement.value = "10";
      this.txtdate_from.nativeElement.value = "2021-12-03";
      this.txtdate_to.nativeElement.value = "2021-12-03";
      this.ck_e = true;
      this.ck_j1 = true;
      this.ck_j2 = true;
      this.ck_j3 = true;
      this.ck_j4 = true;
    } else {
      this.txtcourse_name.nativeElement.value = "";
      this.txtgroup.nativeElement.value = "";
      this.txtqty.nativeElement.value = "";
      this.txtdate_from.nativeElement.value = "";
      this.txtdate_to.nativeElement.value = "";
      this.ck_e = false;
      this.ck_j1 = false;
      this.ck_j2 = false;
      this.ck_j3 = false;
      this.ck_j4 = false;
      this.ck_m1 = false;
      this.ck_m2 = false;
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

  open(content){
    this.modalService.open(content, {
      size: 'lg' //sm, mb, lg
    });
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

    this.selection.select(...this.data_grid);
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: PeriodicElement): string {
    if (!row) {
      return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.emp_no + 1}`;
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

export interface PeriodicElement {
  emp_no: string;
  sname_eng: string;
  gname_eng: string;
  fname_eng: string;
  posn_ename: string;
  band: string;
  dept_code: string;
  dept_abb_name: string;
  status: string;
  remark: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    emp_no: '014748',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    status: '',
    remark: 'CPT-001-001',
  }, {
    emp_no: '014749',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    status: 'Wait',
    remark: 'CPT-001-001',
  }, {
    emp_no: '014748',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    status: '',
    remark: '',
  }, {
    emp_no: '014749',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    status: 'Wait',
    remark: '',
  }, {
    emp_no: '014748',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    status: '',
    remark: '',
  }, {
    emp_no: '014749',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    status: 'Wait',
    remark: '',
  }, {
    emp_no: '014749',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    status: 'Wait',
    remark: '',
  }, {
    emp_no: '014748',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    status: '',
    remark: '',
  }, {
    emp_no: '014749',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    status: 'Wait',
    remark: '',
  }, {
    emp_no: '014749',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    status: 'Wait',
    remark: '',
  }, {
    emp_no: '014748',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    status: '',
    remark: '',
  }, {
    emp_no: '014749',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    status: 'Wait',
    remark: '',
  }, {
    emp_no: '014749',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    status: 'Wait',
    remark: '',
  }, {
    emp_no: '014748',
    sname_eng: 'MISS',
    gname_eng: 'NUTTAYA',
    fname_eng: 'KALLA',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    status: '',
    remark: '',
  }, {
    emp_no: '014749',
    sname_eng: 'MR.',
    gname_eng: 'NATIRUT',
    fname_eng: 'DAUNGPAK',
    posn_ename: 'PROGRAMMER',
    band: 'J2',
    dept_code: '2230',
    dept_abb_name: 'ICD',
    status: 'Wait',
    remark: '',
  },
];

