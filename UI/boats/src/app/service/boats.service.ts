import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Boat } from '../models/boat.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BoatsService {


  baseUrl = 'https://localhost:7132/api/boats';

  constructor(private http: HttpClient) { }


  //get all boats jobs
  getAllBoats() : Observable<Boat[]> {
    return this.http.get<Boat[]>(this.baseUrl);
  }
}
