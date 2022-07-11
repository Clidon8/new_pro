import { Component, Inject, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { NewhelloComponent } from '../newhello/newhello.component';
// import { NewhelloComponent } from '../newhello/newhello.component';

export interface DialogData {
  // animal: string;
  // name: string;
  newdata: string;
  name:string;
  codeuse:number;
  WhatCha:string;
}

@Component({
  selector: 'user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css']
})
export class UserManagementComponent implements OnInit {
  // animal!: string;
  name!: string;
  newdata!: string;
  codeuse!:number;
  WhatCha!:string;

  constructor( public dialog: MatDialog) { }
  ngOnInit(): void {

  }
  openDialog(): void {
    const dialogRef = this.dialog.open(NewhelloComponent, {
      width: '250px',
      data: {name: this.name, newdata: this.newdata},
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      this.newdata = result;
    });

}
}

