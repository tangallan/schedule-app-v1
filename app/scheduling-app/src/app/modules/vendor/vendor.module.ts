import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VendorComponent } from './vendor/vendor.component';
import { VendorRoutingModule } from './vendor-routing.module';
import { SettingsComponent } from './settings/settings.component';
import { ServicetypesComponent } from './servicetypes/servicetypes.component';
import { AvailabilityComponent } from './availability/availability.component';
import { CalendarComponent } from './calendar/calendar.component';

@NgModule({
  declarations: [VendorComponent, SettingsComponent, ServicetypesComponent, AvailabilityComponent, CalendarComponent],
  imports: [
    CommonModule,
    VendorRoutingModule
  ]
})
export class VendorModule { }
