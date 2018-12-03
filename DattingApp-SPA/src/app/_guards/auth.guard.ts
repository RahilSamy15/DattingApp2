import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '_services/auth.service';
import { AlertifyService } from '_services/alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authser: AuthService , private alertify: AlertifyService , private router: Router) {}
  canActivate(): boolean {
    if (this.authser.LogedIn()) {
     return true;
    }

  this.alertify.error('you cant access to the page ');
  this.router.navigate(['/home']);
  return false;


  }
}
