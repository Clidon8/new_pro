import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'clidon-manager-password',
  templateUrl: './clidon-manager-password.component.html',
  styleUrls: ['./clidon-manager-password.component.css']
})
export class ClidonManagerPasswordComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }
  GoToClidonManagementOperations(){
    this.router.navigate(['clidon-management-operations']);
  }
}
