import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, flatMap } from 'rxjs/operators'

import { VendorAvailability } from '../models/vendorAvailability';
import { VendorService } from '../models/vendorService';


@Injectable()
export class VendorsService {
  constructor(private http: HttpClient) {
  }

  getAvailability(vendorid: string): Observable<VendorAvailability[]> {
    let headers = new HttpHeaders()
      .set('Content-Type', 'application/json');

    return this.http.get(`https://localhost:5001/api/vendors/${vendorid}/availabilities`, {
      headers
    })
      .pipe(
        map((json: any[]) => {
          let r = [];
          json.forEach(v => {
            const va = new VendorAvailability().deserialize(v);
            r.push(va);
          });
          return r;
        })
      );
  }

  updateAvailability(vendorid: string, va: VendorAvailability): Observable<VendorAvailability> {
    return this.http.put(`https://localhost:5001/api/vendors/${vendorid}/availability`, va)
      .pipe(
        map((json: any) => {
          const va = new VendorAvailability().deserialize(json);
          return va;
        })
      );
  }

  removeAvailability(vendorid, dayOfWeek) {
    return this.http.delete(`https://localhost:5001/api/vendors/${vendorid}/availability/${dayOfWeek}`);
  }

  getAllServices(vendorid): Observable<VendorService[]> {
    let headers = new HttpHeaders()
      .set('Content-Type', 'application/json');

    return this.http.get(`https://localhost:5001/api/vendors/${vendorid}/services`, {
      headers
    })
      .pipe(
        map((json: any[]) => {
          let r = [];
          json.forEach(v => {
            const va = new VendorService().deserialize(v);
            r.push(va);
          });
          return r;
        })
      );
  }

  createNewService(vendorid, vendorService: VendorService): Observable<VendorService> {
    return this.http.post(`https://localhost:5001/api/vendors/${vendorid}/services`, vendorService)
      .pipe(
        map((json: any) => {
          const vs = new VendorService().deserialize(json);
          return vs;
        })
      );
  }

  updateService(vendorid, vendorService: VendorService): Observable<VendorService> {
    return this.http.put(`https://localhost:5001/api/vendors/${vendorid}/services`, vendorService)
      .pipe(
        map((json: any) => {
          const vs = new VendorService().deserialize(json);
          return vs;
        })
      );
  }
}
