import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/user';
import { UserServiceService } from 'src/app/Services/user-service.service';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'clidon-change-manager-password',
  templateUrl: './clidon-change-manager-password.component.html',
  styleUrls: ['./clidon-change-manager-password.component.css']
})
export class ClidonChangeManagerPasswordComponent implements OnInit {
  formData!:FormGroup;
  Password!:FormControl;
  user:User=new User();
  fileName !:string;
  firstname!:string;
  lastname!:string;
  password!:string;
  passwordold!:string;
  passwordnew!:string;
  code!:string;
  constructor(private router:Router, private userSrvice:UserServiceService) { }
  //ולידציות
  ngOnInit(): void {
    this.Password= new FormControl("",[Validators.required,Validators.maxLength(8),Validators.minLength(4)]),
    this.formData=new FormGroup({
      Password:this.Password
    })
  }
  //פונקציה שמשנה למנהל סיסמא אם שכח
  CodeUser(lastName:string,firstName:string,passwordnew:string){
   // alert("l: "+lastName+" f: "+firstName+" p: "+passwordnew)
    this.userSrvice.CodeUser(lastName,firstName,passwordnew).subscribe(p=>{
      this.user.lastName==lastName
      && this.user.firstName==firstName
      this.user.password && this.user.firstName && this.user.firstName
      var str = p+",";
      var splitted = str.split(",", 3);
      console.log(splitted);
      console.log("p:"+p)
      this.code= splitted[1]
     if(p && splitted[0]=="True" && splitted[2]=="True")
     {
      alert("הסיסמא התעדכנה בהצלחה")
     }
     else if(splitted[2]!="True")
     {
      alert(" אינך מנהל")
     }
    })
  }
  ChangePassword(paold:string,panew:string){
    this.userSrvice.ChangePassword(this.passwordold,this.passwordnew).subscribe(p=>{
       this.user.password===this.passwordold
       alert(this.user.code)
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
}
