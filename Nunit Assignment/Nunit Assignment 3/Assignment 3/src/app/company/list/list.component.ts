import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HelperServiceService } from '../shared/helper-service.service';
import { Company } from '../company.model';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  companies: Company[] = [];
  constructor(private myService: HelperServiceService) { }

  ngOnInit(): void {
    this.loadScript('../assets/js/datatables-demo.js');
    this.loadScript('../assets/js/scripts.js');
    this.myService.ListData();
    this.myService.GetData().subscribe((data) => {
      this.companies = data;
    });
    
    this.myService.isFirstTime = false;
  }
  private loadScript(url: string) {
    const body = <HTMLDivElement>document.body;
    const script = document.createElement('script');
    script.innerHTML = '';
    script.src = url;
    script.async = false;
    script.defer = true;
    body.appendChild(script);
  }
  public delete(id:number){
    this.companies.splice(id-1,1);
  }
}
