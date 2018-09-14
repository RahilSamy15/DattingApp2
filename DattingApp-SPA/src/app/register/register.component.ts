import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '_services/auth.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Output() cancelRegister = new EventEmitter() ;
  model: any = {}; constructor(private authser: AuthService) { }

  ngOnInit() {
  }
  register() {
    this.authser.register(this.model).subscribe(() => console.log('u have been sucessfuly registerd '), error => console.log(error) ) ;
    console.log(this.model);
  }
  cancel() {
    this.cancelRegister.emit(false);
    console.log('cancelled');

  }

}
