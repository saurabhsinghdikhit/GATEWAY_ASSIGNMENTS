import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Branch } from '../branch.model';
import { Company } from '../company.model';
import { HelperServiceService } from '../shared/helper-service.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  company: Company;
  companies: Company[] = [];
  branch:Branch[]=[];
  companyForm = new FormGroup({
    id: new FormControl(''),
    email: new FormControl('', Validators.required),
    name: new FormControl('', Validators.required),
    totalEmployee: new FormControl('', Validators.required),
    totalBranch: new FormControl(''),
    address: new FormControl('', Validators.required),
    isCompanyActive: new FormControl('')
  });
  constructor(private route: ActivatedRoute, private myService: HelperServiceService, private router: Router) { }

  ngOnInit(): void {
    this.myService.ListData();
    this.myService.GetData().subscribe((data) => {
      this.companies = data;
      this.company = this.companies.find(x => x.id == parseInt(this.route.snapshot.paramMap.get('id')));
      this.fillData(this.company);
    });

  }
  private fillData(company: Company) {
    this.companyForm.setValue({
      id: company.id,
      email: company.email,
      name:company.name,
      totalEmployee:company.totalEmployee,
      totalBranch: company.totalBranch,
      address: company.address,
      isCompanyActive:company.isCompanyActive
    });
    this.branch=company.companyBranch;
  }
  onSubmit() {
    let itemIndex = this.companies.findIndex(item => item.id == this.companyForm.get('id').value);
    this.companies[itemIndex] = this.companyForm.value;
    this.companies[itemIndex].companyBranch = this.branch;
    this.router.navigate(['/company/list'])
  }

}


