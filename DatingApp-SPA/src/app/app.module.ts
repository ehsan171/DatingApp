import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { MemberListComponent } from './member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { appRoutes } from './routes';
import {AuthGuard} from './_guards/auth.guard';
import {UserService} from './_services/user.service';
import { ScreenplayRegComponent } from './screenplay-reg/screenplay-reg.component';
import { ScreenplayComponent } from './screenplay/screenplay.component';
import { CheckBoxModule, ButtonModule } from '@syncfusion/ej2-angular-buttons';
import { enableRipple } from '@syncfusion/ej2-base';
import { DropDownButtonModule } from '@syncfusion/ej2-angular-splitbuttons';
import { MultiSelectModule, DropDownTreeModule, AutoCompleteModule, DropDownListModule } from '@syncfusion/ej2-angular-dropdowns';
import { TestComponent } from './test/test.component';
import { TextBoxModule, UploaderModule } from '@syncfusion/ej2-angular-inputs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatTreeModule} from '@angular/material/tree';
import {MatIconModule} from '@angular/material/icon';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { TestTreeComponent } from './testTree/testTree.component';
import { TestTree2Component } from './testTree2/testTree2.component';
import { TreeViewModule } from '@syncfusion/ej2-angular-navigations';
import { Screenplays_tableComponent } from './screenplays_table/screenplays_table.component';
import { ScreenplayIdComponent } from './screenplay-id/screenplay-id.component';
import { ScreenplayAllComponent } from './screenplay-all/screenplay-all.component';
import { ScreenplayDetailComponent } from './screenplay-detail/screenplay-detail.component';
import { ScreenplayEditComponent } from './screenplay-edit/screenplay-edit.component';
import { UploadComponent } from './upload/upload.component';
import { Test2Component } from './test2/test2.component';
import { AgTableModule } from 'ag-table';
import { FancyGridModule } from 'fancy-grid-angular';
import { BackButtonDisableModule } from 'angular-disable-browser-back-button';


//  khat zir baraie checkbox ast pak shavad
enableRipple(true);

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      MemberListComponent,
      ListsComponent,
      MessagesComponent,
      ScreenplayRegComponent,
      ScreenplayComponent,
      TestComponent,
      TestTreeComponent,
      TestTree2Component,
      Screenplays_tableComponent,
      ScreenplayIdComponent,
      ScreenplayAllComponent,
      ScreenplayDetailComponent,
      ScreenplayEditComponent,
      UploadComponent,
      Test2Component
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      BsDropdownModule.forRoot(),
      TabsModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      CheckBoxModule,
      DropDownButtonModule,
      MultiSelectModule,
      DropDownTreeModule,
      ReactiveFormsModule,
      AutoCompleteModule,
      ButtonModule,
      DropDownListModule,
      TextBoxModule,
      DropDownTreeModule,
      BrowserAnimationsModule,
      MatTreeModule,
      MatIconModule,
      MatCheckboxModule,
      TreeViewModule,
      UploaderModule,
      AgTableModule,
      FancyGridModule,
      BackButtonDisableModule.forRoot(),


   ],
   providers: [
      AuthService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
