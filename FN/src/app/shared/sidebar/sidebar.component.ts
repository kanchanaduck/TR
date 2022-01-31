import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import axios from 'axios';
import { ActivatedRoute, Router } from '@angular/router';
import { AppServiceService } from '../../app-service.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SidebarComponent implements OnInit {

  menus: any=[];
  _data: any;
  _fullname: any;
  _positions: any;
  img_garoon: any = environment.img_garoon;
  images: any;
  activeUrl: any;

  constructor(private service: AppServiceService, private router: Router, private route: ActivatedRoute) { }

  async ngOnInit() {

    this.activeUrl = this.route

    await axios.get(`${environment.API_URL}Menus`).then(response => (
      this.menus = response
      // console.log(response)
    ));

    console.log(this.menus)

    this._data = await this.service.service_jwt(); //console.log(this._data);
    this._fullname = this._data.user.gname_eng + ' ' + this._data.user.fname_eng.substring(0, 1);
    this._positions = this._data.user.posn_ename;
    this.images = `${this.img_garoon}${this._data.user.emp_no}.jpg`;
  }

}
