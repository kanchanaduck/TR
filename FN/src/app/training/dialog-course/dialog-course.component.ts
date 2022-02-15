import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { NgbActiveModal, NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { AppServiceService } from 'src/app/app-service.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-dialog-course',
  templateUrl: './dialog-course.component.html',
  styleUrls: ['./dialog-course.component.scss']
})
export class DialogCourseComponent implements OnInit {
  data_grid: any = [];
  // datatable
  dtOptions: any = {};
  dtTrigger: Subject<any> = new Subject();
  @ViewChild(DataTableDirective)
  dtElement: DataTableDirective;
  isDtInitialized: boolean = false
  // end datatable

  _ogr_code: string = "";
  _getjwt: any;
  _emp_no: any;

  @Output() newItemEvent = new EventEmitter<string>();

  constructor(private service: AppServiceService, public activeModal: NgbActiveModal) { 

  }

  ngOnInit(): void {
    this.dtOptions = {
      dom: "<'row'<'col-sm-12 col-md-4'f>>" +
        "<'row'<'col-sm-12'tr>>" +
        "<'row'<'col-sm-12 col-md-4'i><'col-sm-12 col-md-8'p>>",
      language: {
        paginate: {
          next: '<i class="icon ion-ios-arrow-forward"></i>', // or '→'
          previous: '<i class="icon ion-ios-arrow-back"></i>' // or '←' 
        }
      },
      container: "#example_wrapper .col-md-6:eq(0)",
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
    };

    this._getjwt = this.service.service_jwt();  // get jwt
    this._emp_no = this._getjwt.user.emp_no; // set emp_no
    this.fnGetStakeholder(this._emp_no);
  }

  onSelect(selectedItem: any) {
    // console.log("Selected item: ", selectedItem); // You get the Id of the selected item here
    this.newItemEvent.emit(selectedItem.course_no);
    // this.dialogRef.disableClose = true;
    //     this.dialogRef.close();

    // this.activeModal.dismiss();
    console.log(this.activeModal);
    
    // this.activeModal.close(true);
  }


  async fnGetStakeholder(emp_no: any) {
    await this.service.gethttp('Stakeholder/Employee/' + emp_no)
      .subscribe((response: any) => {
        console.log(response);
        if (response.role.toUpperCase() == environment.role.committee) {
          this._ogr_code = response.organization.org_code;
          this.fnGet(this._ogr_code);
        }
      }, (error: any) => {
        console.log(error);
        this.fnGet(this._ogr_code);
      });
  }

  async fnGet(_ogr_code: string) {

    await this.service.gethttp('CourseMasters/Org/' + _ogr_code)
      .subscribe((response: any) => {
        console.log('co: ', response);

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
