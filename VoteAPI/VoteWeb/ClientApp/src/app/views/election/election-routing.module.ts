import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ElectionListComponent } from './election-list/election-list.component';
import { ElectionFormComponent } from './election-form/election-form.component';
import { ElectionDetailsComponent } from './election-details/election-details.component';
import { ElectionVotersComponent } from './election-voters/election-voters.component';


const routes: Routes = [
  {
    path: '',
    component: ElectionListComponent,
    data: {
      title: 'Election'
    }
  },
  {
    path: 'add',
    component: ElectionFormComponent,
    data: {
      title: 'Election'
    }
  },
  {
    path: 'edit/:id',
    component: ElectionFormComponent,
    data: {
      title: 'Election'
    }
  },
  {
    path: 'details/:id',
    component: ElectionDetailsComponent,
    data: {
      title: 'Election'
    }
  },
  
  {
    path: 'electionvoters/:id',
    component: ElectionVotersComponent,
    data: {
      title: 'Election'
    }
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ElectionRoutingModule {}
