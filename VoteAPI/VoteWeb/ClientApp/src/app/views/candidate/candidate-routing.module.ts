import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CandidateListComponent } from './candidate-list/candidate-list.component';
import { CandidateFormComponent } from './candidate-form/candidate-form.component';
import { CandidateDetailsComponent } from './candidate-details/candidate-details.component';


const routes: Routes = [
  {
    path: '',
    component: CandidateListComponent,
    data: {
      title: 'Candidates'
    }
  },
  {
    path: 'add',
    component: CandidateFormComponent,
    data: {
      title: 'Candidates'
    }
  },
  {
    path: 'edit/:id',
    component: CandidateFormComponent,
    data: {
      title: 'Candidates'
    }
  },
  {
    path: 'details/:id',
    component: CandidateDetailsComponent,
    data: {
      title: 'Candidates'
    }
  },
   
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CandidateRoutingModule {}
