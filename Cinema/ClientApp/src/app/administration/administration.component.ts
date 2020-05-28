import { Component, OnInit, Inject } from '@angular/core';
import { Film } from '../models/film';
import { Projection } from '../models/projection';
import { Order } from '../models/order';
import { FilmService } from '../services/film.service';
import { ProjectionService } from '../services/projection.service';
import { OrderService } from '../services/order.service';
import { Room } from '../models/room';
import { RoomService } from '../services/room.service';
import { ViewerService } from '../services/viewer.service';
import { Viewer } from '../models/viewer';

@Component({
    selector: 'app-administration',
    templateUrl: './administration.component.html',
    styleUrls: ['./administration.component.css']
})
/** administration component*/
export class AdministrationComponent implements OnInit {
/** administration ctor */
  selected = 'films';
  films: Film[];
  projections: Projection[];
  orders: Order[];
  rooms: Room[];
  viewers: Viewer[];

 
  constructor(
    private _filmService: FilmService,
    private _projectionService: ProjectionService,
    private _orderService: OrderService,
    private _roomService: RoomService,
    private _viewerService: ViewerService,
  )
    {
    }
    ngOnInit(): void {
        
  }
  async list(type: string) {
    switch (type) {
      case 'films':
        this.films = await this._filmService.getFilms();
        break;
      case 'projections':
        this.projections = await this._projectionService.getAllProjection();
        break;
      case 'rooms':
        this.rooms = await this._roomService.getAllRoom();
        break;
      case 'orders':
        this.orders = await this._orderService.getAllOrder();
        break;
      case 'viewers':
        this.viewers = await this._viewerService.getAllViewer();
        break;
      default:
        break;
    }
  }

  deleteFilm(id: number) {
    console.log('delete film');
    this._filmService.deleteFilm(id).subscribe();
    this.films = this.films.filter(film => film.id != id);  
  }
  deleteProjection(id: number) {
    console.log('delete projection');
    this._projectionService.deleteProjection(id).subscribe();
    this.projections = this.projections.filter(proj => proj.id != id);
  }
  deleteOrder(id: number) {
    console.log('delete order');
    this._orderService.deleteOrder(id).subscribe();
    this.orders = this.orders.filter(order => order.id != id);
  }
  deleteViewer(id: number) {
    console.log('delete viewer');
    this._viewerService.deleteViewer(id).subscribe();
    this.viewers = this.viewers.filter(viewer => viewer.id != id);
  }
  deleteRoom(id: number) {
    console.log('delete room');
    this._roomService.deleteRoom(id).subscribe();
    this.rooms = this.rooms.filter(viewer => viewer.id != id);
  }
  



}
