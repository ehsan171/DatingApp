import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class UserService {
  // baseUrl = environment.apiUrl;
  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

getUsers(): Observable<User[]> {
  return this.http.get<User[]>(this.baseUrl + 'tusers', httpOptions);
}
getUser(id): Observable<User> {
  return this.http.get<User>(this.baseUrl + 'users/' + id, httpOptions);
}
test(): Observable<any>{
  return this.http.get<any>(this.baseUrl + 'EmployeeProject/' , httpOptions);
}

}
