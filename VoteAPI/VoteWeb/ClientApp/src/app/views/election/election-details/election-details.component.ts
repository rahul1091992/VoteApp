import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RepositoryService } from '../../../services/repository.service';
import { ErrorHandlerService } from '../../../services/error-handler.service';
import { FormGroup, FormBuilder, Validators, ValidationErrors } from '@angular/forms';
import { EnvironmentUrlService } from '../../../services/environment-url.service';

@Component({
 templateUrl: 'election-details.component.html'
})
 
    export class ElectionDetailsComponent implements OnInit {
  public form: FormGroup;
  public loading = false;
  public returnUrl: string;
  public error = '';
  public downloadUrl = '';
  public candidates: any[];
  public electionId = 0;
  
  public name = '';
  public totalVote = 0;
  public winner = '';

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    public environmentUrlService: EnvironmentUrlService,
    private router: Router,
    private toastr: ToastrService,
    private repository: RepositoryService,
    private errorHandler: ErrorHandlerService,
    private activeRoute: ActivatedRoute,
  ) 
  { }
  ngOnInit() {
     

     // logged in user
     const currentUser = JSON.parse(localStorage.getItem('currentUser'));

     this.downloadUrl=this.environmentUrlService.downloadUrl;

    const id: any = this.activeRoute.snapshot.params['id'] || 0;
    this.electionId = id;
    if (this.electionId > 0) {
      this.getAll();
    }
    
  }
  // Get candidate
  public getAll() {
    this.loading = true;
    let apiUrl: string = `candidate/getAll/${this.electionId}`;

    this.repository.getData(apiUrl)
      .subscribe(res => {
        if (res.status) {
        this.loading = false;
        this.candidates = res.data as any[];
        //this.winner=res.data[0].name;
      }else{
        this.loading = false;
        this.candidates = res.data as any[];
      }
      this.getElection(this.electionId);
      },
      (error => {
        this.loading = false;
        this.errorHandler.handleError(error);
        this.toastr.error('There was some error. Please re-try or contact web admin', 'Error');
      })
      )
    }
  // Get Details
  public getElection(id) {
    this.loading = true;
    let apiUrl: string = `election/${id}`;

    this.repository.getData(apiUrl)
      .subscribe(res => {
        if (res.status) {
        this.loading = false;
         this.name=res.data.name;
         this.totalVote=res.data.totalVote;
        //  if(res.data.isActive){
        //      this.winner='';
        //  }

      }else{
        this.loading = false;
      }
      },
      (error => {
        this.loading = false;
        this.errorHandler.handleError(error);
        this.toastr.error('There was some error. Please re-try or contact web admin', 'Error');
      })
      )
    }

 
    

 
 

   //******************To be used in dev mode only***************************
   getFormValidationErrors() {
    Object.keys(this.form.controls).forEach(key => {

      const controlErrors: ValidationErrors = this.form.get(key).errors;
      if (controlErrors != null) {
        Object.keys(controlErrors).forEach(keyError => {
          console.log('Key control: ' + key + ', keyError: ' + keyError + ', err value: ', controlErrors[keyError]);
        });
      }
    });
  }
  // Validations
  public validateControl(controlName: string) {
    if (this.form.controls[controlName].invalid && this.form.controls[controlName].touched)
      return true;

    return false;
  }

  public hasError(controlName: string, errorName: string) {
    if (this.form.controls[controlName].hasError(errorName))
      return true;
    return false;
  }
}
