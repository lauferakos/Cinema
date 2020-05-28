import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { AuthService, LoginStatus } from '../services/auth.service';
import { ViewerService } from '../services/viewer.service';
import { Viewer } from '../models/viewer';
import { Router } from '@angular/router';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
/** login component*/
export class LoginComponent implements OnInit {
/** login ctor */
  checkoutForm;
  username: string;
  password: string;
  viewers: Viewer[];
  status: LoginStatus;
  constructor(
    private formBuilder: FormBuilder,
    private auth: AuthService,
    private _viewerService: ViewerService,
    private router: Router
   ) {

    this.checkoutForm = this.formBuilder.group({
      name: '',
      password:''
    });
  }
    async ngOnInit() {

      this.viewers = await this._viewerService.getAllViewer();
    }


  async onSubmit(data) {
    console.log('Belépés');
 
    this.username = this.checkoutForm.value.name;
    this.password = this.checkoutForm.value.password;

    
    this.status = await this.auth.checkUserPassword(this.username, this.password);


    if (this.status) {
      sessionStorage.setItem('loggedIn', String(this.status.loggedIn));
      sessionStorage.setItem('id', this.status.userId.toString());
    }
    else {
      sessionStorage.setItem('loggedIn', 'false');
      sessionStorage.removeItem('id');
    }

    this.router.navigate(['']);
  }

}
