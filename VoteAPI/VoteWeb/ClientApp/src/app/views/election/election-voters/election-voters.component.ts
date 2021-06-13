import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from '../../../services/authentication.service';
import { RepositoryService } from '../../../services/repository.service';
import { ErrorHandlerService } from '../../../services/error-handler.service';
import { EnvironmentUrlService } from '../../../services/environment-url.service';

@Component({
  templateUrl: 'election-voters.component.html'
})
 
  export class ElectionVotersComponent implements OnInit {
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
   
    public electionId = 0;
    public candidateId = 0;

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
   
    const id: any = this.activeRoute.snapshot.params['id'] || 0;
    var splitted = id.split(",");  
    this.candidateId=splitted[0];
    this.electionId=splitted[1];
     this.downloadUrl=this.environmentUrlService.downloadUrl;
     this.getAll(0);
  }
  // Get Details
  public getAll(skip) {
    this.loading = true;
    let apiUrl: string = `election/getAllVoters/${this.electionId}/${this.candidateId}/${this.itemPerPage}/${skip}`;

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

   
    


 
}
