import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder} from '@angular/forms';
import { FilmService } from '../services/film.service';
import { Film } from '../models/film';
import { ProjectionService } from '../services/projection.service';
import { RoomService } from '../services/room.service';

@Component({
    selector: 'app-additem',
    templateUrl: './additem.component.html',
    styleUrls: ['./additem.component.css']
})
/** additem component*/
export class AdditemComponent implements OnInit {
/** additem ctor */
  type: string;

  checkoutForm;
  result;
  constructor(
    private _Activatedroute: ActivatedRoute,
    private formBuilder: FormBuilder,
    private _filmService: FilmService,
    private _projectionService: ProjectionService,
    private _roomService: RoomService,
    private router: Router
    ) {

    this.type = this._Activatedroute.snapshot.paramMap.get("type");
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
    if (this.type == 'rooms') {
      this.checkoutForm = this.formBuilder.group({
        capacity: ''
      });
    }
  }
  ngOnInit() {
    
  }

  onSubmit(customerData) {

    if (this.type == 'films') {
      this._filmService.addFilm(customerData).subscribe(film => this.result = film);
      if (this.result) {
        console.warn('Film mentve', this.result);
        this.result = null;
      }
    }
    if (this.type == 'projections') {
      this._projectionService.addProjection(customerData).subscribe(projection => this.result = projection);
      if (this.result) {
        console.warn('Vetítés mentve', this.result);
        this.result = null;
      }
    }
    if (this.type == 'rooms') {
      this._roomService.addRoom(customerData).subscribe(room => this.result = room);
      if (this.result) {
        console.warn('Terem mentve', this.result);
        this.result = null;
      }
    }
    this.router.navigate(['administration']);
  }
}
