import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'clidon-management-operations',
  templateUrl: './clidon-management-operations.component.html',
  styleUrls: ['./clidon-management-operations.component.css']
})
export class ClidonManagementOperationsComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  GoToclidonUserManagement(){
    this.router.navigate(['clidon-user-management']);
  }

  clidonChangeManagerPassword(){
   this.router.navigate(['clidon-change-manager-password']);
  }
  m(){
    this.router.navigate(['clidon-typed-page']);
  }
}
