import { Component, OnInit, ViewChild } from '@angular/core';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-course-master',
  templateUrl: './course-master.component.html',
  styleUrls: ['./course-master.component.scss']
})
export class CourseMasterComponent implements OnInit {
  data_grid: any = [];
  dtOptions: any = {};
  // dtOptions: DataTables.Settings = {};

  str_create: string = 'create';
  str_edit: string = 'edit';
  m_title: string = '';
  
  @ViewChild("content") id_content: any;
  @ViewChild("inputCourseNo") inputCourseNo: any;
  @ViewChild("inputThaName") inputThaName: any;
  @ViewChild("inputEngName") inputEngName: any;
  @ViewChild("inputDay") inputDay: any;

  constructor(private modalService: NgbModal, config: NgbModalConfig) {
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
      filter:{
        "dom":{
          "container": {
            tag: "div",
            className: "dt-buttons btn-group flex-wrap float-left"
          },
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
            className: "btn btn-outline-indigo"
          },
        },
        "buttons": [
          {
            extend:'pageLength',
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
            text: '<i class="fas fa-plus"></i> New</button>',
            key: '1',
            action: () => {
              this.open(this.id_content, this.str_create);
            }
          }
        ],
      },
      rowGroup: {
        dataSrc: [ 5 ]
      },


      container: "#example_wrapper .col-md-6:eq(0)",
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
    };

    // l - Length changing
    // f - Filtering input
    // t - The Table!
    // i - Information
    // p - Pagination
    // r - pRocessing
    // < and > - div elements
    // <"#id" and > - div with an id
    // <"class" and > - div with a class
    // <"#id.class" and > - div with an id and class
  }

  open(content, action) {
    if (action == this.str_create) {
      this.m_title = 'Create Data';
    } else {
      this.m_title = 'Edit Data';
    }

    this.modalService.open(content, {
      size: 'mb' //sm, mb, lg
    });
  }

  fn_edit(item) {
    console.log('fn_edit', item);
    this.open(this.id_content, this.str_edit);
  }


  // Start Check box
  selection = new SelectionModel<PeriodicElement>(true, []);
  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.data_grid.length;
    return numSelected === numRows;
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

