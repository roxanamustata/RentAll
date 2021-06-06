import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeaseComponent } from './lease/lease.component';
import { LeaseViewComponent } from './lease-view/lease-view.component';



@NgModule({
  declarations: [LeaseComponent, LeaseViewComponent],
  imports: [
    CommonModule
  ],
  exports:[LeaseComponent]
})
export class LeasesModule { }
