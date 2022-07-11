import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators ,FormBuilder} from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/Models/user';
import { UserServiceService } from 'src/app/Services/user-service.service';

@Component({
  selector: 'clidon-sing-in',
  templateUrl: './clidon-sing-in.component.html',
  styleUrls: ['./clidon-sing-in.component.css']
})
export class ClidonSingInComponent implements OnInit {

  formData!:FormGroup;
  in!:string
  name!:FormControl;
  FirstName!:string;
  LastName!:string;
  email!:FormControl;
  password!:FormControl;
  user:User=new User();
  constructor(private router:Router,private userSrvice:UserServiceService){

  }
  ngOnInit(): void {
    this.name = new FormControl("",[Validators.required,Validators.minLength(2)]),
    this.email=new FormControl("",[Validators.required,Validators.email]),
    this.password= new FormControl("",[Validators.required,Validators.maxLength(8),Validators.minLength(4)]),
    this.formData=new FormGroup({
      name: this.name,
      email: this.email,
      password:this.password
    })
  }
  resetForm()
  {
    this.formData.reset();
    sessionStorage.setItem('enter','0')
  }

  insertUser()
  {
  this.userSrvice.getCount().subscribe(code=>{this.user.code=code
  if(code==null)
  {
    console.log("פעולת ההוספה לא הצליחה");
  }
  else
  {
    this.user.code+=1;
    this.userSrvice.insertUser(this.user).subscribe(code=>{
    this.user.code;
     if(code==-1)
     {
      console.log("פעולת ההוספה לא הצליחה");
     }
     else
     {
       //קישור לאיזור האישי(אם הצליח להוסיף את המשתמש)
       //this.router.navigate(['clidon-typed-page']);
       //אם הצליח להוסיף את המשתמש יהיה לו קישור ל PAYPAL ואם שילם קישור לאיזור האישי.
       this.router.navigate(['clidon-payment']);
       console.log("ברוכים הבאים ");
     }

    })
  }
    })

  }

  }



