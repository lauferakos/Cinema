import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OrderService } from '../services/order.service';
import { Order } from '../models/order';

@Component({
    selector: 'app-order-list',
    templateUrl: './order-list.component.html',
    styleUrls: ['./order-list.component.css']
})
/** order-list component*/
export class OrderListComponent implements OnInit {
/** order-list ctor */
  viewerId: string;
  userid: string;
  orders: Order[];
  constructor(private _Activatedroute: ActivatedRoute, private _orderService: OrderService) {

    this.userid = sessionStorage.getItem('id');
    if (!this.userid) {
      this.userid = '0';
    }
    }
    async ngOnInit(){
      this.viewerId = this._Activatedroute.snapshot.paramMap.get("viewerId");
      this.orders = await this._orderService.getOrders(this.viewerId);
    }
}
