import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import {User}from 'src/app/Models/user'
import { templateJitUrl } from '@angular/compiler';
import { Documents } from '../Models/documents';
import { numbers } from '@material/dialog';
// import { promises } from 'dns';


@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  //קישור לCOTROLLER של הUSER
url="https://localhost:44317/api/user"
document:Documents=new Documents();
documentPath!:string;

  constructor(private http:HttpClient) { }
//הוספת משתמש חדש
 insertUser(user:User):Observable<null>
{
return this.http.post<null>(this.url+'/insert/',user);
}
isSignIn(password:String):Observable<null>
{
return this.http.get<null>(`${this.url}/isSignIn/${password}`);
}
LOGIN( password:string,lname:string,fname:string):Observable<null>{
 return this.http.get<null>(`${this.url}/LOGIN/${password}/${lname}/${fname}`);
}
IsName(fname:string,lname:string):Observable<boolean>
{
  return this.http.get<boolean>(`${this.url}/IsName/${fname}/${lname}`)
}
// isSignIn(password:String,fname:string,lname:string):Observable<null>
// {
// return this.http.get<null>(`${this.url}/isSignIn/${password}${fname}${lname}`);
// }
//מספר רץ כמספר זיהוי למשתמשים
getCount():Observable<number>
{
  return this.http.get<number>(`${this.url}/getcount`)
}
//שינוי סיסמא
ChangePassword(passwordold:String,passwordnew:String):Observable<number>{
return this.http.get<number>(`${this.url}/ChangePassword/${passwordold}/${passwordnew}`)
}
//שכח סיסמא
CodeUser(lastName:string,firstName:string,passwordnew:string):Observable<null>{
  // alert("l: "+lastName+" f: "+firstName+" p: "+passwordnew)
return this.http.get<null>(`${this.url}/CodeUser/${lastName}/${firstName}/${passwordnew}`);
}
UpdetIsMeneger( ISmeneger:boolean, password:string,lastname:string,firstname:string):Observable<boolean>{
return this.http.get<boolean>(`${this.url}/UpdetIsMeneger/${ISmeneger}/${password}/${lastname}/${firstname}`)
}
UpdetIsMeneger1( ISmeneger:boolean, password:string,fname:string,lname:string):Observable<null>{
  alert("p: "+password+" f: "+fname+" l: "+lname)
  return this.http.get<null>(`${this.url}/UpdetIsMeneger/${ISmeneger}/${password}/${fname}/${lname}`)
  }

//מביא את כל המשתמשים
AllUser():Observable<User []>{
  return this.http.get<User[]>(`${this.url}/AllUser`);
}
//מחיקת משתמש
Delet(codeuser:number):Observable<number>{
  return this.http.get<number>(`${this.url}/Delet/${codeuser}`);
}
//עדכון נתונים של משתמשים
UpdateUser1(codeuser:number,WhatChange:string,DataChange:string):Observable<null>{
  return this.http.get<null>(`${this.url}/UpdateUser1/${codeuser}/${WhatChange}/${DataChange}`);
}
//מסמכים להקלדה//Promise<any>{
  public uploadFile (TEXT: File,str:Number): Observable<any>{
    //  debugger
         let formData = new FormData();
         formData.append('TEXT',TEXT);
        // formData.append('GradeCode',gradeCode.toString());
        //formData
    //var  str ="1";
    return this.http.post<any>(this.url+'/FileToText/',formData);
      }

  // public uploadFile (TEXT: File,number:Number): Observable<any>{
  //        let formData = new FormData();
  //        formData.append('TEXT',TEXT);
  // //  return this.http.get<any>(`${this.url}/Files/`)
  //      return this.http.post<any>(`${this.url}/FileToText/`,formData);
  //     }






// //מסמכים להקלדה//Promise<any>{
// public uploadFile (TEXT:string): Observable<any>{
//   // debugger
//        let formData = new FormData();
//        formData.append('TEXT',TEXT);
//       // formData.append('GradeCode',gradeCode.toString());
//       //formData
// //  str ="";
//   // return this.http.get<any>(this.url+'/Files/'+str);
//   //return this.http.get<any>(`${this.url}/Files/${"C:\Users\שטרן\Desktop\מסכי פרוייקט\black.png"}`)
//   var a="hghj";
//   return this.http.get<any>(`${this.url}/Files/${a}`)
//     }
}




