import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TenantComponent } from './tenant/tenant.component';



@NgModule({
  declarations: [TenantComponent],
  imports: [
    CommonModule
  ],
  exports:[TenantComponent]
})
export class TenantsModule { }
