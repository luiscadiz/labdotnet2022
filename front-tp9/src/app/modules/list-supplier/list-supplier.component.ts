import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { Supplier } from 'src/app/model/Supplier';
import { SupplierService } from 'src/app/service/supplier.service';

@Component({
  selector: 'app-list-supplier',
  templateUrl: './list-supplier.component.html',
  styleUrls: ['./list-supplier.component.css']
})
export class ListSupplierComponent implements OnInit {

  displayedColumns: string[] = ["ID","Empresa","Direccion","Ciudad","Telefono","Opcion"];
  suppliers: Supplier[] = [];
  dataSource =  new MatTableDataSource<Supplier>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  constructor(private listSupplier: SupplierService) { }

  ngOnInit(): void {
    this.getListSupplier();
  }

  getListSupplier(){
      this.listSupplier.getSupplier().subscribe(res => {
        this.suppliers = res;
      })
  }

  listarProveedores(){
      this.dataSource.data = this.suppliers;
  }

}
