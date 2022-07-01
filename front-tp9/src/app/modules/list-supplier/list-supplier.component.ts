import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Supplier } from 'src/app/model/Supplier';
import { SupplierService } from 'src/app/service/supplier.service';

@Component({
  selector: 'app-list-supplier',
  templateUrl: './list-supplier.component.html',
  styleUrls: ['./list-supplier.component.css']
})
export class ListSupplierComponent implements OnInit {

  public suppliers: Supplier[] = [];
  constructor(private listSupplier: SupplierService) { }

  ngOnInit(): void {
    this.getListSupplier();
  }

  getListSupplier(){
      this.listSupplier.getSupplier().subscribe(res => {
        this.suppliers = res;
      })
  }

  // getListSupplier(){
  //       console.log(this.listSupplier.getSupplier());
  //   }

}
