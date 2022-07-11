import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/user';
import { UserServiceService } from 'src/app/Services/user-service.service';
@Component({
  selector: 'clidon-change-user-password',
  templateUrl: './clidon-change-user-password.component.html',
  styleUrls: ['./clidon-change-user-password.component.css']
})
export class ClidonChangeUserPasswordComponent implements OnInit {
password!:string;
passwordold!:string;
passwordnew!:string;
code!:string;
user:User=new User();
  constructor(private router:Router, private userSrvice:UserServiceService ) { }
  CodeUser(lastName:string,firstName:string,passwordnew:string){
   // alert("l: "+lastName+" f: "+firstName+" p: "+passwordnew)
    this.userSrvice.CodeUser(lastName,firstName,passwordnew).subscribe(p=>{
      this.user.lastName==lastName
      && this.user.firstName==firstName
      this.user.password && this.user.firstName && this.user.firstName
      var str = p+",";
      var splitted = str.split(",", 2);
      // console.log(splitted);
      // console.log("p:"+p)
      this.code= splitted[1]
     if(p && splitted[0]=="True")
     {
      console.log("הסיסמא התעדכנה בהצלחה")
     }
     else
     {
      console.log(" אינך קיים במערכת")
     }
    })
  }
  ChangePassword(paold:string,panew:string){
   this.userSrvice.ChangePassword(this.passwordold,this.passwordnew).subscribe(p=>{
      this.user.password===this.passwordold
    if(p==1)
    {
      console.log("הסיסמא התעדכנה בהצלחה")
    }
    else if(p==0)
    {
      console.log("הסיסמא  החדשה קימת כבר במערכת")
    }
    else if(p==-1)
    {
      console.log("אינך קיים במערכת")
    }
   })
  }
  ngOnInit(): void {
  }
}
