import { Component, Inject, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/user';
import { UserServiceService } from 'src/app/Services/user-service.service';
import { DialogData } from '../user-management/user-management.component';


@Component({
  selector: 'delet-user',
  templateUrl: './delet-user.component.html',
  styleUrls: ['./delet-user.component.css']
})
export class DeletUserComponent implements OnInit {
  user:User=new User;
  constructor(
    public dialogRef: MatDialogRef<DeletUserComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private router:Router,private userSrvice:UserServiceService,
  ) {}
  delet(name:string)
  {
    // alert("hello"+name +"code:"+this.data.codeuse)
    this.dialogRef.close();
    this.Delet(this.data.codeuse)
  }
  u:User[]=[]
  Delet(codeuser:number){
    // alert(codeuser)
    //מחיקת משתמש
     this.userSrvice.Delet(codeuser).subscribe(c=>{
       this.user.code=c
       if(c!=null){
        console.log('  פעולת המחיקה הצליחה')
       }
     })
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
  ngOnInit(): void {
  }
}
