import { Component, OnInit } from '@angular/core';
import { AuthService } from '_services/auth.service';
import { AlertifyService } from '_services/alertify.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-nav',
  templateUrl: './Nav.component.html',
  styleUrls: ['./Nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
   constructor(public authser: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }
  login() {
    this.authser.login(this.model)
      .subscribe( Response => {
        this.alertify.success( 'u have been logged');
      }, error => { this.alertify.error(error); }, () => {this.router.navigate(['/members']); } );
  }
  verifyLoggedIn() {
     return this.authser.LogedIn();
  }
  logout() {
    localStorage.removeItem('token');
    this.alertify.message('log out');
    this.router.navigate(['/home']);
  }

}
