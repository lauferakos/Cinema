import { Component, OnInit, Inject } from '@angular/core';
import { Film } from '../models/film';
import { FilmService } from '../services/film.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public films: Film[];

  constructor(private _filmService: FilmService) {

  }
  async ngOnInit() {
    this.films = await this._filmService.getPopularFilms();
    }
}
