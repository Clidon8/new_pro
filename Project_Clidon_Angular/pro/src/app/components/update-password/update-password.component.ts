import { Component, Inject, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/user';
import { UserServiceService } from 'src/app/Services/user-service.service';
import { DialogData } from '../user-management/user-management.component';

@Component({
  selector: 'update-password',
  templateUrl: './update-password.component.html',
  styleUrls: ['./update-password.component.css']
})
export class UpdatePasswordComponent implements OnInit {
  user:User=new User;
  constructor(
    public dialogRef: MatDialogRef<UpdatePasswordComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private router:Router,private userSrvice:UserServiceService,
  ) {}

  password(pas:string){
    alert("hello"+pas +"code:"+this.data.codeuse)
    this.dialogRef.close();
    this.UpdateUser1(this.data.codeuse,'password',pas)
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
