import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from '_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  helper = new JwtHelperService();
  constructor(private authser: AuthService) {}
  ngOnInit() {
  const token = localStorage.getItem('token');
  if (token) {
  this.authser.decodedToken = this.helper.decodeToken(token);
  }

  }
}
