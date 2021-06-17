import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReportComponent } from './report/report.component';
import { CenterReportComponent } from './center-report/center-report.component';



@NgModule({
  declarations: [ReportComponent, CenterReportComponent],
  imports: [
    CommonModule
  ],
  exports:[ReportComponent]
})
export class ReportsModule { }
