import { HttpClient, HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'https://localhost:44375/api/auth'
  userToken: any;
constructor(private http:HttpClient) { }


login(model: any){
  const headers = new HttpHeaders({'Content-type': 'application/json'});

  return this.http.post(this.baseUrl+ '/login',model,{headers: headers}).pipe(map((user: any) =>{
    if(user){
      localStorage.setItem("token", user.tokenString);
      this.userToken = user.tokenString;
    }

  }));
}

register(model:any){
  const headers = new HttpHeaders({'Content-type': 'application/json'});

  return this.http.post(this.baseUrl+ '/register',model,{headers: headers})
}

}
