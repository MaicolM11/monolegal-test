import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bill } from '../models/Bill';

@Injectable({
  providedIn: 'root'
})
export class ApiBillService {


  url: string = 'https://localhost:5001/api/bill';

  constructor(private http: HttpClient ) {

  }

  getBills(): Observable<Bill[]>{
    return this.http.get<Bill[]>(this.url);
  }

  update(id: string) {
    return this.http.put<boolean>(this.url+"/"+id, {} );
  }

}
