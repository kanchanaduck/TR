import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-training',
  templateUrl: './training.component.html',
  styleUrls: ['./training.component.scss']
})
export class TrainingComponent implements OnInit {
  // dtOptions: DataTables.Settings = {};
  dtOptions: any = {};
  training_menu: any = [];

  constructor() { }

  ngOnInit(): void {

    this.training_menu = [
          {
            "menu_code": "TR-01",
            "menu_name": "Maintenance",
            "parent_menu_code": "TR",
            "description": null,
            "url": null,
            "spare1": null,
            "spare2": null,
            "update_date": "2021-09-15T00:00:00",
            "update_by": "014496",
            "children": [
              {
                "menu_code": "TR-01-01",
                "menu_name": "Trainer management",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "trainer",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014496",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Stakeholder management",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "stakeholder",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014496",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Center management",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "center",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014496",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Master course control",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "course-master",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014496",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Need survey for center",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "survey-center",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014496",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Need survey for committee",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "survey",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014496",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Open course",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "course-open",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014748",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Committee register trainee",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "register",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014748",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Manager approve trainee",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "approve-mgr",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014748",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Center approve trainee",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "approve-center",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014748",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Register continuous employee no.",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "register-continuous",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014748",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Input score",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "course-score",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014748",
                "children": [
                ]
              }
            ]
          },
          {
            "menu_code": "TR-02",
            "menu_name": "Report",
            "parent_menu_code": "TR",
            "description": null,
            "url": null,
            "spare1": null,
            "spare2": null,
            "update_date": "2021-09-15T00:00:00",
            "update_by": "014496",
            "children": [
              {
                "menu_code": "TR-01-00",
                "menu_name": "Confirmation sheet",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "course-confirmation-sheet",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014748",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Signature sheet",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "course-signature-sheet",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014748",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Count trainee of course",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "trainee-count",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014748",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Course and trainees score",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "course-history",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014748",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Course map",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "course-map",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014496",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Employee training history",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "employee-course-history",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014748",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Course attendee",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "course-history",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014748",
                "children": [
                ]
              },
              {
                "menu_code": "TR-01-00",
                "menu_name": "Target group of course",
                "parent_menu_code": "TR-01",
                "description": null,
                "url": "course-target",
                "spare1": null,
                "spare2": null,
                "update_date": "2021-09-15T00:00:00",
                "update_by": "014748",
                "children": [
                ]
              }
            ]
          }
        ]


    
    // this.dtOptions = {
    //   pagingType: 'full_numbers',
    //   "dom": "<'row'<'col-sm-12 col-md-6'><'col-sm-12 col-md-6 text-right'B>>" +
    //   "<'row'<'col-sm-12 mt-1'tr>>" +
    //   "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
    //   // dom: 'Bfrtip',
    //   buttons: [
    //     /* {
    //       extend: 'copy',
    //       className: 'btn btn-outline-primary',
    //     },
    //     {
    //       extend: 'print',
    //       className: 'btn btn-outline-primary',
    //     },
    //     {
    //       extend: 'excel',
    //       className: 'btn btn-outline-primary',
    //     },
    //     {
    //       text: 'Some button',
    //       className: 'btn btn-outline-primary',
    //       key: '1',
    //       action: function (e, dt, node, config) {
    //         alert('Button activated');
    //       }
    //     }, */
    //     {
    //       text: '<i class="fas fa-plus"></i> Add</button>',
    //       className: 'btn btn-outline-primary btn-rounded',
    //       key: '1',
    //       action: function (e, dt, node, config) {
    //         alert('Button activated');
    //       }
    //     }
    //   ],
    // };
  }

}
