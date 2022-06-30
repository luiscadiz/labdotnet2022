import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Supplier } from '../model/Supplier';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  constructor(private http: HttpClient){
    
  }

  createSupplier(request: Supplier){
    
  }
}