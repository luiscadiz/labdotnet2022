import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeleteSupplierComponent } from './modules/delete-supplier/delete-supplier.component';
import { FormCreateComponent } from './modules/form-create/form-create.component';
import { FromDeleteComponent } from './modules/from-delete/from-delete.component';
import { ListSupplierComponent } from './modules/list-supplier/list-supplier.component';
import { UpdateFormComponent } from './modules/update-form/update-form.component';


const routes: Routes = [
  {
    path: '',
    component: ListSupplierComponent
  },
  {
    path: 'actualizar',
    component: UpdateFormComponent
  },
  {
    path: 'eliminar',
    component: DeleteSupplierComponent
  },
  {
    path: 'crear',
    component: FormCreateComponent
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
