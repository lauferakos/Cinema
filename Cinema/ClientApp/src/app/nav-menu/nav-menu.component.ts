import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  userid: string;
  isExpanded = false;

  constructor(private router:Router) {
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  ShowBasket() {
    this.userid = sessionStorage.getItem('id');
    if (this.userid) {
      this.router.navigate(['basket/', this.userid]);
    }
  }
  ShowReservation() {
    this.userid = sessionStorage.getItem('id');
    if (this.userid) {
      this.router.navigate(['order/', this.userid]);
    }
  }
}
