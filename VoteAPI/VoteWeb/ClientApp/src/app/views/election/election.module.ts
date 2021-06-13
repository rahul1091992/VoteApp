import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ChartsModule } from 'ng2-charts';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { ElectionRoutingModule } from './election-routing.module';
import { ElectionListComponent } from './election-list/election-list.component';
import { ElectionFormComponent } from './election-form/election-form.component';
import { ElectionDetailsComponent } from './election-details/election-details.component';
import { ElectionVotersComponent } from './election-voters/election-voters.component';
import { NgxPaginationModule } from 'ngx-pagination';


@NgModule({
  imports: [
    FormsModule,CommonModule,  NgxPaginationModule,
    ElectionRoutingModule,
    ChartsModule,
    BsDropdownModule,
    ButtonsModule.forRoot(),
    ReactiveFormsModule,HttpClientModule,
  ],
  declarations: [
    ElectionListComponent,ElectionFormComponent,ElectionDetailsComponent,ElectionVotersComponent
     ]
   
})
export class ElectionModule { }
