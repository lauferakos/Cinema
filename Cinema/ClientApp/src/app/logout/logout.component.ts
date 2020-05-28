import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-logout',
    templateUrl: './logout.component.html',
    styleUrls: ['./logout.component.css']
})
/** logout component*/
export class LogoutComponent {
    /** logout ctor */
  constructor(private router: Router) {
    sessionStorage.clear();
    localStorage.clear();
    this.router.navigate(['login']);

    }
}
