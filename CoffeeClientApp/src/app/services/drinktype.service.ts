import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { DrinkType } from '../models/DrinkType';

const API_URL = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class DrinktypeService {
  constructor(private http: HttpClient) { }

  public getAllDrinktypes() {
    return this.http.get<DrinkType[]>(API_URL + '/drinktype');
  }

}
