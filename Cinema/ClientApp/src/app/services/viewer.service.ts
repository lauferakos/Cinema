import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Viewer } from '../models/viewer';
import { Observable } from 'rxjs';

@Injectable()
export class ViewerService {
  baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;

  }
  async getAllViewer(): Promise<Viewer[]> {
    let getAllViewerUrl = this.baseUrl + 'viewer';
    return await this.http.get<Viewer[]>(getAllViewerUrl).toPromise();
  }

  deleteViewer(id: number): Observable<Viewer> {
    let deleteViewerUrl = this.baseUrl + 'viewer/delete/' + id;
    return this.http.delete<Viewer>(deleteViewerUrl);
  }
  addViewer(viewer: Viewer): Observable<Viewer> {
    let addViewerUrl = this.baseUrl + 'viewer';
    return this.http.post<Viewer>(addViewerUrl, viewer);
  }
}
