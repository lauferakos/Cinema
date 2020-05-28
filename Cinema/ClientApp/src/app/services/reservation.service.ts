import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Reservation } from '../models/reservation';

@Injectable()
export class ReservationService {
  baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  async getReservations(viewerid: string): Promise<Reservation[]>{
    let getReservationsUrl = this.baseUrl + 'seatreservation/' + viewerid;
    return await this.http.get<Reservation[]>(getReservationsUrl).toPromise();
  }

}
