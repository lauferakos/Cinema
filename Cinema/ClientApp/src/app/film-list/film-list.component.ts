import { Component, Inject, OnInit} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Film } from '../models/film';
import { FilmService } from '../services/film.service';

@Component({
    selector: 'app-film-list',
    templateUrl: './film-list.component.html',
    styleUrls: ['./film-list.component.css']
})
/** film-list component*/
export class FilmListComponent implements OnInit{
/** film-list ctor */
  public films: Film[];
  constructor(private _filmService: FilmService) {

  }
  async ngOnInit() {
    this.films = await this._filmService.getFilms();
  }

  async searchByName(title: string) {
    if (title == '') {
      this.films = await this._filmService.getFilms();
    }
    else {
      var result = await this._filmService.getFilmByName(title);
      if (result) {
        this.films = [];
        this.films.push(result);
      }
      else {
        console.log('hiba');
      }
    }
  }
}

