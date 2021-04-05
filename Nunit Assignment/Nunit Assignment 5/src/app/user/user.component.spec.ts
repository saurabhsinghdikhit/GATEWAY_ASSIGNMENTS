import { ComponentFixture, TestBed } from '@angular/core/testing';
import { UserServiceService } from 'src/shared/user-service.service';

import { UserComponent } from './user.component';

describe('UserComponent', () => {
  let component: UserComponent;
  let fixture: ComponentFixture<UserComponent>;

  let user: UserComponent;
  let service: UserServiceService;
  let spy: any;

  beforeEach(() => {
    service = new UserServiceService();
    component = new UserComponent(service);
  });
  afterEach(()=>{
    service = null;
    component = null;
  });

  it('check if user is already logged in', () => {
    spy = spyOn(service, 'isLogin').and.returnValue(false);
    expect(component.isAlreadyLogin()).toBeFalsy();
    expect(service.isLogin).toHaveBeenCalled();

  });
  it('do login', () => {
    spy = spyOn(service, 'doLogin').and.returnValue(true);
    expect(component.doLogin()).toBeTruthy();
    expect(service.doLogin).toHaveBeenCalled();
  });
  it('do logout', () => {
    spy = spyOn(service, 'dologout').and.returnValue(true);
    expect(component.doLogout()).toBeTruthy();
    expect(service.dologout).toHaveBeenCalled();
  });
  it('is logout', () => {
    spy = spyOn(service, 'isLogout').and.returnValue(true);
    expect(component.isAlreadyLogout()).toBeTruthy();
    expect(service.isLogout).toHaveBeenCalled();
  });
  it('can create product', () => {
    spy = spyOn(service, 'canCreateProduct').and.returnValue(true);
    expect(component.createProduct()).toBeTruthy();
    expect(service.canCreateProduct).toHaveBeenCalled();
  });
});
