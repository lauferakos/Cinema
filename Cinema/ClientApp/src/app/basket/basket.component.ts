import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Order } from '../models/order';

@Component({
    selector: 'app-basket',
    templateUrl: './basket.component.html',
    styleUrls: ['./basket.component.css']
})
/** basket component*/
export class BasketComponent {
/** basket ctor */
  jegyek: number;
  viewerid: string;
  projectionid: string;
  constructor(private _Activatedroute: ActivatedRoute, public router: Router) {
    this.jegyek = 1;
    this.viewerid = this._Activatedroute.snapshot.paramMap.get("viewerid");
    this.projectionid = this._Activatedroute.snapshot.paramMap.get("projectionid");
  }
  inc() {
    this.jegyek += 1;
  }
  dec() {
    if (this.jegyek > 0) {
      this.jegyek -= 1;
    }
  }
  addToBasket() {
    const order: Order = {
      projectionId: Number(this.projectionid),
      viewerId: Number(this.viewerid),
      reservedSeats: this.jegyek,
      price: this.jegyek * 1000
    };


    try {
      localStorage.setItem(this.projectionid, JSON.stringify(order));
    } catch (e) {
      console.error('Error saving to localStorage', e);
    }
    this.router.navigate(['film']);
  }
}
