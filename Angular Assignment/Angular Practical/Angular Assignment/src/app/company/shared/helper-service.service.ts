import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Company } from '../company.model';

@Injectable({
  providedIn: 'root'
})
export class HelperServiceService {

  private companiesData = new BehaviorSubject<Company[]>([]);
  companies = this.companiesData.asObservable();
  isFirstTime: boolean = true;
  constructor(private httpClient: HttpClient) { }
  ListData() {
    if (this.isFirstTime) {
      this.httpClient.get<Company[]>("../assets/Data/data.json").subscribe(data => {
        this.companiesData.next(data);
      });
    }
  }
  GetData(): Observable<Company[]> {
    return this.companies;
  }
}
