import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators ,FormBuilder} from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../Models/user';
import { UserServiceService } from '../Services/user-service.service';
// import { FileMimeType } from '@taldor-ltd/angular-file-viewer';

@Component({
  selector: 'files',
  templateUrl: './files.component.html',
  styleUrls: ['./files.component.css']
})
export class FilesComponent implements OnInit {
  formData!:FormGroup;
  password!:FormControl;
  user:User=new User();
  fileName !:string;
  constructor(){}
  ngOnInit(): void {
    this.password= new FormControl("",[Validators.required,Validators.maxLength(8),Validators.minLength(4)]),
    this.formData=new FormGroup({
      password:this.password
    })
  }


  // onFileSelected(event: { target: { files: File[]; }; }) {

  //   const file:File = event.target.files[0];

    // if (file) {

    //     this.fileName = file.name;

    //     const formData = new FormData();

    //     formData.append("thumbnail", file);

    //     const upload$ = this.http.post("/api/thumbnail-upload", formData);

    //     upload$.subscribe();
    // }
}


