import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CenterComponent } from './center/center.component';
import { UnitComponent } from './unit/unit.component';
import { RouterModule } from '@angular/router';
import { UnitEditorComponent } from './unit-editor/unit-editor.component';


@NgModule({
  declarations: [CenterComponent, UnitComponent, UnitEditorComponent],
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


