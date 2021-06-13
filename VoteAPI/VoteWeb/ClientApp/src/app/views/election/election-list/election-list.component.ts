import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from '../../../services/authentication.service';
import { RepositoryService } from '../../../services/repository.service';
import { ErrorHandlerService } from '../../../services/error-handler.service';

@Component({
  templateUrl: 'election-list.component.html'
})
 
  export class ElectionListComponent implements OnInit {
    public form: FormGroup;
    public loading = false;
    public returnUrl: string;
    public error = '';
   
   public elections: any[];

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
   
     // logged in user
     const currentUser = JSON.parse(localStorage.getItem('currentUser'));
     this.getAll();
  }
  // Get Details
  public getAll() {
    
    this.loading = true;
    let apiUrl: string = `election/getAll`;

    this.repository.getData(apiUrl)
      .subscribe(res => {
        if (res.status) {
        this.loading = false;
        console.log(res.data);
        this.elections = res.data as any[];
      }else{
        this.loading = false;
        this.elections = res.data as any[];
       // this.toastr.error(res.message);
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
   
  const deleteUrl = `election/${id}`;
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

public status(id) {
  const statusUrl = `election/status/${id}`;
  this.repository.getData(statusUrl)
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
}
