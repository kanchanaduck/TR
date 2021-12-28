import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-course-map',
  templateUrl: './course-map.component.html',
  styleUrls: ['./course-map.component.scss']
})
export class CourseMapComponent implements OnInit {

  selectedTrainerMultiple: string[];
  variableTrainer: any = variableTrainer;

  constructor() { }

  ngOnInit(): void {
    this.selectedTrainerMultiple = ["014748", "014749", "014496"]
  }

}

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