import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import axios from 'axios';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SidebarComponent implements OnInit {

  menus: any=[];
  activeUrl: any=[];

  constructor(
    private router: Router ,
    private route: ActivatedRoute,) {
   }

  ngOnInit() {
    this.activeUrl = this.route

    axios.get('assets/menus.json').then(response => (
      this.menus = response.data
    ));
  }

}
