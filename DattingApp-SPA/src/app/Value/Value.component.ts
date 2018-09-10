import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-value',
  templateUrl: './Value.component.html',
  styleUrls: ['./Value.component.css']
})
export class ValueComponent implements OnInit {

  values: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getValue();
  }
  getValue() {
    this.http.get('http://localhost:5000/api/values').
    subscribe(
      Response => {this.values = Response;  },
       Error => {console.log( Error ); }
      );
  }

}