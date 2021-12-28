import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import axios from 'axios';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SidebarComponent implements OnInit {

  menus: any=[];

  constructor() { }

  ngOnInit() {

    axios.get('assets/menus.json').then(response => (
      this.menus = response.data
    ));
  }

}
