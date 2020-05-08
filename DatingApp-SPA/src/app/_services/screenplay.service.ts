import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { Screenplay } from '../_models/screenplay';
import { Person } from '../_models/person';
import { BasicData } from '../_models/basicData';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer' + localStorage.getItem('token')
  })
};

@Injectable({
  providedIn: 'root'
})
export class ScreenplayService {
  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

getScreenplays(): Observable<Screenplay[]> {
  return this.http.get<Screenplay[]>(this.baseUrl + 'screenplay', httpOptions);
}
getScreenplay(id): Observable<Screenplay[]> {
  return this.http.get<Screenplay[]>(this.baseUrl + 'screenplay/' + id, httpOptions);
}

getPersons(): Observable<Person[]> {
  return this.http.get<Person[]>(this.baseUrl + 'Person', httpOptions);
}
getFormats(): Observable<BasicData[]> {
  return this.http.get<BasicData[]>(this.baseUrl + 'Basicdata/formats', httpOptions);
}
getStatuses(): Observable<BasicData[]> {
  return this.http.get<BasicData[]>(this.baseUrl + 'Basicdata/statuses', httpOptions);
}
getGenres(): Observable<BasicData[]> {
  return this.http.get<BasicData[]>(this.baseUrl + 'Basicdata/genres', httpOptions);
}

register(model: any){
  
  return this.http.post(this.baseUrl + 'screenplay/register', model);
}

}
