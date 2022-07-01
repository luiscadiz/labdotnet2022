import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Supplier } from 'src/app/model/Supplier';
import { SupplierService } from 'src/app/service/supplier.service';

@Component({
  selector: 'app-form-create',
  templateUrl: './form-create.component.html',
  styleUrls: ['./form-create.component.css']
})
export class FormCreateComponent implements OnInit {

  public form!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private supplierService: SupplierService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      empresa: new FormControl('',Validators.required),
      direccion: new FormControl(''),
      ciudad: new FormControl(''),
      telefono: new FormControl('',Validators.required)
    })
  }

  guardar(){
    const supplier = new Supplier();
    supplier.NameCompany = this.form.get('empresa')?.value
    supplier.Address = this.form.get('direccion')?.value
    supplier.City = this.form.get('ciudad')?.value
    supplier.Phone = this.form.get('telefono')?.value;

    this.supplierService.createSupplier(supplier).subscribe(res => {
      console.log("Se guardo el proveedor" + res);
      this.form.reset();
    });
  }

}