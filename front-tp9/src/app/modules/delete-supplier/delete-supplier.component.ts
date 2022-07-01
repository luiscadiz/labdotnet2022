import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { SupplierService } from 'src/app/service/supplier.service';

@Component({
  selector: 'app-delete-supplier',
  templateUrl: './delete-supplier.component.html',
  styleUrls: ['./delete-supplier.component.css']
})
export class DeleteSupplierComponent implements OnInit {

  formDelete!: FormGroup;
  constructor(
    private fb: FormBuilder,
    private service: SupplierService) { }

  ngOnInit(): void {
    this.formDelete = this.fb.group({
      id: new FormControl('', Validators.required),
    })
  }

  deleteSupplier()
  {
    this.service.deleteSupplier(this.formDelete.get('id')?.value)
    .subscribe({
        complete: () => {
          alert("Proveedor Eliminado");
          this.formDelete.reset();
        },
      error: () => {
        alert("Ocurrio un problema--> No se logro eliminar el proveedor");
      }
    });
  }

}
