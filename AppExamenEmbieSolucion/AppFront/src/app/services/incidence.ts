import { Injectable } from '@angular/core';
import { Incidence } from '../models/incidence';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface IncidencesPage {
  data: Incidence[];
  total: number;
}

// @Injectable({
//   providedIn: 'root'
// })
// export class IncidencesPagination {
//   incidences: Incidence[] = [];
//   totalRegisters: number;
// }

@Injectable({providedIn: 'root'})
export class IncidencesService {

  private apiUrl = 'https://localhost:7231/api/Incidences';

  constructor(private http: HttpClient) {}

  getIncidences(page: number, pageSize: number, nameClient?: string, status?: string): Observable<IncidencesPage> {
    let params = new HttpParams()
      .set('page', page)
      .set('pageSize', pageSize);
    if (nameClient) {
      params = params.set('nameClient', nameClient);
    }
    if (status) {
      params = params.set('status', status);
    }
    return this.http.get<{ data: Incidence[], total: number }>(this.apiUrl, { params });
  }

  getIncidenceById(id: number): Observable<Incidence> {
    return this.http.get<Incidence>(`${this.apiUrl}/${id}`);
  }

  addIncidence(incidence: Incidence): Observable<Incidence> {
    return this.http.post<Incidence>(`${this.apiUrl}`, incidence);
  }

  updateIncidence(id: number, incidence: Incidence): Observable<Incidence> {
    return this.http.put<Incidence>(`${this.apiUrl}/${id}`, incidence);
  }
  // updateIncident(id: number, incident: Incident): Observable<void> {
  //   return this.http.put<void>(`${this.apiUrl}/${id}`, incident);
  // }

  deleteIncidence(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  getTotalRegisters(): Observable<number> {
    return new Observable<number>(observer => {
      this.http.get<Incidence[]>(this.apiUrl).subscribe(allData => {
        observer.next(allData.length);
        observer.complete();
      }, err => observer.error(err));
    });
  }
}
