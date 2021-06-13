import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from '../../../services/authentication.service';
import { RepositoryService } from '../../../services/repository.service';
import { ErrorHandlerService } from '../../../services/error-handler.service';
import { EnvironmentUrlService } from '../../../services/environment-url.service';

@Component({
  templateUrl: 'voters-list.component.html'
})
 
  export class VotersListComponent implements OnInit {
    public form: FormGroup;
    public loading = false;
    public returnUrl: string;
    public error = '';
    public downloadUrl = '';
    public filter = '0';
    public itemPerPage = 20;
    public currentPage = 1;
    config: any;
    collection = {  data: [] };
   
   public voters: any[];

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
     this.getAll(0);
  }
  // Get Details
  public getAll(skip) {
    this.loading = true;
    let apiUrl: string = `voters/getAll/${this.itemPerPage}/${skip}/${this.filter}`;

    this.repository.getData(apiUrl)
      .subscribe(res => {
        if (res.status) {
        this.loading = false;
        this.collection.data=res.data as any[];
         
        this.config = {
          itemsPerPage: this.itemPerPage,
          currentPage: this.currentPage,
          totalItems:Number(res.message)
        };

         
      }else{
        this.loading = false;
        this.voters = res.data as any[];
      }
      },
      (error => {
        this.loading = false;
        this.errorHandler.handleError(error);
        this.toastr.error('There was some error. Please re-try or contact web admin', 'Error');
      })
      )
    }
    pageChanged(event){
      this.config.currentPage = event;
      this.currentPage=event;
      var skip=0;
      if(event==1){
        skip=0;
      }else {
        skip=((event-1)*this.itemPerPage);
      }
      this.getAll(skip);
    }

  //search
    public search(filter) {
      this.filter=filter;
      if(this.filter==''){
        this.filter='0';
      }
      this.getAll(0);
    }

    public status(id) {
      const statusUrl = `voters/status/${id}`;
      this.repository.getData(statusUrl)
          .subscribe(res => {
            if (res.status) {
              this.getAll(0);
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
