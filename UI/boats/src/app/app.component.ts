import { NONE_TYPE } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Boat } from './models/boat.model';
import { BoatsService } from './service/boats.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'boats';
  jobs : Boat[] = []
  job : Boat = {
    id:'',
    name:'',
    county:'',
    state:'',
    zipcode:'',
    jobTitle:'',
    jobDesciption:'',//this is spelt desciption in sql
    date:'',
    amount: new Float32Array,

  }

  constructor(private boatsService: BoatsService){


  }

  ngOnInit(): void {
    this.getAllJobs();
  }

  getAllJobs() {
    this.boatsService.getAllJobs()
    .subscribe(
      response => {
        this.jobs = response
      }
    );
  }

  onSubmit() {
    this.boatsService.addJob(this.job)
    .subscribe(
      response => {
        this.getAllJobs();
        this.job = {
          id:'',
          name:'',
          county:'',
          state:'',
          zipcode:'',
          jobTitle:'',
          jobDesciption:'',//this is spelt desciption in sql
          date:'',
          amount: new Float32Array,
        }
      }
    );
  }


}
