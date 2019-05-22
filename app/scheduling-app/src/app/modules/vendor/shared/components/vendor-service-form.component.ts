import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { VendorService } from '../models/vendorService';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-vendorservice-form',
  templateUrl: './vendor-service-form.component.html',
  styleUrls: []
})
export class VendorServiceFormComponent implements OnInit {

  // tslint:disable-next-line: no-input-rename
  @Input('vendorService') public vendorService: VendorService;

  // tslint:disable-next-line: no-input-rename
  @Input('saving') public saving: boolean;

  // tslint:disable-next-line: no-output-rename
  @Output('createdNewVendorService') createdNewVendorService = new EventEmitter<any>();

  isEdit = false;

  constructor() { }

  ngOnInit() {
    if (!this.vendorService) {
      this.vendorService = new VendorService();
      this.isEdit = false;
    } else {
      this.isEdit = true;
    }
  }

  createNewServiceType(form: NgForm) {
    if(form.valid) {
      this.createdNewVendorService.emit({
        vendorService: this.vendorService,
        form,
        isEdit: this.isEdit
      });
    }
  }
}
