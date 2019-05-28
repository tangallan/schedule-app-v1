import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { CustomerRoutingModule } from './customer-routing.module';

import { CustomerComponent } from './customer/customer.component';
import { AppointmentsComponent } from './appointments/appointments.component';
import { ServiceListingsComponent } from './shared/components/serviceListings/serviceListings.component';


import { CustomerService } from './shared/services/customer.service';
import { VendorSearchService } from './shared/services/vendorSearch.service';


@NgModule({
  declarations: [
    CustomerComponent,
    AppointmentsComponent,
    ServiceListingsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    CustomerRoutingModule,
    HttpClientModule
  ],
  providers: [
    CustomerService,
    VendorSearchService
  ]
})
export class CustomerModule { }
