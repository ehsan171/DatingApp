import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpEvent, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { Screenplay } from '../_models/screenplay';
import { Person } from '../_models/person';
import { BasicData } from '../_models/basicData';
import { Episode } from '../_models/episode';
import { ScreenplayFormat } from '../_models/screenplayFormat';
import { ScreenplayStatus } from '../_models/screenplayStatus';

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer' + localStorage.getItem('token')
  })

};

@Injectable({
  providedIn: 'root'
})
export class ScreenplayService {
  // baseUrl = environment.apiUrl;
  baseUrl = 'http://localhost:5000/api/';

constructor(
  private http: HttpClient,
  private httpClient: HttpClient
  ) { }

getScreenplays(): Observable<Screenplay[]> {
  return this.http.get<Screenplay[]>(this.baseUrl + 'screenplay', httpOptions);
}
getScreenplay(id): Observable<Screenplay[]> {
  return this.http.get<Screenplay[]>(this.baseUrl + 'screenplay/' + id, httpOptions);
}

getEpisode(screenplayId): Observable<Episode[]> {
  return this.http.get<Episode[]>(this.baseUrl + 'screenplay/episode/' + screenplayId, httpOptions);
}

getPersons(): Observable<Person[]> {
  return this.http.get<Person[]>(this.baseUrl + 'Person', httpOptions);
}
getFormats(): Observable<BasicData[]> {
  return this.http.get<BasicData[]>(this.baseUrl + 'Basicdata/formats', httpOptions);
}
getConcepts(): Observable<BasicData[]> {
  return this.http.get<BasicData[]>(this.baseUrl + 'Basicdata/concepts', httpOptions);
}
getFormatNumbers(): Observable<ScreenplayFormat[]> {
  return this.http.get<ScreenplayFormat[]>(this.baseUrl + 'screenplay/formatReport', httpOptions);
}
getStatusNumbers(): Observable<ScreenplayStatus[]> {
  return this.http.get<ScreenplayStatus[]>(this.baseUrl + 'screenplay/statusReport', httpOptions);
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

episodeRegister(model: any, screenplayId){
  return this.http.post(this.baseUrl + 'screenplay/' + screenplayId + '/Episode/register', model);
}

public downloadFile(file: string): Observable<HttpEvent<Blob>> {
  return this.httpClient.request(new HttpRequest(
    'GET',
    `${'http://localhost:5000/api/episode/upload/download2'}?file=${file}`,
    null,
    {
      reportProgress: true,
      responseType: 'blob'
    }));
}



}
