import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { map, flatMap } from 'rxjs/operators'

import { VendorAvailability } from '../models/vendorAvailability';


@Injectable()
export class VendorsService {
    constructor(private http: HttpClient) {
    }

    getAvailability(vendorid: String) : Observable<VendorAvailability[]> {
        let headers = new HttpHeaders()
            .set("Content-Type", "application/json");

        return this.http.get(`https://localhost:5001/api/vendors/82410237-5528-4142-B92D-313998AD6C43/availabilities`, {
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
}