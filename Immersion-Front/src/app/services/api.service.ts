import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Diplome } from 'app/models/Diplome';
import { HardSkill } from 'app/models/HardSkill';
import { Poste } from 'app/models/Poste';
import { SoftSkill } from 'app/models/SoftSkill';
import { Utilisateur } from 'app/models/Utilisateur';

@Injectable({
  providedIn: 'root'
})
export class APIService {

  private posteURL: string = '';
  private userURL: string= '';

  constructor(private http:HttpClient) { }

  getAllPostes():Observable<Poste[]>{
    return this.http.get<Poste[]>(this.posteURL);
  }

  getUser(id:number) : Observable<Utilisateur> {
    return this.http.get<Utilisateur>(`${this.userURL}/${id}`);
  }

}
