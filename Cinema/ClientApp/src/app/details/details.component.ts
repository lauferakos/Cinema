import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FilmService } from '../services/film.service';
import { Film } from '../models/film';
import { Location } from '@angular/common';

@Component({
    selector: 'app-details',
    templateUrl: './details.component.html',
    styleUrls: ['./details.component.css']
})
/** details component*/
export class DetailsComponent implements OnInit {
/** details ctor */

  filmid: string;
  film: Film;
  constructor(private _Activatedroute: ActivatedRoute,
    private _filmService: FilmService,
    private _location: Location) {
    }
  async ngOnInit() {
    this.filmid = this._Activatedroute.snapshot.paramMap.get("filmid");
    this.film = await this._filmService.getFilmById(this.filmid);
  }

  backClicked() {
    this._location.back();
  }
}
