import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/user';
import { UserServiceService } from 'src/app/Services/user-service.service';

@Component({
  selector: 'clidon-is-manager',
  templateUrl: './clidon-is-manager.component.html',
  styleUrls: ['./clidon-is-manager.component.css']
})
export class ClidonIsManagerComponent implements OnInit {
 ismeneger!:boolean;
 password!:string;
 firstname!:string;
 lastname!:string;
 user:User=new User();
 code!:string
  constructor(private router:Router, private userSrvice:UserServiceService ) { }

  isfalse()
  {
     return this.ismeneger=false;
  }
  meneger()
  {
     this.ismeneger=true
  }
  nomeneger(){
   this.ismeneger=false;
  }
  UpdetIsMeneger1(password:string,firstname:string,lastname:string){
    // alert("p: "+password+" f: "+firstname+" l: "+lastname)
  this.userSrvice.UpdetIsMeneger1(this.ismeneger,password,firstname,lastname).subscribe(p=>{
    this.user.password && this.user.firstName && this.user.lastName
    var str = p+",";
    var splitted = str.split(",", 4);
    this.code= splitted[0]
    if(splitted[0]=="True")
    {
      console.log("השינוי התבצע בהצלחה");
    }
    else
    {
      console.log("ישנה בעיה בשינוי")
    }
  })
  }
  UpdetIsMeneger(password:string,lastname:string,firstname:string){
    this.userSrvice.UpdetIsMeneger(this.ismeneger,password,lastname,firstname).subscribe(p=>{
      this.user.password===password
      && this.user.lastName==lastname&&
      this.user.firstName==firstname
      if(p)
      {
        console.log("השינוי התבצע בהצלחה");
      }
      else{
        console.log("ישנה בעיה בשינוי")
      }
    })


  }
  ngOnInit(): void {
  }

}
