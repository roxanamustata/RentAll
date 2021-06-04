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
import {MatTableModule} from '@angular/material/table';
import {MatInputModule} from '@angular/material/input';


import {CentersModule} from './centers/centers.module';
import {HomeModule} from './home/home.module';
import {LeasesModule} from './leases/leases.module';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home/home.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CenterComponent } from './centers/center/center.component';
import { UnitComponent } from './centers/unit/unit.component';
import { LeaseComponent } from './leases/lease/lease.component';
import { TenantComponent } from './tenants/tenant/tenant.component';
import { ReportComponent } from './reports/report/report.component';





@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
   
    CenterComponent,
    LeaseComponent,
    TenantComponent,
    ReportComponent,
    UnitComponent
   
    
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
  
    // CentersModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent, pathMatch: 'full' },
      // { path: 'counter', component: CounterComponent },
      // { path: 'fetch-data', component: FetchDataComponent },
      {path: 'Center', component: CenterComponent},
      {path: 'Center/units/leases', component: LeaseComponent},
      {path: 'tenants', component: TenantComponent},
      {path: 'reports', component: ReportComponent},
      {path: 'Center/:id/units', component: UnitComponent},
    ]),
    BrowserAnimationsModule,
  
  ],
  providers: [
    
            
    ],
  bootstrap: [AppComponent]
})
export class AppModule { 


  
}
