import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Documents } from '../Models/documents';

@Injectable({
  providedIn: 'root'
})
export class DocumentServiceService {
//api/Main
url="https://localhost:44317/api/Main"
  constructor(private http:HttpClient) { }
  insertUser(document:Documents):Observable<null>
  {
  return this.http.post<null>(this.url+'/insert/',document);
  }

  
}
