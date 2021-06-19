import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TenantComponent } from './tenant/tenant.component';
import { TenantEditorComponent } from './tenant-editor/tenant-editor.component';



@NgModule({
  declarations: [TenantComponent, TenantEditorComponent],
  imports: [
    CommonModule
  ],
  exports:[TenantComponent]
})
export class TenantsModule { }
