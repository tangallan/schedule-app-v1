import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { VendorServiceResult } from '../models/vendorServiceResult';

@Injectable({
  providedIn: 'root'
})
export class VendorSearchService {

  constructor(private http: HttpClient) { }

  searchServices(text: string): Observable<VendorServiceResult[]> {
    const params = new HttpParams()
      .set('text', text);

    return this.http.get('https://localhost:5001/api/vendors/services/search', {
      params
    })
      .pipe(
        map((json: any[]) => {
          const r = [];
          json.forEach(v => {
            const va = new VendorServiceResult().deserialize(v);
            r.push(va);
          });
          return r;
        })
      );
  }

}
