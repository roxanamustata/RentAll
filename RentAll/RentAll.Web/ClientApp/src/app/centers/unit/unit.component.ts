import { Component, OnInit } from "@angular/core";
import { CenterClient } from "src/app/autogenerated/api";
import { GetUnitDto } from "src/app/autogenerated/api";
import { ActivatedRoute, Router } from "@angular/router";
import { UnitsDataSource } from "./units.datasource";

@Component({
  selector: "app-unit",
  templateUrl: "./unit.component.html",
  styleUrls: ["./unit.component.css"],
})
export class UnitComponent implements OnInit {
  dataSource: UnitsDataSource;
  displayedColumns = ["id", "unitCode", "area", "floor", "type",  "monthlyRentSqm", 
  "monthlyMaintenanceCostSqm","monthlyMarketingFeeSqm"];
   id: number;


  constructor(
    private readonly centerClient: CenterClient,
    private route: ActivatedRoute,  
    private router: Router
  ) {}

  ngOnInit() {
    this.id = parseInt(this.route.snapshot.paramMap.get("id"));
    this.dataSource = new UnitsDataSource(this.centerClient);
  
    this.dataSource.loadLessons(this.id);

  }

  onRowClicked(row) {
    console.log('Row clicked: ', row);
}



}