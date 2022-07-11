import { Component, OnInit } from '@angular/core';
import { RouteConfigLoadEnd, Router } from '@angular/router';
import { Documents } from '../Models/documents';
import { DocumentServiceService } from '../Services/document-service.service';
import { UserServiceService } from '../Services/user-service.service';
@Component({
  selector: 'add-document',
  templateUrl: './add-document.component.html',
  styleUrls: ['./add-document.component.css']
})
export class AddDocumentComponent implements OnInit {
  document:Documents=new Documents();
  constructor( private router:Router,private documentServiceService:DocumentServiceService,private userSrvice:UserServiceService) { }
  code!:number;
  documentsName!:string;
  documentPath!:string;
  ngOnInit(): void {
  }
add()
{
  alert("jhgfbdvgmh,j.,mnbv")
  this.userSrvice.getCount().subscribe(c=>{
    this.document.code=c;
    if(c==null)
    {
      alert("פעולת ההוספה נכשלה");
    }
    else
    {
      this.document.code+=1;
      this.documentServiceService.insertUser(this.document).subscribe(code=>{
        this.document.code;
        if(code!=-1)
        {
          alert("code"+code)
        }
        else
        {
          alert("פעולת ההוספה נכשלה");
        }
      })
    }
  })
}
}
