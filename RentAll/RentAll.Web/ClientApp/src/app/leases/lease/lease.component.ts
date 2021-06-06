import { Component, OnInit } from '@angular/core';
import {FormControl} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CenterClient, GetCenterDto } from 'src/app/autogenerated/api';
import { UnitsDataSource } from 'src/app/centers/unit/units.datasource';
import { LeasesDataSource } from './leases.datasource';


@Component({
  selector: 'app-lease',
  templateUrl: './lease.component.html',
  styleUrls: ['./lease.component.css']
})
export class LeaseComponent implements OnInit {
  dataSource: LeasesDataSource;
  center: GetCenterDto;
  displayedColumns = ["leaseNumber", "tenant", "signingDate", "startDate",  "termInMonths", "valid","activity", "center"];
   id: number;


  constructor(
    private readonly centerClient: CenterClient,
    private route: ActivatedRoute,  
    private router: Router
  ) {}

  ngOnInit() {

    if(this.route.snapshot.paramMap.get("id")!=null){
    this.id = parseInt(this.route.snapshot.paramMap.get("id"));

   this.centerClient.getCenterById(this.id).subscribe(data=>this.center=data);

    this.dataSource = new LeasesDataSource(this.centerClient);
  
    this.dataSource.loadLeasesInCenter(this.id);
    }
    else{
      this.dataSource = new LeasesDataSource(this.centerClient);
  
    this.dataSource.loadLeases();
    }
  }

  onRowClicked(row) {
    console.log('Row clicked: ', row);
}



}