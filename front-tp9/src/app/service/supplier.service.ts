import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Supplier } from '../model/Supplier';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  constructor(private http: HttpClient){
    
  }

  createSupplier(request: Supplier): Observable<any>{
    let endPoint = 'api/Supplier';
    return this.http.post(environment.supplier + endPoint, request);
  }

  updateSupplier(id : number,request: Supplier ){
    let endPoint = 'api/Supplier/';
    return this.http.patch(environment.supplier + endPoint + id, request);
  }

  getSupplier(): Observable<any>{
    let endPoint = 'api/Supplier';
    return this.http.get<Supplier>(environment.supplier + endPoint);
  }

// getSupplier(){
//     let endPoint = 'api/Supplier';
//     return this.http.get(environment.supplier + endPoint);
//   }
}