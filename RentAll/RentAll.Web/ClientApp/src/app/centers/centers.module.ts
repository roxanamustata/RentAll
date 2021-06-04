import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CenterComponent } from './center/center.component';
import { UnitComponent } from './unit/unit.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [CenterComponent, UnitComponent],
  exports:[
    CenterComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forRoot([
      
      
      {path: 'units', component: UnitComponent}
      
    ]),
  ]
  
})
export class CentersModule { }


