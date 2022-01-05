import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';


const routes: Routes = [
  { path: '', redirectTo: '/users', pathMatch: 'full' },
  { path: 'menus', loadChildren: () => import('./menus/menus.module').then(m => m.MenusModule) },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'general-pages', loadChildren: () => import('./general-pages/general-pages.module').then(m => m.GeneralPagesModule) },
  { path: 'ui-elements', loadChildren: () => import('./ui-elements/ui-elements.module').then(m => m.UiElementsModule) },
  { path: 'form', loadChildren: () => import('./form/form.module').then(m => m.FormModule) },
  { path: 'charts', loadChildren: () => import('./charts/charts.module').then(m => m.ChartsDemoModule) },
  { path: 'tables', loadChildren: () => import('./tables/tables.module').then(m => m.TablesModule) },
  { path: 'welfare', loadChildren: () => import('./welfare/welfare.module').then(m => m.WelfareModule) },
  { path: 'users', loadChildren: () => import('./users/users.module').then(m => m.UsersModule), data: { title: 'User', active: true }  },
  { path: 'employee', loadChildren: () => import('./employee/employee.module').then(m => m.EmployeeModule), data: { title: 'Employee', active: false } },
  { path: 'training', loadChildren: () => import('./training/training.module').then(m => m.TrainingModule), data: { title: 'Training', active: true } },
  { path: '**', redirectTo: 'general-pages/page-404' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
