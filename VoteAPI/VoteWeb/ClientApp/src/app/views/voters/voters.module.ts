import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ChartsModule } from 'ng2-charts';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { VotersListComponent } from './voters-list/voters-list.component';
import { VotersRoutingModule } from './voters-routing.module';
import { VotersDetailsComponent } from './voters-details/voters-details.component';
import { NgxPaginationModule } from 'ngx-pagination';


@NgModule({
  imports: [
    FormsModule,CommonModule,  NgxPaginationModule,
    VotersRoutingModule,
    ChartsModule,
    BsDropdownModule,
    ButtonsModule.forRoot(),
    ReactiveFormsModule,HttpClientModule,
  ],
  declarations: [
    VotersListComponent,VotersDetailsComponent
     ]
   
})
export class VotersModule { }
