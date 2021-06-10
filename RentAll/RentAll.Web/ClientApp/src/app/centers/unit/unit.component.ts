import { Component, OnInit } from "@angular/core";
import {
  CenterClient,
  GetCenterDto,
  GetLeaseDto,
} from "src/app/autogenerated/api";
import { GetUnitDto } from "src/app/autogenerated/api";
import { ActivatedRoute, Router } from "@angular/router";
import { UnitsDataSource } from "./units.datasource";
import { MatDialog } from "@angular/material";
import { LeaseViewComponent } from "src/app/leases/lease-view/lease-view.component";

@Component({
  selector: "app-unit",
  templateUrl: "./unit.component.html",
  styleUrls: ["./unit.component.css"],
})
export class UnitComponent implements OnInit {
  dataSource: UnitsDataSource;
  center: GetCenterDto;
  displayedColumns = [
    "id",
    "unitCode",
    "area",
    "floor",
    "type",
    "monthlyRentSqm",
    "monthlyMaintenanceCostSqm",
    "monthlyMarketingFeeSqm",
    "actions",
  ];
  id: number;
  unitId: number;
  unit: GetUnitDto;
  lease: GetLeaseDto;

  constructor(
    private readonly centerClient: CenterClient,
    private route: ActivatedRoute,
    private router: Router,
    public dialog: MatDialog
  ) {}

  ngOnInit() {
    this.id = parseInt(this.route.snapshot.paramMap.get("id"));

    this.centerClient
      .getCenterById(this.id)
      .subscribe((data) => (this.center = data));
    this.dataSource = new UnitsDataSource(this.centerClient);

    this.dataSource.loadUnits(this.id);
  }

  openDialog(unitId: number): void {
      
    this.centerClient
      .getValidLeaseByUnitId(unitId)
      .subscribe((data) => {
          this.lease = data;
          const dialogRef = this.dialog.open(LeaseViewComponent, {
            width: "250px",
            data: this.lease,
          });
          dialogRef.afterClosed().subscribe((result) => {
            console.log(`Dialog result: ${result}`);
      
          });
        
        });

    

   
    // dialogRef.close();
    


  }

  //   openDialog(unitId: number) {
  //     // this.unitId = id;
  //     this.centerClient.getUnitById(this.id, unitId).subscribe((data) => {
  //       this.unit = data;
  //       const dialogRef = this.dialog.open(LeaseViewComponent, {
  //         data: {
  //             height: '400px',
  //             width: '600px',
  //           unit: this.unit,

  //         },
  //       });

  //       dialogRef.afterClosed().subscribe((data) => {
  //         console.log(`Dialog result: ${data}`);
  //       });

  //       dialogRef.close('Pizza!');
  //     });
  //   }

  onRowClicked(row) {
    console.log("Row clicked: ", row);
  }
}
