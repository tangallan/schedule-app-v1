import { Component, OnInit } from '@angular/core';

// services
import { VendorsService } from '../shared/services/vendors.service';
import { VendorAvailability } from '../shared/models/vendorAvailability';

@Component({
  selector: 'app-availability',
  templateUrl: './availability.component.html',
  styleUrls: ['./availability.component.css']
})
export class AvailabilityComponent implements OnInit {

  vendorAvailMapped: any;
  dayAvailabilites = [
    {
      day: 'Sunday',
      dayOfWeek: 1
    },
    {
      day: 'Monday',
      dayOfWeek: 2,
    },
    {
      day: 'Tuesday',
      dayOfWeek: 3
    },
    {
      day: 'Wednesday',
      dayOfWeek: 4
    },
    {
      day: 'Thursday',
      dayOfWeek: 5
    },
    {
      day: 'Friday',
      dayOfWeek: 6
    },
    {
      day: 'Saturday',
      dayOfWeek: 7
    }
  ];

  constructor(private vendorsService: VendorsService) {}

  ngOnInit() {
    this.vendorsService.getAvailability('').subscribe((result: VendorAvailability[]) => {
      this.vendorAvailMapped = result.reduce((obj, item) => {
        obj[item['dayOfWeek'].toString()] = item;
        return obj;
      }, {});
    });
  }
}
