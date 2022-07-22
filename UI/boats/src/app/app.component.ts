import { Component, OnInit } from '@angular/core';
import { BoatsService } from './service/boats.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'boats';

  constructor(private boatsService: BoatsService){


  }

  ngOnInit(): void {
    this.getAllBoats();
  }

  getAllBoats() {
    this.boatsService.getAllBoats()
    .subscribe(
      response => {
        console.log(response)
      }
    )
  }

}
