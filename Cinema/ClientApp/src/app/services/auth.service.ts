import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthService {
  baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }


  async checkUserPassword(username: string, password: string): Promise<LoginStatus>{

    return await this.http.get<LoginStatus>(this.baseUrl + 'auth/' + username + '/' + password).toPromise();

  }
  public isAuthenticated(): boolean{
    let item = sessionStorage.getItem('loggedIn');
    if (item == 'true') {
      return true;
    }
    else {
      return false;
    }
  }
}
export interface LoginStatus {
  loggedIn: boolean;
  userId: number;
}
