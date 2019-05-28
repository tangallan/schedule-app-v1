import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../shared/services/customer.service';
import { VendorSearchService } from '../shared/services/vendorSearch.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  customerLoaded = false;

  serviceSearch = {
    text: '',
    location: '',
    waitTime: ''
  };

  constructor(private customerService: CustomerService, private vendorSearchService: VendorSearchService) { }

  ngOnInit() {
    this.customerService.initCustomer()
      .subscribe(s => {
        if(s) {
          this.customerLoaded = true;
        }
      });
  }


  searchServices() {
    this.vendorSearchService.searchServices(this.serviceSearch.text)
      .subscribe(s => {
        console.log('s', s);
      })
  }
}
