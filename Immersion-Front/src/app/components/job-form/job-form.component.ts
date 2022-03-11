import { Component, OnInit } from '@angular/core';
import { APIService } from 'app/services/api.service';

@Component({
  selector: 'app-job-form',
  templateUrl: './job-form.component.html',
  styleUrls: ['./job-form.component.scss']
})
export class JobFormComponent implements OnInit {

  constructor(private apiservice : APIService) { }

  ngOnInit(): void {
  }

  add(jobName : string, jobDescription : string):void{

  }
}
