import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { VendorService } from '../shared/models/vendorService';
import { VendorsService } from '../shared/services/vendors.service';

@Component({
  selector: 'app-servicetypes',
  templateUrl: './servicetypes.component.html',
  styleUrls: ['./servicetypes.component.css']
})
export class ServicetypesComponent implements OnInit {
  vendorId = '82410237-5528-4142-B92D-313998AD6C43'; //TODO: replace soon
  creatingNew = false;

  allVendorServices: VendorService[] = [];

  errored = false;
  success = false;
  saving = false;

  editingVendorService: VendorService;

  constructor(private vendorService: VendorsService) { }

  ngOnInit() {
    this.resetValidState();

    this.vendorService.getAllServices(this.vendorId)
      .subscribe(res => {
        this.allVendorServices = res;
      }, error => {
        this.allVendorServices = [];
        this.errored = true;
      });
  }

  toggleCreateNewServiceType() {
    this.creatingNew = !this.creatingNew;
    if (this.creatingNew) {
      this.editingVendorService = null;
    }
  }

  createNewServiceType(cmpEvent) {
    const currentVS: VendorService = cmpEvent.vendorService;
    const form: NgForm = cmpEvent.form;
    const isEdit = cmpEvent.isEdit;

    this.resetValidState();

    if (isEdit) {
      this.saving = true;
      this.vendorService.updateService(this.vendorId, currentVS)
        .subscribe(res => {
          this.saving = false;
          this.creatingNew = false;
          this.showHideSuccess();
        }, error => {
          this.errored = true;
          this.saving = false;
        });
    } else {
      this.saving = true;
      this.vendorService.createNewService(this.vendorId, currentVS)
        .subscribe(res => {
          this.allVendorServices.push(res);
          this.saving = false;

          form.reset();
          this.showHideSuccess();
        }, error => {
          this.errored = true;
          this.saving = false;
        });
    }

  }

  editServiceType(serviceType: VendorService) {
    this.editingVendorService = serviceType;
    this.creatingNew = true;
  }

  deleteServiceType(serviceType: VendorService) {
    this.errored = false;
    this.vendorService.removeService(this.vendorId, serviceType)
      .subscribe(resp => {
        this.allVendorServices = this.allVendorServices.filter(f => f.id !== serviceType.id);
      }, error => {
        this.errored = true;
      });
  }

  private resetValidState() {
    this.errored = false;
    this.success = false;
  }

  private showHideSuccess() {
    this.success = true;
    setTimeout(() => {
      this.success = false;
    }, 1500);
  }
}
