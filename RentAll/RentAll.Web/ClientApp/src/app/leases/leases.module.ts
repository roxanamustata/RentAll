import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeaseComponent } from './lease/lease.component';



@NgModule({
  declarations: [LeaseComponent],
  imports: [
    CommonModule
  ],
  exports:[LeaseComponent]
})
export class LeasesModule { }
