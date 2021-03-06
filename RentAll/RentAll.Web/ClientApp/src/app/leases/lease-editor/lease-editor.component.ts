import { DatePipe } from '@angular/common';
import { identifierModuleUrl } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder }
  from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { first } from 'rxjs/operators';
import { CenterClient, CompanyClient, CreateLeaseDto, GetActivityDto, GetCenterDto, GetCompanyDto, GetUnitDto, UserClient } from 'src/app/autogenerated/api';

@Component({
  selector: 'app-lease-editor',
  templateUrl: './lease-editor.component.html',
  styleUrls: ['./lease-editor.component.css']
})
export class LeaseEditorComponent implements OnInit {

  lease: CreateLeaseDto;

  id: number;
  unitId: number;
  leaseId: number;
  selectedCenter$: GetCenterDto;
  form: FormGroup;
  isAddMode: boolean;
  loading = false;
  submitted = false;
  selectedTenant$: GetCompanyDto;

  activityOptions$ = this.centerClient.listActivities();
  tenantOptions$ = this.companyClient.listCompanies();
  centerOptions$ = this.centerClient.listCenters();
  userOptions$ = this.userClient.listUsers();





  constructor(private centerClient: CenterClient,
    private companyClient: CompanyClient,
    private userClient: UserClient,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
  ) {

  }
  ngOnInit() {
    this.id = parseInt(this.route.snapshot.paramMap.get("id"));
    this.leaseId = parseInt(this.route.snapshot.paramMap.get("leaseId"));
    this.isAddMode = !this.leaseId;


    this.centerClient.getCenterById(this.id).subscribe(data => this.selectedCenter$ = data);


    this.form = this.fb.group({
      "centerId": ["", Validators.required],
      "leaseNumber": ["", Validators.required],
      "tenantId": ["", Validators.required],
      "activityId": ["", Validators.required],
      "signingDate": ["", Validators.required],
      "startDate": ["", Validators.required],
      "termInMonths": ["", Validators.required],
      "endDate": ["", Validators.required],
      "valid": ["", Validators.required],
      "userId": ["", Validators.required],

    });

    if (!this.isAddMode) {

      this.leaseId = parseInt(this.route.snapshot.paramMap.get("leaseId"));


      this.centerClient.getLeaseById(this.id, this.leaseId)
        .pipe(first())
        .subscribe(x => this.form.patchValue({
          "centerId": x.centerId,
          "leaseNumber": x.leaseNumber,
          "tenantId": x.tenantId,
          "activityId": x.activityId,
          "signingDate": new DatePipe('en-US').transform(x.signingDate, 'yyyy-MM-dd'),
          "startDate": new DatePipe('en-US').transform(x.startDate, 'yyyy-MM-dd'),
          "termInMonths": x.termInMonths,
          "endDate": new DatePipe('en-US').transform(x.endDate, 'yyyy-MM-dd'),
          "valid": x.valid,
          "userId": x.userId,

        }));
    }

  }
  get f() { return this.form.controls; }



  onSubmit() {
    this.submitted = true;

    if (this.form.invalid) {
      return;
    }
    // this.loading = true;

    if (this.isAddMode) {
      this.unitId = parseInt(this.route.snapshot.paramMap.get("unitId"));
      this.lease = this.form.value;
      this.centerClient.createLeaseInCenter(this.id, this.unitId, this.lease)
        .subscribe(
          () => {
            this.router.navigate([`/rentall/Center/${this.id}/units/leases`]);

          },

        );
    } else {

      this.lease = this.form.value;
      this.centerClient.updateLeaseInCenter(this.id, this.leaseId, this.lease)
        .subscribe(() => {

          this.router.navigate([`/rentall/Center/${this.id}/units/leases`]);
        });
    }







  }

  cancelCreate() {
    // Simply navigate back to reminders view
    this.router.navigate([`/rentall/Center/${this.id}/units/leases`], { relativeTo: this.route }); // Go up to parent route     
  }

}
