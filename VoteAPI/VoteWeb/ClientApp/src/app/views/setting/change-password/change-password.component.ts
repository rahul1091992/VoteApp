import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RepositoryService } from '../../../services/repository.service';
import { ErrorHandlerService } from '../../../services/error-handler.service';
import { FormGroup, FormBuilder, Validators, ValidationErrors } from '@angular/forms';

@Component({
 templateUrl: 'change-password.component.html'
})
 
    export class ChangePasswordComponent implements OnInit {
  public form: FormGroup;
  public loading = false;
  public returnUrl: string;
  public error = '';
  public userId = 0;
  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService,
    private repository: RepositoryService,
    private errorHandler: ErrorHandlerService,
    private activeRoute: ActivatedRoute,
  ) 
  { }
  ngOnInit() {
    this.form = this.fb.group({
        oldPassword: [null, Validators.compose([Validators.required])],
        newPassword: [null, Validators.compose([Validators.required])],
        confirmPassword: [null, Validators.compose([Validators.required])],
        userId:0
    });

     // logged in user
     const currentUser = JSON.parse(localStorage.getItem('currentUser'));
     this.userId=currentUser.userId;

    const id: any = this.activeRoute.snapshot.params['id'] || 0;
    

  }
   
// Form Submit 
public onSubmit(formValue) {
  this.getFormValidationErrors();

  if(formValue.newPassword!=formValue.confirmPassword){
    this.toastr.error('Confirm Password not match');
    return;
  }

  if (this.form.valid) {
    this.executeCreation(formValue);
  }
}
 
private executeCreation(formValue) {
  formValue.userId=this.userId;
  console.log(formValue);
  this.loading = true;
 
    const apiUrl = 'adminAccount/changePassword';
    this.repository.create(apiUrl, formValue)
      .subscribe(res => {
        if (res.status) {
          this.toastr.success(res.message);
          this.loading = false;
          this.router.navigate(['/login']);
        } else {
          this.toastr.error(res.message);
          this.loading = false;
        }
      },
        (error => {
          this.errorHandler.handleError(error);
          this.toastr.error('There was some error. Please re-try or contact web admin', 'Error');
          this.loading = false;
        })
      );
   
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
