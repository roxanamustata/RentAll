import { identifierModuleUrl } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } 
    from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CenterClient, CreateLeaseDto, GetUnitDto } from 'src/app/autogenerated/api';

@Component({
  selector: 'app-lease-editor',
  templateUrl: './lease-editor.component.html',
  styleUrls: ['./lease-editor.component.css']
})
export class LeaseEditorComponent {

lease: CreateLeaseDto;
id: number;
unitId: number;


   
  constructor(private centerClient:CenterClient,private fb: FormBuilder, 
    private route: ActivatedRoute, private router: Router) {

  }


  form =this.fb.group({
    "centerId": ["", Validators.required],
    "leaseNumber": ["", Validators.required],
    "tenantId":["", Validators.required],
    "activityId":["", Validators.required],
    "signingDate":["", Validators.required],
    "startDate":["", Validators.required],
    "termInMonths":["", Validators.required],
    "endDate":["", Validators.required],
    "valid":["", Validators.required],
    "userId":["", Validators.required],

    
});

onSubmit() {
console.log("reactive form submitted");
console.log(this.form);
if (this.form.invalid) {
  return;
}
this.id = parseInt(this.route.snapshot.paramMap.get("id"));
this.unitId = parseInt(this.route.snapshot.paramMap.get("unitId"));

this.lease =this.form.value;
this.centerClient.createLeaseInCenter(this.id, this.unitId, this.lease)
    .subscribe( );
    
    // page is showing this lease only after refresh
    this.router.navigate([`/rentall/Center/${this.id}/units/leases`]);
   

}



}
