import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order } from '../models/order';
import { Observable } from 'rxjs';
import { Seat } from '../models/seat';

@Injectable()
export class OrderService {
  baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  async getOrders(viewerId: string): Promise<Order[]> {
    let getOrdersUrl = this.baseUrl + 'order/' + viewerId;
    return await this.http.get<Order[]>(getOrdersUrl).toPromise();
  }

  async getAllOrder(): Promise<Order[]> {
    let getAllOrderUrl = this.baseUrl + 'order';
    return await this.http.get<Order[]>(getAllOrderUrl).toPromise();
  }
  deleteOrder(id:number): Observable<Order> {
    let deleteOrderUrl = this.baseUrl + 'order/delete/' + id;
    return this.http.delete<Order>(deleteOrderUrl);
  }

  addOrder(order: Order): Observable<Order> {
    let addOrderUrl = this.baseUrl + 'order';
    return this.http.post<Order>(addOrderUrl, order);
  }
  reserveSeat(projectionId: number, viewerId: number, reservedSeats:number): Observable<Boolean> {
    let reserveSeatUrl = this.baseUrl + 'seatreservation/reserve/' + projectionId + '/' + viewerId + '/' + reservedSeats;   
    return this.http.post<Boolean>(reserveSeatUrl, {});
  }
}
