import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { SupplierService } from 'src/app/service/supplier.service';

@Component({
  selector: 'app-delete-supplier',
  templateUrl: './delete-supplier.component.html',
  styleUrls: ['./delete-supplier.component.css']
})
export class DeleteSupplierComponent implements OnInit {

  formDelete!: FormGroup;
  idSelector!: string;
  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private service: SupplierService) { }

  ngOnInit(): void {
    this.idSelector = this.route.snapshot.params['id'];
    this.formDelete = this.fb.group({
      id: new FormControl(this.idSelector, Validators.required),
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
