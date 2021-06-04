import { Component, OnInit } from '@angular/core';
import {FormControl} from '@angular/forms';
interface Center {
  value: string;
  viewValue: string;
}
export interface Lease {
  position: number;
  tenantName: string;
  leaseNumber: string;
  startDate: Date;
  endDate: Date;
  code: string;
  area: number;
  monthlyRentSqm:number;
  monthlyMaintenanceCostSqm: number;
  monthlyMarketingFeeSqm:number;
}

const ELEMENT_DATA: Lease[] = [
  {position: 1, tenantName: 'Zara', leaseNumber: '100', startDate: new Date(2021-1-15), endDate: new Date(2031-1-14),  code: 'A1', area: 2000,monthlyRentSqm: 10, monthlyMaintenanceCostSqm:5, monthlyMarketingFeeSqm:1},
  {position: 2, tenantName: 'Mango', leaseNumber: '101', startDate: new Date(2021-1-15), endDate: new Date(2031-1-14),  code: 'A2', area: 1000,monthlyRentSqm: 15, monthlyMaintenanceCostSqm:5, monthlyMarketingFeeSqm:1},
  {position: 3, tenantName: 'Auchan', leaseNumber: '102', startDate: new Date(2021-1-15), endDate: new Date(2031-1-14),  code: 'A3', area: 15000,monthlyRentSqm: 10, monthlyMaintenanceCostSqm:5, monthlyMarketingFeeSqm:1},
];


@Component({
  selector: 'app-lease',
  templateUrl: './lease.component.html',
  styleUrls: ['./lease.component.css']
})
export class LeaseComponent implements OnInit {
  constructor() { }
  
  ngOnInit() {
  }

  centers: Center[] = [
    {value: 'IMTM-0', viewValue: 'Iulius Mall Timisoara'},
    {value: 'IMCJ-1', viewValue: 'Iulius Mall Cluj'},
    {value: 'IMSV-2', viewValue: 'Iulius Mall Suceava'}
  ];

  displayedColumns: string[] = ['position', 'tenantName','leaseNumber',
   'startDate', 'endDate','code', 'area','monthlyRentSqm','monthlyMaintenanceCostSqm','monthlyMarketingFeeSqm' ];
  dataSource = ELEMENT_DATA;
  // disableSelect = new FormControl(false);
 
}
