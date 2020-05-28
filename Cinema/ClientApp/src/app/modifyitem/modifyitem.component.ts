import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Film } from '../models/film';
import { FilmService } from '../services/film.service';
import { FormBuilder } from '@angular/forms';
import { ProjectionService } from '../services/projection.service';
import { Projection } from '../models/projection';

@Component({
    selector: 'app-modifyitem',
    templateUrl: './modifyitem.component.html',
    styleUrls: ['./modifyitem.component.css']
})
/** modifyitem component*/
export class ModifyitemComponent implements OnInit {
/** modifyitem ctor */
  type: string;
  id: string;
  film: Film;
  projection: Projection;
  checkoutForm;
  constructor(
    private _Activatedroute: ActivatedRoute,
    private _filmService: FilmService,
    private _projectionService: ProjectionService,
    private formBuilder: FormBuilder
  ) {
    this.type = this._Activatedroute.snapshot.paramMap.get("type");
    this.id = this._Activatedroute.snapshot.paramMap.get("id");
    if (this.type == 'films') {
      this.checkoutForm = this.formBuilder.group({
        title: '',
        director: '',
        description: '',
        rating: ''
      });
    }
    if (this.type == 'projections') {
      this.checkoutForm = this.formBuilder.group({
        filmId: '',
        roomId: '',
        start: ''
      });

    }
    
    }
    async ngOnInit(){
      if (this.type == 'films') {
        this.film = await this._filmService.getFilmById(this.id);
      }
      if (this.type == 'projections') {
        this.projection = await this._projectionService.getProjectionById(this.id);
      }
  }

  onSubmit(changedvalue) {
    let result;
    
    if (this.type == 'films') {
      console.log('edit');
      this._filmService.editFilm(this.film.id, changedvalue).subscribe(film => result = film);
      if (result) {
        console.warn('Film mentve', result);
      }
    }
    if (this.type == 'projections') {
      this._projectionService.editProjection(this.id, changedvalue).subscribe(projection => result = projection);
      if (result) {
        console.warn('Vetítés mentve', result);
      }
    }

  }
}
