import { Component, OnInit } from '@angular/core';
import { Poste } from 'app/models/Poste';
import { APIService } from 'app/services/api.service';

@Component({
  selector: 'app-poste-details',
  templateUrl: './poste-details.component.html',
  styleUrls: ['./poste-details.component.scss']
})
export class PosteDetailsComponent implements OnInit {

  poste !: Poste;
  
  constructor(private apiservice:APIService) { }

  ngOnInit(): void {
  }

}
