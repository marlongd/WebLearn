import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};

  
  @Output() registerCancel = new EventEmitter();
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  register(){
    this.authService.register(this.model).subscribe(
      () => {console.log("Registered sucessfully");},
      error=> {console.log("Register failed");}
    )
  }

  cancel(){
    this.registerCancel.emit(false);
  }

}
