import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ClientSelection } from '../models/ClientSelection';
import { environment } from 'src/environments/environment';
import { retry, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

const API_URL = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class ClientSelectionService {
  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };

  public getClientSelection(badgeNumber) {
    return this.http.get<ClientSelection>(API_URL + '/ClientSelection/GetClientSelection/' + badgeNumber)
    .pipe(
      catchError((err) => {
        console.log('error caught in service');
        console.error(err);
        return throwError(err);
      })
    );
  }

  public SaveClientSelection(clientSelection: ClientSelection){
    const headers = { 'content-type': 'application/json'};
    const body = JSON.stringify(clientSelection);
    console.log(body);
    console.log('address : ' + API_URL + '/ClientSelection/');
    return this.http.post(API_URL + '/ClientSelection/', body, {headers});
  }

  public UpdateClientSelection(clientSelection: ClientSelection){
    const headers = { 'content-type': 'application/json'};
    const body = JSON.stringify(clientSelection);
    console.log(body);
    console.log('address : ' + API_URL + '/ClientSelection/');
    return this.http.put(API_URL + '/ClientSelection/', body, {headers});
  }
}
