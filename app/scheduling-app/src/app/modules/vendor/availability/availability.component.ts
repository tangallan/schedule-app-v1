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
  vendorId = '82410237-5528-4142-B92D-313998AD6C43'; //TODO: replace soon
  error = false;
  isEditing = false;
  vendorAvailMapped: any;
  dayAvailabilites: any[] = [
    {
      day: 'Sunday',
      dayOfWeek: 0
    },
    {
      day: 'Monday',
      dayOfWeek: 1
    },
    {
      day: 'Tuesday',
      dayOfWeek: 2
    },
    {
      day: 'Wednesday',
      dayOfWeek: 3
    },
    {
      day: 'Thursday',
      dayOfWeek: 4
    },
    {
      day: 'Friday',
      dayOfWeek: 5
    },
    {
      day: 'Saturday',
      dayOfWeek: 6
    }
  ];
  hours: any[] = [
    '01:00:00',
    '01:30:00',
    '02:00:00',
    '02:30:00',
    '03:00:00',
    '03:30:00',
    '04:00:00',
    '04:30:00',
    '05:00:00',
    '05:30:00',
    '06:00:00',
    '06:30:00',
    '07:00:00',
    '07:30:00',
    '08:00:00',
    '08:30:00',
    '09:00:00',
    '09:30:00',
    '10:00:00',
    '10:30:00',
    '11:00:00',
    '11:30:00',
    '12:00:00',
    '12:30:00',
    '13:00:00',
    '13:30:00',
    '14:00:00',
    '14:30:00',
    '15:00:00',
    '15:30:00',
    '16:00:00',
    '16:30:00',
    '17:00:00',
    '17:30:00',
    '18:00:00',
    '18:30:00',
    '19:00:00',
    '19:30:00',
    '20:00:00',
    '20:30:00',
    '21:00:00',
    '21:30:00',
    '22:00:00',
    '22:30:00',
    '23:00:00',
    '23:30:00',
  ];

  constructor(private vendorsService: VendorsService) { }

  ngOnInit() {
    this.error = false;
    this.vendorsService.getAvailability(this.vendorId).subscribe((result: VendorAvailability[]) => {
      this.vendorAvailMapped = result.reduce((obj, item) => {
        obj[item['dayOfWeek'].toString()] = item;
        return obj;
      }, {});
    }, err => {
      this.error = true;
    });
  }

  editAvailability() {
    this.isEditing = true;
  }

  cancelEditAvailability() {
    this.isEditing = false;
  }

  saveAvailability() { }

  toggleAvailability(evt, dayOfWeek) {
    const result = this.vendorAvailMapped[dayOfWeek.toString()];

    if (result) {
      this.error = false;
      result.saving = true;
      this.vendorsService.removeAvailability(this.vendorId, dayOfWeek)
        .subscribe(s => {
          delete this.vendorAvailMapped[dayOfWeek.toString()];
        }, error => {
          this.error = true;
          result.saving = false;
          evt.target.checked = true;
        });
    } else {
      this.initNewDayOfWeek(dayOfWeek);
    }
  }

  onTimeSelect(evt, dayOfWeek, timePropertyName: string) {
    if(!this.vendorAvailMapped[dayOfWeek.toString()]) {
      this.initNewDayOfWeek(dayOfWeek);
    }

    this.vendorAvailMapped[dayOfWeek.toString()][timePropertyName] = evt.target.value;
    this.trySaving(dayOfWeek);
  }

  private trySaving(dayOfWeek) {
    const result = this.vendorAvailMapped[dayOfWeek.toString()];
    if(result.fromTime && result.toTime) {
      this.error = false;
      result.saving = true;
      this.vendorsService.updateAvailability(this.vendorId, result)
        .subscribe(va => {
          result.saving = false;
        }, error => {
          result.saving = false;
          this.error = true;
        });
    } else {
      result.saving = false;
    }
  }

  private initNewDayOfWeek(dayOfWeek) {
    this.vendorAvailMapped[dayOfWeek.toString()] = new VendorAvailability().deserialize({
      id: 0,
      vendorId: this.vendorId,
      dayOfWeek,
      fromTime: '',
      toTime: ''
    });
  }
}
