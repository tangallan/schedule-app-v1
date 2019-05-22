import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

// custom
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';

// modules
import { VendorRoutingModule } from './vendor-routing.module';

// components
import { VendorComponent } from './vendor/vendor.component';
import { SettingsComponent } from './settings/settings.component';
import { ServicetypesComponent } from './servicetypes/servicetypes.component';
import { AvailabilityComponent } from './availability/availability.component';
import { CalendarComponent } from './calendar/calendar.component';
import { VendorServiceFormComponent } from './shared/components/vendor-service-form.component';

// services
import { VendorsService } from './shared/services/vendors.service';



@NgModule({
  declarations: [
    VendorComponent,
    SettingsComponent,
    ServicetypesComponent,
    AvailabilityComponent,
    CalendarComponent,
    VendorServiceFormComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    VendorRoutingModule,
    HttpClientModule,
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory
    })
  ],
  providers: [
    VendorsService
  ]
})
export class VendorModule { }
