import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RepositoryService } from '../../../services/repository.service';
import { ErrorHandlerService } from '../../../services/error-handler.service';
import { FormGroup, FormBuilder, Validators, ValidationErrors } from '@angular/forms';
import { EnvironmentUrlService } from '../../../services/environment-url.service';

@Component({
 templateUrl: 'candidate-details.component.html'
})
 
    export class CandidateDetailsComponent implements OnInit {
  public form: FormGroup;
  public loading = false;
  public returnUrl: string;
  public error = '';
   
  public candidateId = 0;
  public name = '';
  public fatherName = '';
  public email = '';
  public phone = '';
  public adhar = '';
  public image = '';
  public proof = '';
  public address = '';
  public downloadUrl = '';

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService,
    public environmentUrlService: EnvironmentUrlService,
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
    this.candidateId = id;
    if (this.candidateId > 0) {
     
     this.getCandidate(this.candidateId);
    }
    
  }

   
  // Get Details
  public getCandidate(id) {
    this.loading = true;
    let apiUrl: string = `candidate/${id}`;

    this.repository.getData(apiUrl)
      .subscribe(res => {
        if (res.status) {
        this.loading = false;
         this.name=res.data.name;
         this.fatherName=res.data.fatherName;
         this.email=res.data.email;
         this.phone=res.data.phone;
         this.adhar=res.data.adhar;
         this.image=res.data.imageName;
         this.proof=res.data.proofName;
         this.address=res.data.address;
      }else{
        this.loading = false;
        this.toastr.error(res.message);
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
