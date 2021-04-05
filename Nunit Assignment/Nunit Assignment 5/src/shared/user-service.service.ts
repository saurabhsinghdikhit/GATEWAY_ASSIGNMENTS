import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  islogin:boolean=false;
  doLogin(){
    this.islogin=true;
    return true;
  }
  isLogin():boolean{
    return this.islogin;
  }
  dologout(){
    this.islogin=false;
    return true;
  }
  isLogout(){
    return !this.islogin;
  }
  canCreateProduct(){
    return this.islogin?true:false;
  }
}
