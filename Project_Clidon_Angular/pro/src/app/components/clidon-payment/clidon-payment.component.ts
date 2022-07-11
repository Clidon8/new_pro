import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { render } from 'creditcardpayments/creditCardPayments';
@Component({
  selector: 'clidon-payment',
  templateUrl: './clidon-payment.component.html',
  styleUrls: ['./clidon-payment.component.css']
})
export class ClidonPaymentComponent implements OnInit {


  constructor( router:Router) {
    render({
      id:"#myPaypalButtons",
      currency:"USD",
      value:"5.00",
      onApprove:(details)=>{
       alert('הפעולה הצליחה')
       router.navigate(['clidon-typed-page']);
      }
    })
   }


  ngOnInit(): void {
  }

}
