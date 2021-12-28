import { Component, OnInit } from '@angular/core';
import axios from 'axios';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  menus: any=[];

  constructor() { }

  ngOnInit() {

    axios.get('/assets/menus.json').then(response => (
      this.menus = response.data
    ));
  }

  closeMenu(e) {
    e.target.closest('.dropdown').classList.remove('show');
    e.target.closest('.dropdown .dropdown-menu').classList.remove('show');
  }

  toggleHeaderMenu(event) {
    event.preventDefault();
    alert(event)
    document.querySelector('body').classList.toggle('az-header-menu-hide');
  }

  toggleSidebar(event) {
    event.preventDefault();
    if(window.matchMedia('(min-width: 992px)').matches) {
      document.querySelector('body').classList.toggle('az-sidebar-hide');
    }
    else{
      document.querySelector('body').classList.toggle('az-sidebar-show');
    }
    // document.querySelector('.az-sidebar').classList.toggle('d-flex');

  }

}