export interface PeriodicElement {
  course_no: string;
  course_name_th: string;
  course_name_en: string;
  days: number;
  category: string;
  dept_abb_name: string;
  status: number;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    course_no: 'CPT-001',
    course_name_th: 'ความรู้พื้นฐานในการ...',
    course_name_en: 'QC BASIC',
    category: "QC",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-002',
    course_name_th: 'เอ็กเซลพื้นฐาน',
    course_name_en: 'Basic Excel',
    days: 4,
    category: "QC",
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-003',
    course_name_th: 'เอ็กเซลขั้นสูง',
    course_name_en: 'Advanced Excel',
    days: 4,
    category: "QC",
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-004',
    course_name_th: 'มาโคร',
    course_name_en: 'Macro',
    days: 2,
    category: "QC",
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-005',
    course_name_th: 'ความรู้พื้นฐานในกา…',
    course_name_en: 'QC BASIC2',
    days: 1,
    category: "QC",
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-001',
    course_name_th: 'ความรู้พื้นฐานในการ...',
    course_name_en: 'QC BASIC',
    category: "QC",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-002',
    course_name_th: 'เอ็กเซลพื้นฐาน',
    course_name_en: 'Basic Excel',
    category: "QC",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-003',
    course_name_th: 'เอ็กเซลขั้นสูง',
    course_name_en: 'Advanced Excel',
    category: "QC",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-004',
    course_name_th: 'มาโคร',
    course_name_en: 'Macro',
    category: "QC",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-005',
    course_name_th: 'ความรู้พื้นฐานในกา…',
    course_name_en: 'QC BASIC2',
    category: "QC",
    days: 1,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-001',
    course_name_th: 'ความรู้พื้นฐานในการ...',
    course_name_en: 'QC BASIC',
    category: "QC",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-002',
    course_name_th: 'เอ็กเซลพื้นฐาน',
    course_name_en: 'Basic Excel',
    category: "QC",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-003',
    course_name_th: 'เอ็กเซลขั้นสูง',
    course_name_en: 'Advanced Excel',
    category: "QC",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-004',
    course_name_th: 'มาโคร',
    course_name_en: 'Macro',
    category: "QC",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-005',
    course_name_th: 'ความรู้พื้นฐานในกา…',
    course_name_en: 'QC BASIC2',
    category: "QC",
    days: 1,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-001',
    course_name_th: 'ความรู้พื้นฐานในการ...',
    course_name_en: 'QC BASIC',
    category: "QC",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-002',
    course_name_th: 'เอ็กเซลพื้นฐาน',
    course_name_en: 'Basic Excel',
    category: "QC",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-003',
    course_name_th: 'เอ็กเซลขั้นสูง',
    course_name_en: 'Advanced Excel',
    category: "QC",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-004',
    course_name_th: 'มาโคร',
    course_name_en: 'Macro',
    category: "QC",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-005',
    course_name_th: 'ความรู้พื้นฐานในกา…',
    course_name_en: 'QC BASIC2',
    category: "QC",
    days: 1,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-001',
    course_name_th: 'ความรู้พื้นฐานในการ...',
    course_name_en: 'QC BASIC',
    category: "QC",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-002',
    course_name_th: 'เอ็กเซลพื้นฐาน',
    course_name_en: 'Basic Excel',
    category: "QC",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-003',
    course_name_th: 'เอ็กเซลขั้นสูง',
    course_name_en: 'Advanced Excel',
    category: "QC",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-004',
    course_name_th: 'มาโคร',
    course_name_en: 'Macro',
    category: "QC",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-005',
    course_name_th: 'ความรู้พื้นฐานในกา…',
    course_name_en: 'QC BASIC2',
    category: "QC",
    days: 1,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-001',
    course_name_th: 'ความรู้พื้นฐานในการ...',
    course_name_en: 'QC BASIC',
    category: "QC",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-002',
    course_name_th: 'เอ็กเซลพื้นฐาน',
    course_name_en: 'Basic Excel',
    category: "QC",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-003',
    course_name_th: 'เอ็กเซลขั้นสูง',
    course_name_en: 'Advanced Excel',
    category: "QC",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-004',
    course_name_th: 'มาโคร',
    course_name_en: 'Macro',
    category: "QC",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-005',
    course_name_th: 'ความรู้พื้นฐานในกา…',
    course_name_en: 'QC BASIC2',
    category: "QC",
    days: 1,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-001',
    course_name_th: 'ความรู้พื้นฐานในการ...',
    course_name_en: 'QC BASIC',
    category: "QC",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-002',
    course_name_th: 'เอ็กเซลพื้นฐาน',
    course_name_en: 'Basic Excel',
    category: "QC",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-003',
    course_name_th: 'เอ็กเซลขั้นสูง',
    course_name_en: 'Advanced Excel',
    category: "QC",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-004',
    course_name_th: 'มาโคร',
    course_name_en: 'Macro',
    category: "QC",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-005',
    course_name_th: 'ความรู้พื้นฐานในกา…',
    course_name_en: 'QC BASIC2',
    category: "QC",
    days: 1,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-001',
    course_name_th: 'ความรู้พื้นฐานในการ...',
    course_name_en: 'QC BASIC',
    category: "QC",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-002',
    course_name_th: 'เอ็กเซลพื้นฐาน',
    course_name_en: 'Basic Excel',
    category: "QC",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-003',
    course_name_th: 'เอ็กเซลขั้นสูง',
    course_name_en: 'Advanced Excel',
    category: "QC",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-004',
    course_name_th: 'มาโคร',
    course_name_en: 'Macro',
    category: "QC",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-005',
    course_name_th: 'ความรู้พื้นฐานในกา…',
    course_name_en: 'QC BASIC2',
    category: "QC",
    days: 1,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-001',
    course_name_th: 'ความรู้พื้นฐานในการ...',
    course_name_en: 'QC BASIC',
    category: "QC",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-002',
    course_name_th: 'เอ็กเซลพื้นฐาน',
    course_name_en: 'Basic Excel',
    category: "Microsoft office",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-003',
    course_name_th: 'เอ็กเซลขั้นสูง',
    course_name_en: 'Advanced Excel',
    category: "Microsoft office",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-004',
    course_name_th: 'มาโคร',
    course_name_en: 'Macro',
    category: "Microsoft office",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-005',
    course_name_th: 'ความรู้พื้นฐานในกา…',
    course_name_en: 'QC BASIC2',
    category: "Microsoft office",
    days: 1,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-001',
    course_name_th: 'ความรู้พื้นฐานในการ...',
    course_name_en: 'QC BASIC',
    category: "Microsoft office",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-002',
    course_name_th: 'เอ็กเซลพื้นฐาน',
    course_name_en: 'Basic Excel',
    category: "Microsoft office",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-003',
    course_name_th: 'เอ็กเซลขั้นสูง',
    course_name_en: 'Advanced Excel',
    category: "Microsoft office",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-004',
    course_name_th: 'มาโคร',
    course_name_en: 'Macro',
    category: "Microsoft office",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-005',
    course_name_th: 'ความรู้พื้นฐานในกา…',
    course_name_en: 'QC BASIC2',
    category: "Microsoft office",
    days: 1,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-001',
    course_name_th: 'ความรู้พื้นฐานในการ...',
    course_name_en: 'QC BASIC',
    category: "Microsoft office",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-002',
    course_name_th: 'เอ็กเซลพื้นฐาน',
    course_name_en: 'Basic Excel',
    category: "Microsoft office",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-003',
    course_name_th: 'เอ็กเซลขั้นสูง',
    course_name_en: 'Advanced Excel',
    category: "Microsoft office",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-004',
    course_name_th: 'มาโคร',
    course_name_en: 'Macro',
    category: "Microsoft office",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-005',
    course_name_th: 'ความรู้พื้นฐานในกา…',
    course_name_en: 'QC BASIC2',
    category: "Microsoft office",
    days: 1,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-001',
    course_name_th: 'ความรู้พื้นฐานในการ...',
    course_name_en: 'QC BASIC',
    category: "Microsoft office",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-002',
    course_name_th: 'เอ็กเซลพื้นฐาน',
    course_name_en: 'Basic Excel',
    category: "Microsoft office",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-003',
    course_name_th: 'เอ็กเซลขั้นสูง',
    course_name_en: 'Advanced Excel',
    category: "Microsoft office",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-004',
    course_name_th: 'มาโคร',
    course_name_en: 'Macro',
    category: "Microsoft office",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-005',
    course_name_th: 'ความรู้พื้นฐานในกา…',
    course_name_en: 'QC BASIC2',
    days: 1,
    category: "Microsoft office",
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-001',
    course_name_th: 'ความรู้พื้นฐานในการ...',
    course_name_en: 'QC BASIC',
    category: "Microsoft office",
    days: 2,
    dept_abb_name: 'MPL',
    status: 1,
  }, {
    course_no: 'CPT-002',
    course_name_th: 'เอ็กเซลพื้นฐาน',
    course_name_en: 'Basic Excel',
    category: "Microsoft office",
    days: 4,
    dept_abb_name: 'MPL',
    status: 1,
  }, 
 
];