import { Component, OnInit } from '@angular/core';
import { Poste } from 'app/models/Poste';
import { APIService } from 'app/services/api.service';

@Component({
  selector: 'app-job-list',
  templateUrl: './job-list.component.html',
  styleUrls: ['./job-list.component.scss']
})
export class JobListComponent implements OnInit {

  jobs !: Poste[];

  constructor(private APIservice : APIService ) { }

  ngOnInit(): void {
    this.getAllJobs();
  }

  getAllJobs() : void{
    this.APIservice.getAllPostes().subscribe(poste=>{
      console.log(poste);
      console.log(poste.job);
    });
  }

}
