import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeaseComponent } from './lease/lease.component';
import { LeaseViewComponent } from './lease-view/lease-view.component';
import { LeaseEditorComponent } from './lease-editor/lease-editor.component';



@NgModule({
  declarations: [LeaseComponent, LeaseViewComponent, LeaseEditorComponent],
  imports: [
    CommonModule
  ],
  exports:[LeaseComponent]
})
export class LeasesModule { }
