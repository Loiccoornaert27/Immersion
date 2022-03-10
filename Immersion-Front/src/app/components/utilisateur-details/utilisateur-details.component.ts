import { Component, OnInit } from '@angular/core';
import { Utilisateur } from 'app/models/Utilisateur';
import { APIServiceService } from 'app/services/apiservice.service';

@Component({
  selector: 'app-utilisateur-details',
  templateUrl: './utilisateur-details.component.html',
  styleUrls: ['./utilisateur-details.component.scss']
})
export class UtilisateurDetailsComponent implements OnInit {

  user !: Utilisateur;
  private id : number =1;

  constructor(private apiservice : APIServiceService) { }

  ngOnInit(): void {
    // this.getDetails();
    this.user={id:1,nom:"Coornaert",prenom:"Loic",hardSkills:[{id:1,intitule:'Angular'},{id:5,intitule:'C#'}],softSkills:[{id:2,intitule:'cafe'}],diplomes:[{id:2,intitule:"Diplome d'ingénieur"}] };
  }

  getDetails() : void{
    this.apiservice.getUser(this.id).subscribe( user => this.user=user );
  } 

}
