import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Diplome } from 'app/models/Diplome';
import { HardSkill } from 'app/models/HardSkill';
import { Poste } from 'app/models/Poste';
import { SoftSkill } from 'app/models/SoftSkill';
import { User } from 'app/models/User';




@Injectable({
  providedIn: 'root'
})
export class APIService {

   httpOptions = {
    headers : new HttpHeaders('content-type:application/json')
  }

  private posteURL: string = '';
  private userURL: string= 'https://localhost:7170/user';

  constructor(private http:HttpClient) { }

  getAllPostes():Observable<Poste[]>{
    return this.http.get<Poste[]>(this.posteURL);
  }

  getUser(id:number) : Observable<User> {
    console.log(`${this.userURL}/${id}`);
   var oui = this.http.get<User>(`${this.userURL}/${id}`, this.httpOptions);
   console.log(oui); 
   return oui;
  }

}
