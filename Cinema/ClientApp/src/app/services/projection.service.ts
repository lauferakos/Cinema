import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Projection } from '../models/projection';
import { Observable } from 'rxjs';

@Injectable()
export class ProjectionService {
  baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  async getProjectionsByFilmId(filmId: string): Promise<Projection[]>{
    let getProjectionsUrl = this.baseUrl + 'projection/' + filmId;
    return await this.http.get<Projection[]>(getProjectionsUrl).toPromise();
  }
  async getAllProjection(): Promise<Projection[]> {
    let getAllProjectionUrl = this.baseUrl + 'projection';
    return await this.http.get<Projection[]>(getAllProjectionUrl).toPromise();
  }

  addProjection(proj: Projection): Observable<Projection> {
    let addProjectionUrl = this.baseUrl + 'projection';
    return this.http.post<Projection>(addProjectionUrl, proj);
  }
  deleteProjection(id: number): Observable<Projection> {
    let deleteProjUrl = this.baseUrl + 'projection/delete/' + id;
    return this.http.delete<Projection>(deleteProjUrl);
  }

  async getProjectionById(id: string): Promise<Projection> {
    let getProjectionByIdUrl = this.baseUrl + 'projection/get/' + id;
    return await this.http.get<Projection>(getProjectionByIdUrl).toPromise();
  }

  editProjection(id: string, proj: Projection): Observable<Projection> {
    console.log(proj);
    let editProjectionUrl = this.baseUrl + 'projection/' + id;
    return this.http.put<Projection>(editProjectionUrl, proj);
  }
 
}
