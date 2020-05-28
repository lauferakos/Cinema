import { Component, Inject } from '@angular/core';
import { Order } from '../models/order';
import { OrderService } from '../services/order.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-basket-list',
    templateUrl: './basket-list.component.html',
    styleUrls: ['./basket-list.component.css']
})
/** basket-list component*/
export class BasketListComponent {
/** basket-list ctor */
  orders: Order[];
  fullprice: number;

  constructor(private _orderService: OrderService, private router: Router) {
    this.listOrdersInBasket();
  }

  listOrdersInBasket() {
    let keys = Object.keys(localStorage);
    let i = keys.length;
    
    this.orders = [];
    while (i--) {
      this.orders.push(JSON.parse(localStorage.getItem(keys[i])));
    }
    this.fullprice = 0;
    for (var j = 0; j < this.orders.length; j++) {
      this.fullprice += this.orders[j].price;
    }
 
  }

  cancelOrder(key: number) {
    let item: Order;
    item = JSON.parse(localStorage.getItem(key.toString()));
    this.fullprice -= item.price; 
    localStorage.removeItem(key.toString());
    this.orders = this.orders.filter(o => o.projectionId != key);
  }

  acceptOrder() {
    for (var i = 0; i < this.orders.length; i++) {
      this._orderService.addOrder(this.orders[i]).subscribe();
      this._orderService.reserveSeat(this.orders[i].projectionId, this.orders[i].viewerId, this.orders[i].reservedSeats).subscribe();
       
    }
    localStorage.clear();
    let viewerid = sessionStorage.getItem('id');
      this.router.navigate(['order/', viewerid]);
  }
}
