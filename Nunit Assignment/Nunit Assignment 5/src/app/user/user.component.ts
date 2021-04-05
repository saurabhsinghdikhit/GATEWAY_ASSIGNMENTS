import { Component, OnInit } from '@angular/core';
import { UserServiceService } from 'src/shared/user-service.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private userService: UserServiceService) { }

  ngOnInit(): void {
  }
  doLogin():boolean{
    console.log(this.userService.doLogin());
    return this.userService.doLogin();
  }
  isAlreadyLogin():boolean{
    return this.userService.isLogin();
  }
  doLogout():boolean{
    return this.userService.dologout();
  }
  isAlreadyLogout():boolean{
    return this.userService.isLogout();
  }
  createProduct():boolean{
    return this.userService.canCreateProduct();
  }
}
