import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { CenterClient, CreateUnitDto, UpdateUnitDto } from 'src/app/autogenerated/api';

@Component({
  selector: 'app-unit-editor',
  templateUrl: './unit-editor.component.html',
  styleUrls: ['./unit-editor.component.css']
})
export class UnitEditorComponent implements OnInit {

  unitToCreate: CreateUnitDto;
unitToUpdate: UpdateUnitDto;
  id: number;
  unitId: number;
  form: FormGroup;
  isAddMode: boolean;
  submitted = false;



  constructor(private centerClient: CenterClient,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,) { }

  ngOnInit() {
    this.id = parseInt(this.route.snapshot.paramMap.get("id"));
    this.unitId = parseInt(this.route.snapshot.paramMap.get("unitId"));

    this.form = this.fb.group({
      
      "unitCode": ["", Validators.required],
      "area": ["", Validators.required],
      "monthlyRentSqm": ["", Validators.required],
      "monthlyMaintenanceCostSqm": ["", Validators.required],
      "monthlyMarketingFeeSqm": ["", Validators.required],
      
    });

    if (!this.isAddMode) {

      this.centerClient.getUnitById(this.id, this.unitId)
        .pipe(first())
        .subscribe(x => this.form.patchValue(x));
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
      
      this.unitToCreate = this.form.value;
      this.centerClient.createUnitInCenter(this.id, this.unitToCreate)
         .subscribe(() => {
            
            this.router.navigate([`/rentall/Center/${this.id}/units`]);
           
          },

        );
    } else {

      this.unitToUpdate = this.form.value;
      this.centerClient.updateUnitInCenter(this.id, this.unitId, this.unitToUpdate)
        .subscribe(() => {
          this.router.navigate([`/rentall/Center/${this.id}/units`]);

        });
    }







  }

  cancelCreate() {
    // Simply navigate back to reminders view
    this.router.navigate([`/rentall/Center/${this.id}/units`], { relativeTo: this.route }); // Go up to parent route     
  }


}
