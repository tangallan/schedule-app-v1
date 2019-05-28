import { Component, OnInit } from '@angular/core';
import { CalendarEvent } from 'angular-calendar';
import { addDays, addHours, startOfDay } from 'date-fns';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {
  view: string = 'week';

  viewDate: Date = new Date();

  events: CalendarEvent[] = [];

  constructor() { }

  ngOnInit() {
    let d1 = addDays(new Date(), -1);
    d1 = addHours(d1, -3);
    this.events.push({
      start: d1,
      title: 'Test 1',
      actions: [
        {
          label: 'View',
          onClick: ({ event }: { event: CalendarEvent }): void => {
            this.handleEvent(event);
          }
        }
      ]
    });
  }

  toggleCalendarView(view) {
    this.view = view;
  }

  handleEvent(event: CalendarEvent) {
    console.log(event);
  }
}
