import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

// modules
import { VendorRoutingModule } from './vendor-routing.module';

// components
import { VendorComponent } from './vendor/vendor.component';
import { SettingsComponent } from './settings/settings.component';
import { ServicetypesComponent } from './servicetypes/servicetypes.component';
import { AvailabilityComponent } from './availability/availability.component';
import { CalendarComponent } from './calendar/calendar.component';

// services
import { VendorsService } from './shared/services/vendors.service';

@NgModule({
  declarations: [VendorComponent, SettingsComponent, ServicetypesComponent, AvailabilityComponent, CalendarComponent],
  imports: [
    CommonModule,
    VendorRoutingModule,
    HttpClientModule
  ],
  providers: [
    VendorsService
  ]
})
export class VendorModule { }
