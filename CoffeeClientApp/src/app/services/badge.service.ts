import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

const API_URL = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class BadgeService {

  constructor(private http: HttpClient) { }

  public getOwner(badgeNumber){
    return this.http.get(API_URL + '/badge/GetOnwer/' + badgeNumber, { responseType: 'text' });
  }
}
