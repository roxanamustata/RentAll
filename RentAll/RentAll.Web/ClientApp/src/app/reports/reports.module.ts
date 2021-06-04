import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReportComponent } from './report/report.component';



@NgModule({
  declarations: [ReportComponent],
  imports: [
    CommonModule
  ],
  exports:[ReportComponent]
})
export class ReportsModule { }
