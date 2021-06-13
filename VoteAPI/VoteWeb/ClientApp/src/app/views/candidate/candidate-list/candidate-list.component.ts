import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RepositoryService } from '../../../services/repository.service';
import { ErrorHandlerService } from '../../../services/error-handler.service';
import { EnvironmentUrlService } from '../../../services/environment-url.service';

@Component({
  templateUrl: 'candidate-list.component.html'
})
 
  export class CandidateListComponent implements OnInit {
    public form: FormGroup;
    public loading = false;
    public returnUrl: string;
    public error = '';
    public downloadUrl = '';
    public userId = 0;
    public electionId = 0;
   public candidates: any[];
   public elections: any[];

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    public environmentUrlService: EnvironmentUrlService,
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
    
     this.getElection();
     
  }
  // Get All
  public getAll() {
    this.loading = true;
    let apiUrl: string = `candidate/getAll/${this.electionId}`;

    this.repository.getData(apiUrl)
      .subscribe(res => {
        if (res.status) {
        this.loading = false;
        this.candidates = res.data as any[];
      }else{
        this.loading = false;
        this.candidates = res.data as any[];
      }
      },
      (error => {
        this.loading = false;
        this.errorHandler.handleError(error);
        this.toastr.error('There was some error. Please re-try or contact web admin', 'Error');
      })
      )
    }
     // Delete
public delete(id) {
  if (confirm('Are you sure')) {
    this.deleteConfirm(id);
  }
}
public deleteConfirm(id) {
   
  const deleteUrl = `candidate/${id}`;
  this.repository.delete(deleteUrl)
      .subscribe(res => {
        if (res.status) {
          this.getAll();
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
     // election change
     public electionchange(id) {
      this.electionId=id;
      this.getAll();
    }

// Get elections
public getElection() {
  this.loading = true;
  let apiUrl: string = `election/getAll`;

  this.repository.getData(apiUrl)
    .subscribe(res => {
      if (res.status) {
      this.loading = false;
      console.log(res.data);
      this.elections = res.data as any[];
      if(this.electionId==0){
        this.electionId= this.elections[0].id;
       }
      this.getAll();

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
}
