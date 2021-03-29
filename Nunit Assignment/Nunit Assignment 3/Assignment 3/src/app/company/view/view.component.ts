import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Company } from '../company.model';
import { HelperServiceService } from '../shared/helper-service.service';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
  company:Company;
  companies: Company[]=[];
  companyId:number;
  constructor(private route: ActivatedRoute,private myService:HelperServiceService) { }

  ngOnInit(): void {
    this.loadScript('../assets/js/datatables-demo.js');
    this.loadScript('../assets/js/scripts.js');
    this.myService.ListData();
    this.myService.GetData().subscribe((data)=>
    {
      this.companies=data;
      this.company=this.companies.find(x=>x.id==parseInt(this.route.snapshot.paramMap.get('id')));
    });
  }
  private loadScript(url: string) {
    const body = <HTMLDivElement> document.body;
    const script = document.createElement('script');
    script.innerHTML = '';
    script.src = url;
    script.async = false;
    script.defer = true;
    body.appendChild(script);
    }
}
