import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Supplier } from '../model/Supplier';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  private endPoint: string = 'api/Supplier';
  
  constructor(private http: HttpClient){
    
  }

  createSupplier(request: Supplier): Observable<any>{
    return this.http.post(environment.supplier + this.endPoint, request);
  }

  updateSupplier(id : number,request: Supplier ){
    return this.http.patch(environment.supplier + this.endPoint + '/' + id, request);
  }

  getSupplier(): Observable<any>{
    return this.http.get<Supplier>(environment.supplier + this.endPoint);
  }

  deleteSupplier(id: number){
    return this.http.delete(environment.supplier + this.endPoint + '/' + id );
  }
}