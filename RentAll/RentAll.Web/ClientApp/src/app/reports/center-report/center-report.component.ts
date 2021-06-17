import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';


@Component({
  selector: 'app-center-report',
  templateUrl: './center-report.component.html',
  styleUrls: ['./center-report.component.css']
})
export class CenterReportComponent  {

  constructor( public dialogRef: MatDialogRef<CenterReportComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Record<string, number>) { 
    {}
  }

  

}
