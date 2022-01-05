import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenusComponent } from './menus/menus.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../shared/shared.module';

const routes: Routes = [
  { path: '', component: MenusComponent },
  /* { path: 'approve-mgr', component: ApproveMgrComponent, data: { title: 'Mgr. approve trainee', active: true } }, */
]

@NgModule({
  declarations: [
    MenusComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes),
  ]
})
export class MenusModule { }
