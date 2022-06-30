import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-form-create',
  templateUrl: './form-create.component.html',
  styleUrls: ['./form-create.component.css']
})
export class FormCreateComponent implements OnInit {

  public form!: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      empresa: new FormControl('',Validators.required),
      direccion: new FormControl(''),
      ciudad: new FormControl(''),
      telefono: new FormControl('',Validators.required)
    })
  }

  guardar(){

  }

}
