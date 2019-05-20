import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { VendorComponent } from './vendor/vendor.component';
import { SettingsComponent } from './settings/settings.component';
import { AvailabilityComponent } from './availability/availability.component';
import { ServicetypesComponent } from './servicetypes/servicetypes.component';
import { CalendarComponent } from './calendar/calendar.component';

const routes: Routes = [
  {
    path: '',
    component: VendorComponent,
    children: []
  },
  {
    path: 'settings',
    component: SettingsComponent
  },
  {
    path: 'availability',
    component: AvailabilityComponent
  },
  {
    path: 'servicetypes',
    component: ServicetypesComponent
  },
  {
    path: 'calendar',
    component: CalendarComponent
  },
  {
    pathMatch: 'full',
    redirectTo: ''
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VendorRoutingModule {}
