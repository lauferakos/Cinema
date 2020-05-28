import { Component, Inject } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ViewerService } from '../services/viewer.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
/** register component*/
export class RegisterComponent {
/** register ctor */
  checkoutForm;
  constructor(private formBuilder: FormBuilder,
    private _viewerService: ViewerService,
    private router: Router) {
      this.checkoutForm = this.formBuilder.group({
        name: '',
        password: ''
      });
  }

  onSubmit(data) {
    this._viewerService.addViewer(data).subscribe();
    this.router.navigate(['login']);
  }
}
