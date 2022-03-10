import { Component, OnInit } from '@angular/core';
import { Poste } from 'app/models/Poste';
import { APIServiceService } from 'app/services/apiservice.service';

@Component({
  selector: 'app-poste-details',
  templateUrl: './poste-details.component.html',
  styleUrls: ['./poste-details.component.scss']
})
export class PosteDetailsComponent implements OnInit {

  poste !: Poste;
  
  constructor(private apiservice:APIServiceService) { }

  ngOnInit(): void {
  }

}
