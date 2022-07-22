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
  getAllJobs() : Observable<Boat[]> {
    return this.http.get<Boat[]>(this.baseUrl);
  }

  addJob(job: Boat): Observable<Boat> {
    job.id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<Boat>(this.baseUrl, job);
  }
}
