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
    this.getDetails(6);
  }

  getDetails(id:number):void{
    this.apiservice.getAJob(id).subscribe(job=>{
      this.poste=job.job;
    });
  }

  delete(poste : Poste):void{
    this.apiservice.deleteAJob(poste.id).subscribe();
    window.location.reload();
  }

}
