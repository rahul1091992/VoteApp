import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { VotersListComponent } from './voters-list/voters-list.component';
import { VotersDetailsComponent } from './voters-details/voters-details.component';


const routes: Routes = [
  {
    path: '',
    component: VotersListComponent,
    data: {
      title: 'Voters'
    }
  } 
  ,
  {
    path: 'details/:id',
    component: VotersDetailsComponent,
    data: {
      title: 'Voters'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VotersRoutingModule {}
