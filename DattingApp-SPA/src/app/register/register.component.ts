import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '_services/auth.service';
import { AlertifyService } from '_services/alertify.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelModel = new EventEmitter();
  @Output() cancelRegister = new EventEmitter() ;
  model: any = {}; constructor(private authser: AuthService, private alertirfy: AlertifyService) { }

  ngOnInit() {
  }
  register() {
    this.authser.register(this.model).subscribe(
      () => this.alertirfy.success('u have been sucessfuly registerd '), error => this.alertirfy.error(error) ) ;
    console.log(this.model);
  }
  cancel() {
    /*this.cancelRegister.emit(false);*/
    this.cancelModel.emit(false);
    console.log('cancelled');

  }

}
