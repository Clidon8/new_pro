import { Component, OnInit,ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { UserServiceService } from 'src/app/Services/user-service.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogtextComponent } from 'src/app/dialogtext/dialogtext.component';
//  import { promises } from 'dns';
// const fs = require("fs");
// import { Observable } from 'rxjs';
// import { Packer } from 'docx';
// import * as saveAs from 'file-saver';
// import { DocumentCreator } from 'cv-generator';


@Component({
  selector: 'clidon-typed-page',
  templateUrl: './clidon-typed-page.component.html',
  styleUrls: ['./clidon-typed-page.component.css']
})

export class ClidonTypedPageComponent{
newtex!:string;
localUrl!:any;
showSpinner!:boolean;
/**
 *
 */


// text:string = "Something you want to write in";

 constructor(private router:Router, private s:UserServiceService,public dialog:MatDialog) { }
 Gotohome(){
  this.router.navigate(['child-home-page']);
}
upload(fileInput :any,str:Number) {
  this.showSpinner=true;
  //debugger
      //console.log(fileInput);
      // debugger

          this.s.uploadFile(fileInput.files[0],str)//.then((res: any) => {
      .subscribe(
      response =>{
        // debugger
         console.log('Observer got a next value: ' + response)
         console.log("התמונות נטענו בהצלחה",response);
         this.newtex = response;
        // alert("הכנס שם לקובץ");
      //  this.dialog.open;
   const dialogRef = this.dialog.open(DialogtextComponent, {
   width: '350px'
});

dialogRef.afterClosed().subscribe(result => {
let fileName = result;
  this.showSpinner=false;
this.download(this.newtex,fileName);
});

    },
      err => console.error('Observer got an error: ' + err),
      () => console.log('Observer got a complete notification')
          );
    }

    download(text:string,fileName:string) {

      var file = new Blob([text], {type: '.doc'});
      const nav = (window.navigator as any);
      if (nav.msSaveOrOpenBlob)
          nav.msSaveOrOpenBlob(file, fileName);
      else { // Others
          var a = document.createElement("a"),
                  url = URL.createObjectURL(file);
          a.href = url;
          a.download = fileName;
          document.body.appendChild(a);
          a.click();
          setTimeout(function() {
              document.body.removeChild(a);
              window.URL.revokeObjectURL(url);
          }, 0);
      }
    }
    //אתר שמסביר בקוד איך מורידים תמונה ע"י שמירה בשם וכתיבה לקובץ
    // https://stackblitz.com/edit/angular-bpbexb?file=src%2Fapp%2Fapp.component.ts

}


function DialogComponent(DialogComponent: any, arg1: { width: string; data: { dialogTitle: any; dialogText: any; }; }) {
throw new Error('Function not implemented.');
}

function DialogText(DialogText: any, arg1: { width: string; data: { dialogTitle: string; }; }) {
throw new Error('Function not implemented.');
}


// file(text:string){
//   fs.writeFileSync("document.txt", this.text, function(err:any){
// if(err){
//   return console.log("error");
// }
// })
// }
//   // upload(fileInput :any)
  // {

  //  // debugger
  //       // console.log(fileInput);
  //       //     this.g.uploadFile(fileInput.files[0],this.grade_code).subscribe();
  //       //     console.log("התמונות נטענו בהצלחה");
  //       //     this.students=false;
  // }
//   Gotohome(){
//     this.router.navigate(['child-home-page']);
//   }

//   upload(fileInput :any) //event
//   {
//   console.log(fileInput);
//   //  debugger
//   let fileName = fileInput.target.files[0].name;
//   // if (fileInput.target.files && fileInput.target.files[0]) {
//     //var reader = new FileReader();
//     //reader.onload = (event: any) => {
//       // this.localUrl = event.target.result;
//        //console.log(this.localUrl);
//         this.s.uploadFile(fileName).subscribe(
//         response =>{
//             // debugger
//             console.log('Observer got a next value: ' + response)
//             console.log("התמונות נטענו בהצלחה",response);
//             this.newtex = response;
//             // alert("הכנס שם לקובץ");
//           //  this.dialog.open;

//       const dialogRef = this.dialog.open(DialogtextComponent, {
//       width: '350px'
//   });

//   dialogRef.afterClosed().subscribe(result => {
//     let fileName = result;
//     this.download(this.newtex,fileName);
//   });

//         });
//    // }
//   //  reader.readAsDataURL(fileInput.target.files[0]);
// //}
//   ////let base64 = this.fileChange(fileInput);
//   //console.log(base64);
//   //debugger

//    
// //,  err => console.error('Observer got an error: ' + err),
//  //       () => console.log('Observer got a complete notification')
//     }

//       download(text:string,fileName:string) {
//         // debugger
//         var file = new Blob([text], {type: '.doc'});
//         const nav = (window.navigator as any);
//         if (nav.msSaveOrOpenBlob)
//             nav.msSaveOrOpenBlob(file, fileName);
//         else { // Others
//             var a = document.createElement("a"),
//                     url = URL.createObjectURL(file);
//             a.href = url;
//             a.download = fileName;
//             document.body.appendChild(a);
//             a.click();
//             setTimeout(function() {
//                 document.body.removeChild(a);
//                 window.URL.revokeObjectURL(url);
//             }, 0);
//         }
//       }
//       //אתר שמסביר בקוד איך מורידים תמונה ע"י שמירה בשם וכתיבה לקובץ
//       // https://stackblitz.com/edit/angular-bpbexb?file=src%2Fapp%2Fapp.component.ts


//  fileChange( event:any) {
//   let fileList: FileList = event.target.files;
//   if (fileList.length > 0) {
//     let file: File = fileList[0];

//     // var fileType = file.name.substring(
//     //   file.name.indexOf(".") + 1,
//     //   file.name.length
//     // );
//     var fileType = file.name.split(".")[file.name.split(".").length-1]
//     if ((window as any).FileReader) {
//       var fileBase64 = "";
//       var fileReader = new FileReader();
//       fileReader.readAsDataURL(file);
//       fileReader.onload = function(e) {
//         fileBase64 = (e.target as any).result.substring(
//           (e.target as any).result.indexOf(",") + 1,
//           (e.target as any).result.length
//         );
//         fileBase64 = (e.target as any).result.substring(
//           0,
//           (e.target as any).result.indexOf("/") + 1
//         );
//         fileBase64 = fileBase64 + fileType;
//         fileBase64 =
//           fileBase64 +
//           (e.target as any).result.substring(
//             (e.target as any).result.indexOf(";"),
//             (e.target as any).result.length
//           );
//       //  if (callback) {
//           // if (jQuery.inArray(fileType, ["pdf", "png", "jpg", "jpeg"]) == -1)
//           // if (!isLogo)
//           // {
//           //   if (
//           //     !fileType.includes("pdf") &&
//           //     !fileType.includes("xls") &&
//           //     !fileType.includes("csv") &&
//           //     !fileType.includes("xlsx")
//           //   )
//           //     fileBase64 = "error";
//           // }
//           //  else {

//         //  }
//           return fileBase64;
//         }
//       };
//     }
//   }

// }

// function DialogComponent(DialogComponent: any, arg1: { width: string; data: { dialogTitle: any; dialogText: any; }; }) {
//   throw new Error('Function not implemented.');
// }

// function DialogText(DialogText: any, arg1: { width: string; data: { dialogTitle: string; }; }) {
//   throw new Error('Function not implemented.');


