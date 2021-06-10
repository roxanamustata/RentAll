import { Component, Inject, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { CenterClient, GetLeaseDto, GetUnitDto } from "src/app/autogenerated/api";
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
@Component({
  selector: "app-lease-view",
  templateUrl: "./lease-view.component.html",
  styleUrls: ["./lease-view.component.css"],
})
export class LeaseViewComponent {

  constructor(
    public dialogRef: MatDialogRef<LeaseViewComponent>,
    @Inject(MAT_DIALOG_DATA) public data: GetLeaseDto) {}

  // onNoClick(): void {
  //   this.dialogRef.close();
  // }


}
