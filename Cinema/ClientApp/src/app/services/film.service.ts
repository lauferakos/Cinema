import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Film } from '../models/film';
import { Observable } from 'rxjs';

@Injectable()
export class FilmService {
  baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }


  async getPopularFilms(): Promise<Film[]> {
    let getPopularFilmUrl = this.baseUrl + 'film/popular';
    return await this.http.get<Film[]>(getPopularFilmUrl).toPromise();
  }
  async getFilms(): Promise<Film[]>{
    let getFilmsUrl = this.baseUrl + 'film';
    return await this.http.get<Film[]>(getFilmsUrl).toPromise();
  }

  async getFilmByName(title: string): Promise<Film> {
    let getFilmByNameUrl = this.baseUrl + 'film/title/'+title;
    return await this.http.get<Film>(getFilmByNameUrl).toPromise();
  }
  async getFilmById(id: string): Promise<Film> {
    let getFilmByIdUrl = this.baseUrl + 'film/' + id;
    return await this.http.get<Film>(getFilmByIdUrl).toPromise();
  }

  addFilm(film: Film): Observable<Film> {
    let addFilmUrl = this.baseUrl + 'film';
    return this.http.post<Film>(addFilmUrl,film);
  }

  deleteFilm(id:number): Observable<Film> {
    let deleteFilmUrl = this.baseUrl + 'film/delete/' + id;
    return this.http.delete<Film>(deleteFilmUrl);
  }

  editFilm(id: number, film: Film): Observable<Film> {
    let editFilmUrl = this.baseUrl + 'film/' + id;
    return this.http.put<Film>(editFilmUrl, film);
  }


}
