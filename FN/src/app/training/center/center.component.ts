import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import { environment } from 'src/environments/environment';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-center',
  templateUrl: './center.component.html',
  styleUrls: ['./center.component.scss']
})
export class CenterComponent implements OnInit {

  center: any = {};
  errors: any;

  constructor() { }

  ngOnInit(): void {
    this.dtOptions = {
      "processing": true,
      ajax: {
        url: environment.API_URL+"Center",
        dataSrc: "",
      },
      columns:
      [
        { 
          "data": "center_no",
          "className": "text-center",
          "render": function ( data, type, row ) {
            return `<input type="checkbox" value=${data}>`
          },
        },
        { "data": "emp_no" },
        { "data": "sname_en" },
        { "data": "gname_en" },
        { "data": "fname_en" },
        { "data": "postion_ename" },
        { "data": "div_abb_name" },
        { "data": "dept_abb_name" },
        { "data": "employed_status" },
        { 
          "data": "center_no",
          "className": "text-center",
          "render": function ( data, type, row ) {
            return `<a href="javascript:;"><i class="far fa-trash-alt"></i></a>`
          },
        },
      ],
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
      order: [ [1, 'asc']],
      columnDefs: [ {
        targets: [ 0, 9 ],
        "orderable": false
      } ],

      container: "#example_wrapper .col-md-6:eq(0)",
      lengthMenu: [[10, 25, 50, 75, 100, -1], [10, 25, 50, 75, 100, "All"]],
    };

  }

  dtOptions: any = {};
  barChartData = [{
    label: '# of Votes',
    data: [12, 39, 20, 10, 55, 18],
  }];

  barChartColors = [
    {
      backgroundColor: '#560bd0'
    }
  ];

  barChartLabels = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'];

  barChartOptions = {
    scales: {
      yAxes: [{
        ticks: {
          beginAtZero: true,
          fontSize: 10,
          min:0,
          max: 80
        }
      }],
      xAxes: [{
        barPercentage: 0.6,
        ticks: {
          beginAtZero:true,
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



   async save_center() {  
    const instance = axios.create({
      baseURL: environment.API_URL,
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
        'Content-Type': 'application/json'
      }
    });
    await instance.post('Center',this.center)
    .then(function (response) {
      Swal.fire({
        toast: true,
        position: 'top-end',
        icon: 'success',
        title: "Success",
        showConfirmButton: false,
        timer: 2000
      })
    })
    .catch(function (error) {
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data
      })
      this.center = {};
    });
  }

  async delete_center() { 
    const instance = axios.create({
      baseURL: environment.API_URL,
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
        'Content-Type': 'application/json'
      }
    });
    const response = await instance.delete('Center',this.center);
  }

  async reset_form_center() { 
    this.center = {};
  }


  async fillEmpNo(event: any) { 
    if(this.center.emp_no.length>=6){
      this.get_employee()
    }
  }
   
   async get_employee() {
    try {
      const response = await axios.get(`${environment.API_URL}Employees/${this.center.emp_no}`);
      console.log(response);
      this.center = response
    } catch (error) {
      Swal.fire({
            icon: 'error',
            title: error.response.status,
            text: error.response.data
          })
          this.center = {};
      console.error(error);
    }
    /* axios.get(`${environment.API_URL}Employees/${this.center.emp_no}`)
    .then(function (response) {
        console.log(response)
        this.center = response
      }) 
    .catch(function (error) {
      console.log(error);
    }); */

      // await axios.get(`${environment.API_URL}Employees/${this.center.emp_no}`)
      // .then(function (response) {
      //   console.log(response)
      //   this.center = response
      // }) 
      // .catch(function (error) {
      //   console.log(error)
      //   // this.reset_form_center()
      //   /* Swal.fire({
      //     icon: 'error',
      //     title: error.response.status,
      //     text: error.response.data
      //   }) */
      // }) 
  }

}


