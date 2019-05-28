import { Component, OnInit, Input } from '@angular/core';
import { VendorServiceResult } from '../../models/vendorServiceResult';

@Component({
  selector: 'app-service-listings',
  templateUrl: './serviceListings.component.html',
  styleUrls: ['./serviceListings.component.css']
})
export class ServiceListingsComponent implements OnInit {

// tslint:disable-next-line: no-input-rename
  @Input('vendorServices') public vendorServices: VendorServiceResult[];

  constructor() { }

  ngOnInit() {
  }

}
