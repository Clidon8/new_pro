import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/user';
// import { NewhelloComponent } from 'src/app/components/newhello/newhello.component';
import { UserServiceService } from 'src/app/Services/user-service.service';
import { DeletUserComponent } from '../delet-user/delet-user.component';
import { NewhelloComponent } from '../newhello/newhello.component';
import { UpdateFirstNameComponent } from '../update-first-name/update-first-name.component';
import { UpdateLastnameComponent } from '../update-lastname/update-lastname.component';
import { UpdatePasswordComponent } from '../update-password/update-password.component';

export interface DialogData {
  newdata: string;
  name:string;
  codeuse:number;
  WhatCha:string;
}
@Component({
  selector: 'clidon-user-table',
  templateUrl: './clidon-user-table.component.html',
  styleUrls: ['./clidon-user-table.component.css']
})
export class ClidonUserTableComponent implements OnInit {
  newdata!:string
  name!:string
  codeuse!:number
  WhatCha!:string


  constructor(private router:Router,private userSrvice:UserServiceService,public dialog: MatDialog) {
    this.alluser();
  }

  user:User=new User();
  ngOnInit(): void {
   }
   openDialoglastname(codeuser:number,WhatChange:string,d:string): void {
    const dialogRef = this.dialog.open(UpdateLastnameComponent, {
      width: '250px',
      //newdata-המידע החדש שרוצים להכניס
      data: {name: d, newdata: this.newdata,codeuse: codeuser,WhatCha: WhatChange},
    });
    dialogRef.afterClosed().subscribe((result: string) => {
      // console.log('The dialog was closed');
      this.newdata = result;
    });
}
openDialogfirstName(codeuser:number,WhatChange:string,d:string): void {
  const dialogRef = this.dialog.open(UpdateFirstNameComponent, {
    width: '250px',
    //newdata-המידע החדש שרוצים להכניס
    data: {name: d, newdata: this.newdata,codeuse: codeuser,WhatCha: WhatChange},
  });
  dialogRef.afterClosed().subscribe((result: string) => {
    // console.log('The dialog was closed');
    this.newdata = result;
  });
}
openDialogpassword(codeuser:number,WhatChange:string,d:string): void {
  const dialogRef = this.dialog.open(UpdatePasswordComponent, {
    width: '250px',
    //newdata-המידע החדש שרוצים להכניס
    data: {name: d, newdata: this.newdata,codeuse: codeuser,WhatCha: WhatChange},
  });
  dialogRef.afterClosed().subscribe((result: string) => {
    // console.log('The dialog was closed');
    this.newdata = result;
  });
}
openDialogDELET(codeuser:number,d:string): void {
  const dialogRef = this.dialog.open(DeletUserComponent, {
    width: '250px',
    //newdata-המידע החדש שרוצים להכניס
    data: {name: d, newdata: this.newdata,codeuse: codeuser},
  });
  dialogRef.afterClosed().subscribe((result: string) => {
    // console.log('The dialog was closed');
    this.newdata = result;
  });
}
   u:User[]=[]
   Delet(codeuser:number){
    //  alert(codeuser)
     //מחיקת משתמש
      this.userSrvice.Delet(codeuser).subscribe(c=>{
        this.user.code=c
        if(c!=null){
          console.log('  פעולת המחיקה הצליחה')
        }
      })
   }
  public UpdateUser1(codeuser:number,WhatChange:string,DataChange:string){
    //  alert("code: "+codeuser+"  WhatChange: "+WhatChange+"  DataChange: "+DataChange)
     this.userSrvice.UpdateUser1(codeuser,WhatChange,DataChange).subscribe(codeuser=>{
       this.user.code==codeuser
       if(!codeuser){
       }
       console.log('פעולת העדכון הצליחה')
     })
   }
   Updatefirstname(fname:string){
    // alert(fname)
  }
  Updatelastname(lname:string){
    // alert(lname)
  }
  Updatepass(p:string){
    // alert(p)
  }
  deletuser(c:number){
    // alert(c)
  }
   alluser(){
    this.userSrvice.AllUser().subscribe(l=>{
      this.u=l
      if(l==null)
      {
        alert('אין נתונים')
      }
      else
      {
        console.log(this.u)
      }
    });

   }
}
