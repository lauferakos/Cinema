import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Room } from '../models/room';
import { Observable } from 'rxjs';

@Injectable()
export class RoomService {
  baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  async getAllRoom(): Promise<Room[]> {
    let getAllRoomUrl = this.baseUrl + 'room';
    return await this.http.get<Room[]>(getAllRoomUrl).toPromise();
  }
  addRoom(room: Room): Observable<Room> {
    let addRoomUrl = this.baseUrl + 'room';
    return this.http.post<Room>(addRoomUrl, room);
  }
  deleteRoom(id: number): Observable<Room> {
    let deleteRoomUrl = this.baseUrl + 'room/delete/' + id;
    return this.http.delete<Room>(deleteRoomUrl);
  }
}
