import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'clidon-home',
  templateUrl: './clidon-home.component.html',
  styleUrls: ['./clidon-home.component.css']
})
export class ClidonHomeComponent implements OnInit {

  constructor(private router:Router) { }
is1=false;
is2=false;
is3=false;
is4=false;
i=4;
  ngOnInit(): void {
  }
  GoToSingIn(){
    this.router.navigate(['clidon-sing-in']);
    this.is1=true;
      if(this.is2||this.is3||this.is4)
      this.is1=false;
      this.i=1;

  }
  // GoToManagerPassword(){
  //   this.router.navigate(['clidon-manager-password']);
  //   this.is2=true;
  //   // if(!this.is1||!this.is3||!this.is4)
  //   // this.is2=false;

  //   this.i=2

  // }
  GoToEntrance(){
    this.router.navigate(['clidon-entrance']);
    this.is3=true;
    // if(!this.is2||!this.is1||!this.is4)
    // this.is3=false;
    this.i=3;
  }
  GoToHome()
  {
    this.router.navigate(['child-home-page']);
    this.is4=true;
    //  if(this.is2||this.is3||this.is1)
    //  this.is4=false;
    this.i=4;
  }
}
