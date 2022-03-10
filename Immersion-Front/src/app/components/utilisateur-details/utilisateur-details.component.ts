import { Component, OnInit } from '@angular/core';
import { User } from 'app/models/User';

import { APIService } from 'app/services/api.service';

@Component({
  selector: 'app-utilisateur-details',
  templateUrl: './utilisateur-details.component.html',
  styleUrls: ['./utilisateur-details.component.scss']
})
export class UtilisateurDetailsComponent implements OnInit {

  user !: User;
  private id : number =1;

  constructor(private apiservice : APIService) { }

  ngOnInit(): void {
    this.getDetails();
    
  }

  getDetails() : void{
    this.apiservice.getUser(this.id).subscribe( user => {
      this.user=user;
      console.log(user.firstName);
    } );
  } 

}
