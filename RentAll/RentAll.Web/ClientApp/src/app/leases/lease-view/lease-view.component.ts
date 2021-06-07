import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { CenterClient, GetLeaseDto } from "src/app/autogenerated/api";

@Component({
  selector: "app-lease-view",
  templateUrl: "./lease-view.component.html",
  styleUrls: ["./lease-view.component.css"],
})
export class LeaseViewComponent implements OnInit {
  lease: GetLeaseDto;
  id: number;
  unitId: number;

  constructor(
    private readonly centerClient: CenterClient,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.id = parseInt(this.route.snapshot.paramMap.get("id"));
    this.unitId = parseInt(this.route.snapshot.paramMap.get("unitId"));

    this.centerClient
      .getValidLeaseByUnitId( this.unitId)
      .subscribe((data) => (this.lease = data));
  }
}
