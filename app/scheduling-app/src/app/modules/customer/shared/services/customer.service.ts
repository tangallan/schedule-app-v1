import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private CUSTOMER_ID_KEY = 'customerid';

  constructor(private http: HttpClient) { }

  initCustomer(): Observable<string> {
    const cid = localStorage.getItem(this.CUSTOMER_ID_KEY);

    if (cid) {
      return of(cid);
    }

    return this.http.get('https://localhost:5001/api/customers/newcustomer')
      .pipe(
        tap((newCid: string) => {
          console.log('newcid', newCid);
          localStorage.setItem(this.CUSTOMER_ID_KEY, newCid);
        }),
        map((newCid: string) => newCid)
      );
  }

  getCustomerId() {
    return localStorage.getItem(this.CUSTOMER_ID_KEY);
  }
}
