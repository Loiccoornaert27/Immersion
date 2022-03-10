import { Component, OnInit } from '@angular/core';
import { Utilisateur } from 'app/models/Utilisateur';
import { APIServiceService } from 'app/services/apiservice.service';

@Component({
  selector: 'app-utilisateur-details',
  templateUrl: './utilisateur-details.component.html',
  styleUrls: ['./utilisateur-details.component.scss']
})
export class UtilisateurDetailsComponent implements OnInit {

  private user !: Utilisateur;
  private id : number =1;

  constructor(private apiservice : APIServiceService) { }

  ngOnInit(): void {
    this.getDetails();
  }

  getDetails() : void{
    this.apiservice.getUser(this.id).subscribe( user => this.user=user );
  } 

}
