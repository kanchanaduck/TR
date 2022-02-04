import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AppServiceService } from 'src/app/app-service.service';
import axios from 'axios';

@Component({
  selector: 'app-trainer-history',
  templateUrl: './trainer-history.component.html',
  styleUrls: ['./trainer-history.component.scss']
})
export class TrainerHistoryComponent implements OnInit {

  trainer_history: any = [];
  trainer_no: number;  
  trainer: any = {};
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

  constructor(
    private route: ActivatedRoute, 
    private service: AppServiceService, 
    private httpClient: HttpClient
  ) { }

  ngOnInit(): void {

    this.dtOptions = {
      dom: "<'row'<'col-sm-12 col-md-4'f><'col-sm-12 col-md-8'B>>" +
      "<'row'<'col-sm-12'tr>>" +
      "<'row'<'col-sm-12 col-md-4'i><'col-sm-12 col-md-8'p>>",
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
                {
                    text: '<i class="far fa-file-excel"></i> History</button>',
                    action: function ( e, dt, node, config ) {
                      //  alert('เอาไว้ดาวน์โหลดประวัติการสอนค่าาา')
                      location.href = `${environment.API_URL}Trainers/History`
                    }
                },
            ]
          },
        ],
      },
      order: [[0, 'asc']],
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
    };


    this.route.params.subscribe(params => {
      this.trainer_no = params['trainer_no'];
    });

    this.get_trainer()
    this.get_trainer_history()

  }


async get_trainer_history(){
  let self = this
  await this.httpClient.get(`${environment.API_URL}Trainers/History/${this.trainer_no}`, this.headers)
  .subscribe((response: any) => {
    self.trainer_history = response;
    self.trainer_history = self.trainer_history.courses_trainers;
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

async get_trainer() {
  let self =this
  await axios.get(`${environment.API_URL}Trainers/${this.trainer_no}`,this.headers)
  .then(function (response) {
    console.log(response)
    self.trainer = response
  }) 
  .catch(function (error) {
    console.log(error)
  }) 
}


}