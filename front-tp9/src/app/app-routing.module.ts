import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FormCreateComponent } from './modules/form-create/form-create.component';


const routes: Routes = [
  {
    path: '',
    component: FormCreateComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
