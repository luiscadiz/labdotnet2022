import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { FormCreateComponent } from './modules/form-create/form-create.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { UpdateFormComponent } from './modules/update-form/update-form.component';
import { FromDeleteComponent } from './modules/from-delete/from-delete.component';
import { ListSupplierComponent } from './modules/list-supplier/list-supplier.component';
import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import { DeleteSupplierComponent } from './modules/delete-supplier/delete-supplier.component';



@NgModule({
  declarations: [
    AppComponent,
    FormCreateComponent,
    UpdateFormComponent,
    FromDeleteComponent,
    ListSupplierComponent,
    DeleteSupplierComponent
  ],
  imports: [  
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    MatCardModule,
    MatTableModule,
    MatPaginatorModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
