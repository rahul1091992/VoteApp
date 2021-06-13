import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ChartsModule } from 'ng2-charts';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { CandidateListComponent } from './candidate-list/candidate-list.component';
import { CandidateFormComponent } from './candidate-form/candidate-form.component';
import { CandidateRoutingModule } from './candidate-routing.module';
import { CandidateDetailsComponent } from './candidate-details/candidate-details.component';


@NgModule({
  imports: [
    FormsModule,CommonModule,
    CandidateRoutingModule,
    ChartsModule,
    BsDropdownModule,
    ButtonsModule.forRoot(),
    ReactiveFormsModule,HttpClientModule,
  ],
  declarations: [
    CandidateListComponent,CandidateFormComponent,
    CandidateDetailsComponent,
     ]
   
})
export class CandidateModule { }
