import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DramasComponent } from './dramas/drama';

const routes: Routes = [
  { path: "",
  component: DramasComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
