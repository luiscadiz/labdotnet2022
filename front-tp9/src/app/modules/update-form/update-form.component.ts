import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Supplier } from 'src/app/model/Supplier';
import { SupplierService } from 'src/app/service/supplier.service';

@Component({
  selector: 'app-update-form',
  templateUrl: './update-form.component.html',
  styleUrls: ['./update-form.component.css']
})
export class UpdateFormComponent implements OnInit {

  updateForm!: FormGroup;

  idSelector!: string;
  // idSelector: string = 
  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private supplierService: SupplierService
  ) { }

  ngOnInit(): void {
    this.idSelector = this.route.snapshot.params['id'];
    this.updateForm = this.fb.group({
      //Agregar validaciones mas especificas al ultimo
      id: new FormControl(this.idSelector,Validators.required),
      empresa: new FormControl('',Validators.required),
      direccion: new FormControl(''),
      ciudad: new FormControl(''),
      telefono: new FormControl('',Validators.required)
    });
  }

  onUpdate(): void{
    var supplier = new Supplier();
    supplier.Id = this.updateForm.get('id')?.value;
    supplier.NameCompany = this.updateForm.get('empresa')?.value;
    supplier.Address = this.updateForm.get('direccion')?.value;
    supplier.City = this.updateForm.get('ciudad')?.value;
    supplier.Phone = this.updateForm.get('telefono')?.value;


    this.supplierService.updateSupplier(this.updateForm.get('id')?.value,supplier).subscribe(
      {
        complete: ()=>{
          alert("Proveedor modificado");
          this.updateForm.reset();
        },
        error: ()=>{
          alert("Ocurrio un problema en la actualización..");
        }
      }
    );
  }

}
