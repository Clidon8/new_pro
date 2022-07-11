import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'clidon-user-management',
  templateUrl: './clidon-user-management.component.html',
  styleUrls: ['./clidon-user-management.component.css']
})
export class ClidonUserManagementComponent implements OnInit {


  constructor(private router:Router) { }
  ChangeIsMeneger()
  {
    this.router.navigate(['clidon-is-manager']);
  }
  adduser(){
    this.router.navigate(['clidon-sing-in']);
  }
  ChangeUsers(){
    this.router.navigate(['clidon-user-table'])
  }
  ngOnInit(): void {
  }

}
