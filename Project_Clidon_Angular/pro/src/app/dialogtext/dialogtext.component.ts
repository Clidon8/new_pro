import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'dialogtext',
  templateUrl: './dialogtext.component.html',
  styleUrls: ['./dialogtext.component.css']
})
export class DialogtextComponent implements OnInit {
  @ViewChild('myForm', {static: true}) myForm!: NgForm;
  form!:FormGroup;
  constructor(
    private fb: FormBuilder,
    private dialogRef:MatDialogRef<DialogtextComponent>
   ) { }

  ngOnInit(): void {

  this.form = new FormGroup({
    name: new FormControl("")
  });
}

  save() {
    debugger
    this.dialogRef.close(this.form.controls.name.value);
}
}
