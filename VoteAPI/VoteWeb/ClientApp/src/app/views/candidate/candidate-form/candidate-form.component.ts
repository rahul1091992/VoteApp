import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RepositoryService } from '../../../services/repository.service';
import { ErrorHandlerService } from '../../../services/error-handler.service';
import { FormGroup, FormBuilder, Validators, ValidationErrors } from '@angular/forms';
import { EnvironmentUrlService } from '../../../services/environment-url.service';
import { HttpRequest, HttpEventType, HttpClient } from '@angular/common/http';

@Component({
 templateUrl: 'candidate-form.component.html'
})
 
    export class CandidateFormComponent implements OnInit {
  public form: FormGroup;
  public loading = false;
  public returnUrl: string;
  public error = '';
  public candidateId = 0;
  public imageId = 0;
  public imageName = '';
  public proofId = 0;
  public proofName = '';
  public elections: any[];
  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    public environmentUrlService: EnvironmentUrlService,
    private http: HttpClient,
    private router: Router,
    private toastr: ToastrService,
    private repository: RepositoryService,
    private errorHandler: ErrorHandlerService,
    private activeRoute: ActivatedRoute,
  ) 
  { }
  ngOnInit() {
    this.form = this.fb.group({
      electionId: [null, Validators.compose([Validators.required])],
      name: [null, Validators.compose([Validators.required, Validators.maxLength(100)])],
      fatherName: [null, Validators.compose([Validators.required, Validators.maxLength(100)])],
      email: [null, Validators.compose([Validators.email, Validators.required, Validators.maxLength(100)])],
      phone: [null, Validators.compose([Validators.required, Validators.minLength(10), Validators.maxLength(10)])],
        adhar: [null, Validators.compose([Validators.required, Validators.minLength(12), Validators.maxLength(12)])],
        address: [null, Validators.compose([Validators.required, Validators.maxLength(1000)])],
      image:0,
      proof:0,
    });

     // logged in user
     const currentUser = JSON.parse(localStorage.getItem('currentUser'));

    const id: any = this.activeRoute.snapshot.params['id'] || 0;
    this.candidateId = id;
    if (this.candidateId > 0) {
      this.getDetails(this.candidateId);
    }else {
      this.imageId = 0;
    this.proofId = 0;
    }
    this.getElection();
  }
  // Get Details
  public getDetails(roomId) {
    this.loading = true;
    this.candidateId = roomId;
    let apiUrl: string = `candidate/${this.candidateId}`;

    this.repository.getData(apiUrl)
      .subscribe(res => {
        if (res.status) {
        this.loading = false;
        this.imageId= res.data.image;
        this.proofId= res.data.proof;
        this.proofName=this.environmentUrlService.downloadUrl+ res.data.proofName;
        this.imageName=this.environmentUrlService.downloadUrl+ res.data.imageName;

        this.form.patchValue(res.data);
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

// Form Submit 
public onSubmit(formValue) {
  this.getFormValidationErrors();
  if (this.form.valid) {
    this.executeCreation(formValue);
  }
}
 
private executeCreation(formValue) {
  if(this.imageId===0){
    this.toastr.error('Upload image', 'Error');
    return;
  }
  if(this.proofId===0){
    this.toastr.error('Upload ID proof', 'Error');
    return;
  }
  formValue.image=this.imageId;
  formValue.proof=this.proofId;
  formValue.electionId=Number(formValue.electionId);

  this.loading = true;
  if (this.candidateId === 0 || this.candidateId === undefined) {
   

    const apiUrl = 'candidate';
    this.repository.create(apiUrl, formValue)
      .subscribe(res => {
        if (res.status) {
          this.toastr.success(res.message);
          this.loading = false;
          this.router.navigate(['/candidate']);
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
  } else {
    const apiUrl = `candidate/${this.candidateId}`;
    this.repository.update(apiUrl, formValue)
      .subscribe(res => {
        if (res.status) {
          this.toastr.success(res.message);
          this.loading = false;
          this.router.navigate(['/candidate']);
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
}
// Get election
public getElection() {
    this.loading = true;
    let apiUrl: string = `election/getAll`;

    this.repository.getData(apiUrl)
      .subscribe(res => {
        if (res.status) {
        this.loading = false;
        this.elections = res.data as any[];
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



     // upload image
  uploadImage(files) {
    if (files.length === 0)
      return;
    if (files.length > 1) {
      this.toastr.error('Max 1 file can be uploaded at once!');
      return;
    }
    const formData = new FormData();
    for (let file of files)
      formData.append(file.name, file);
    const apiUrl = this.environmentUrlService.urlAddress + `/fileUpload`;
    const uploadReq = new HttpRequest('POST', apiUrl, formData, {
      reportProgress: true,
    });
    this.http.request(uploadReq).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress){
       // this.progress = Math.round(100 * event.loaded / event.total);
      }
      else if (event.type === HttpEventType.Response)
        if (event) {
          var result: any = event.body;
          this.imageId = result.data.id;
          this.imageName=this.environmentUrlService.downloadUrl+ result.data.imageUrl;
        }

    });
  }
 // upload proof
 uploadProof(files) {
  if (files.length === 0)
    return;
  if (files.length > 1) {
    this.toastr.error('Max 1 file can be uploaded at once!');
    return;
  }
  const formData = new FormData();
  for (let file of files)
    formData.append(file.name, file);
  const apiUrl = this.environmentUrlService.urlAddress + `/fileUpload`;
  const uploadReq = new HttpRequest('POST', apiUrl, formData, {
    reportProgress: true,
  });
  this.http.request(uploadReq).subscribe(event => {
    if (event.type === HttpEventType.UploadProgress){
     // this.progress = Math.round(100 * event.loaded / event.total);
    }
    else if (event.type === HttpEventType.Response)
      if (event) {
        var result: any = event.body;
        this.proofId = result.data.id;
        this.proofName=this.environmentUrlService.downloadUrl+ result.data.imageUrl;
      }

  });
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
