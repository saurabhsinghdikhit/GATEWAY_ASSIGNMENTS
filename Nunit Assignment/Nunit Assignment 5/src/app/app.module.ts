import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { UserServiceService } from 'src/shared/user-service.service';

import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [UserServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
