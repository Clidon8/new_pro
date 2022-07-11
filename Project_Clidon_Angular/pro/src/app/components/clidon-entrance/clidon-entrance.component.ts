import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { numbers } from '@material/dialog';
import { User } from 'src/app/Models/user';
import { UserServiceService } from 'src/app/Services/user-service.service';

@Component({
  selector: 'clidon-entrance',
  templateUrl: './clidon-entrance.component.html',
  styleUrls: ['./clidon-entrance.component.css']
})
export class ClidonEntranceComponent implements OnInit {
  flag:boolean=false
  user:User=new User();
  FirstName!:string;
  LastName!:string;
  fullName!:string;
  password!:string;
  temp!:boolean;
  code!:string;
  loading:boolean=true;
  constructor(private router:Router,private userSrvice:UserServiceService) { }

  ngOnInit(): void {
  }
  GoToclidonTypedPage(){
  this.router.navigate(['clidon-typed-page']);
  }
  GoToclidonChangeUserPassword()
  {
    this.router.navigate(['clidon-change-user-password']);
  }
  IsName(fname:string,lname:string){
    this.userSrvice.IsName(fname,lname).subscribe(p=>{
      this.user.firstName==fname && this.user.lastName==lname
      if(p)
      {
      return true
      }
    return false
    })
    }
  LOGIN(password:string,lname:string,fname:string)
  {
    this.loading=true;
    this.userSrvice.LOGIN(password,lname,fname).subscribe(p=>{
       this.user.password && this.user.firstName && this.user.firstName
       var str = p+" ";
       var splitted = str.split(" ", 5);
       console.log(splitted)
      //  alert(splitted+"0:"+splitted[0])
       this.code= splitted[0]
      if(p && splitted[0]!="no")
      {
         if(splitted[4]=="True")
         {
          this.loading=false;
          console.log("מנהל יקר ברוכים הבאים ");
          this.router.navigate(['clidon-management-operations']);
         }
         else if(splitted[1]==password && splitted[2]==lname && splitted[3]==fname)
         {
          this.flag=false;
          console.log(" ברוכים הבאים "+splitted[2]+" "+splitted[3]);
          this.router.navigate(['clidon-payment']);
          //איזור אישי
          // this.router.navigate(['clidon-typed-page']);
         }
       }
       else
       {
       //אם לא קיים תחזור לדף הבית
       this.flag=false;
       console.log(" אינך קיים במערכת");
         this.router.navigate(['clidon-sing-in']);
       }

    })
  }
  isSignIn(fname:string,lname:string){
  //אם המשתמש קיים במערכת שיכנס לאיזור האישי אחרת שילך לדף התחברות
  this.userSrvice.isSignIn(this.password).subscribe(p=>
  {
    this.user.password
    //אם קיימת כזו סיסמא
   //קישור לאיזור האישי(אם הצליח להוסיף את המשתמש
     if(p)
     {
      console.log("hello")
      var str = p+",";
      var splitted = str.split(",", 2);
      this.code= splitted[0]
       if(splitted[1]==this.password)
       {
        console.log("מנהל יקר ברוכים הבאים ");
        this.router.navigate(['clidon-management-operations']);
       }
       else
       {
        var str = p+",";
        var splitted = str.split(",", 3);
        console.log(" ברוכים הבאים "+splitted[1]+" "+splitted[2]);
        this.router.navigate(['clidon-payment']);
        //איזור אישי
        // this.router.navigate(['clidon-typed-page']);
       }
     }
     else
     {
     //אם לא קיים תחזור לדף הבית
     console.log(" אינך קיים במערכת");
       this.router.navigate(['clidon-sing-in']);
     }
    })
  }

}
