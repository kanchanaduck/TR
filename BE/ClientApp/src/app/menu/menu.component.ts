import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html'
})
export class MenuComponent {
  public menus: Menu[];

  // constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //   http.get<Menu[]>(baseUrl + 'api/menus').subscribe(result => {
  //     this.menus = result
  //     console.log( this.menus)
  //   }, error => console.error(error));
  // }
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    // .map((response: Response)
    http.get<Menu[]>(baseUrl + 'api/menus')
    .subscribe(result => {
      this.menus = result
    }, error => console.error(error));
  }
}

interface Menu {
  menu_code: string;
  menu_name: string;
  parent_menu_code: string;
  description: string;
  url: string;
  update_date: string;
  update_by: string;
}
