import { Component, Inject, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/user';
import { UserServiceService } from 'src/app/Services/user-service.service';
import { DialogData } from '../user-management/user-management.component';
@Component({
  selector: 'update-lastname',
  templateUrl: './update-lastname.component.html',
  styleUrls: ['./update-lastname.component.css']
})
export class UpdateLastnameComponent implements OnInit {
  user:User=new User;
  constructor(
    public dialogRef: MatDialogRef<UpdateLastnameComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private router:Router,private userSrvice:UserServiceService,
  ) {}

  //מקבל את השם משפחה החדש ומדפיס אותו
  lastname(lname:string){
    alert("hello"+lname +"code:"+this.data.codeuse)
    this.dialogRef.close();
    this.UpdateUser1(this.data.codeuse,'lastname',lname)
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
  ngOnInit(): void {
  }
  UpdateUser1(codeuser:number,WhatChange:string,DataChange:string){
   // alert("code: "+codeuser+"  WhatChange: "+WhatChange+"  DataChange: "+DataChange)
    this.userSrvice.UpdateUser1(codeuser,WhatChange,DataChange).subscribe(codeuser=>{
      this.user.code==codeuser
      if(!codeuser){
      }
      console.log('פעולת העדכון הצליחה')
    })
  }
 }
