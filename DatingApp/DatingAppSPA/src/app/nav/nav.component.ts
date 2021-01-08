import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  model: any = {};
  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  login(){
    this.authService.login(this.model).subscribe(
    (data: any) => {this.alertify.success("logged in sucessfully");},
    (error: any) => {this.alertify.error("loggin failed");}
    );
  }

  logout(){
    this.authService.userToken = null;
    localStorage.removeItem('token');
    this.alertify.success("logged out");
  }

  loggedIn(){
    return this.authService.loggedIn();
  }

}
