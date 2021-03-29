import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Company } from '../company.model';
import { HelperServiceService } from '../shared/helper-service.service';
import {Router} from '@angular/router';
import { Branch } from '../branch.model';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  companies: Company[]=[];
  branch:Branch[]=[];
  companyForm = new FormGroup({
    id:new FormControl(''),
    email: new FormControl('',Validators.required),
    name: new FormControl('',Validators.required),
    totalEmployee: new FormControl('',Validators.required),
    totalBranch: new FormControl(''),
    address: new FormControl('',Validators.required),
    isCompanyActive: new FormControl(''),
    companyBranch: new FormGroup({
      branchId: new FormControl('1'),
      branchName: new FormControl('',Validators.required),
      address: new FormControl('',Validators.required)
    })
  });
  
  constructor(private myService:HelperServiceService,private router: Router) { }

  ngOnInit(): void {
    this.myService.ListData();
    this.myService.GetData().subscribe((data)=>
    {
      this.companies=data;
    });
    
  }
  onSubmit() {
    this.branch.push(this.companyForm.get("companyBranch").value);
    let last:any = this.companies[this.companies.length-1];
    this.companyForm.patchValue({id: (parseInt(last.id)+1)});
    this.companies.push(this.companyForm.value);
    this.companies[last.id].companyBranch=this.branch;
    this.router.navigate(['/company/list'])
  }
}
