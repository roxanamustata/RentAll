import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';



import { RouterModule } from '@angular/router';
import {MatIconModule} from '@angular/material/icon';

import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import { MatInputModule, MatPaginatorModule, MatProgressSpinnerModule, 
  MatSortModule, MatTableModule } from "@angular/material";





import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home/home.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CenterComponent } from './centers/center/center.component';
import { UnitComponent } from './centers/unit/unit.component';
import { LeaseComponent } from './leases/lease/lease.component';
import { TenantComponent } from './tenants/tenant/tenant.component';
import { ReportComponent } from './reports/report/report.component';
import { LeaseViewComponent } from './leases/lease-view/lease-view.component';
import {MatDialogModule} from '@angular/material/dialog';





@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
   
    CenterComponent,
    LeaseComponent,
    TenantComponent,
    ReportComponent,
    UnitComponent,
    LeaseViewComponent
   
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatIconModule,
    MatToolbarModule,
    MatButtonModule,
    MatCardModule,
    MatGridListModule,
    MatFormFieldModule,
    MatSelectModule,
    MatTableModule,
    MatInputModule,
    MatPaginatorModule, 
    MatProgressSpinnerModule, 
    MatSortModule,
    MatDialogModule,

    RouterModule.forRoot([

      { path: '',   redirectTo: 'rentall/home', pathMatch: 'full' },
      { path: 'rentall',   redirectTo: 'rentall/home', pathMatch: 'full' },
      { path: 'rentall/home', component: HomeComponent },
      {path: 'rentall/Center', component: CenterComponent},
      {path: 'rentall/Center/units/leases', component: LeaseComponent},
      {path: 'rentall/tenants', component: TenantComponent},
      {path: 'rentall/reports', component: ReportComponent},
      {path: 'rentall/Center/:id/units', component: UnitComponent},
      {path: 'rentall/Center/:id/units/leases', component: LeaseComponent},
      {path: 'rentall/Center/{id}/units/{{unit.id}}/leases/valid', component: LeaseViewComponent},
    ]),
    BrowserAnimationsModule,
  
  ],
  providers: [
    
            
    ],
  bootstrap: [AppComponent]
})
export class AppModule { 


  
}
