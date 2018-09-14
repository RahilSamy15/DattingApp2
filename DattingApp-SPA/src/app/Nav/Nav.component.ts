import { Component, OnInit } from '@angular/core';
import { AuthService } from '_services/auth.service';


@Component({
  selector: 'app-nav',
  templateUrl: './Nav.component.html',
  styleUrls: ['./Nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
   constructor(private authser: AuthService) { }

  ngOnInit() {
  }
  login() {
    this.authser.login(this.model)
      .subscribe( Response => {
        console.log( 'u have been logged');
      }, error => { console.log('error on login'); } );
  }
  verifyLoggedIn() {
     return !!localStorage.getItem('token');
  }
  logout() {
    localStorage.removeItem('token');
    console.log('log out');
  }

}
