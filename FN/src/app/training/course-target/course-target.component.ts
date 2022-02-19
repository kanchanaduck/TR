import { Component, OnInit, ViewChild } from '@angular/core';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { AppServiceService } from 'src/app/app-service.service';

@Component({
  selector: 'app-course-target',
  templateUrl: './course-target.component.html',
  styleUrls: ['./course-target.component.scss']
})
export class CourseTargetComponent implements OnInit {
  data_grid: any = [];
  // datatable
  dtOptions: any = {};
  dtTrigger: Subject<any> = new Subject();
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  isDtInitialized: boolean = false
  // end datatable

  constructor(private service: AppServiceService) { }

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

    this.fnGet("NULL");
  }

  async onKeyCourse(event: any) {
    if (event.target.value.length >= 3 && event.target.value.length < 15) {
      this.fnGet(event.target.value);
    }else if(event.target.value.length == 0){
      this.fnGet("NULL");
    }
  }

  async fnGet(course_no:string) {
    await this.service.gethttp('OtherData/GetCountAttendee?course_no=' + course_no)
      .subscribe((response: any) => {
        console.log(response);

        this.data_grid = response;

        // Calling the DT trigger to manually render the table
        if (this.isDtInitialized) {
          this.dtElement.dtInstance.then((dtInstance: DataTables.Api) => {
            dtInstance.destroy();
            this.dtTrigger.next();
          });
        } else {
          this.isDtInitialized = true
          this.dtTrigger.next();
        }
      }, (error: any) => {
        console.log(error);
        this.data_grid = [];
      });
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }
}

export interface PeriodicElement {
  emp_no: string;
  status_eng: string;
  firstname_en: string;
  lastname_en: string;
  posn_name: string;
  dept_abb: string;
  div_abb: string;
  status_th: string;
  gname_th: string;
  fname_th: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    emp_no: '014748',
    status_eng: 'MISS',
    firstname_en: 'NUTTAYA',
    lastname_en: 'KALLA',
    posn_name: 'PROGRAMMER',
    dept_abb: 'ICD',
    div_abb: 'CPD',
    status_th: 'นางสาว',
    gname_th: 'นุตยา',
    fname_th: 'กัลลา',
  },{
    emp_no: '014205',
    status_eng: 'MR.',
    firstname_en: 'KHETCHANA',
    lastname_en: 'KETSAUAONG',
    posn_name: 'TECHNICIAN',
    dept_abb: 'ICD',
    div_abb: 'CPD',
    status_th: 'นาย',
    gname_th: 'เขตชนะ',
    fname_th: 'เกษสาวงค์',
  },
];
