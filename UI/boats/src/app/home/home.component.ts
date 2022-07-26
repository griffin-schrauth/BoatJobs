import { Component, OnInit } from '@angular/core';
import { NONE_TYPE } from '@angular/compiler';
import { Boat } from 'src/app/models/boat.model';
import { BoatsService } from 'src/app/service/boats.service';

@Component({ 
   
    styleUrls: ['./home.component.css'],
    templateUrl: 'home.component.html',
    
})
export class HomeComponent implements OnInit {
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

// dont know if i want the users to be ablt to delete jobs.
//should be only able to delete their own jobs
}


