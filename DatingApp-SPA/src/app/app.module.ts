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
import { TextBoxModule, UploaderModule, MaskedTextBoxModule, NumericTextBoxModule   } from '@syncfusion/ej2-angular-inputs';
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
// import { BackButtonDisableModule } from 'angular-disable-browser-back-button';
import { EposidesComponent } from './eposides/eposides.component';
import { Test3Component } from './test3/test3.component';
import {MatTableModule} from '@angular/material/table';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatInputModule } from '@angular/material/input';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DataTablesModule } from 'angular-datatables';
import { EpisodeComponent } from './episode/episode.component';
import { EpisodeAllComponent } from './episode-all/episode-all.component';
import { EpisodeRegComponent } from './episode-reg/episode-reg.component';
import { Upload2Component } from './upload2/upload2.component';
import { TestDownloadComponent } from './test-download/test-download.component';
// import { PdfViewerModule } from 'ng2-pdf-viewer';
import { FileUploadModule } from 'ng2-file-upload';
import { EpisodeDownloadComponent } from './episode-download/episode-download.component';
import { EpisodeEditComponent } from './episode-edit/episode-edit.component';
import { UploadTest2Component } from './upload-test2/upload-test2.component';
import { AccumulationChartModule, ChartModule, CategoryService, DateTimeService,
         ScrollBarService, ChartAnnotationService, RangeColumnSeriesService,
         StackingColumnSeriesService, LineSeriesService, LegendService,
         ColumnSeriesService, TooltipService} from '@syncfusion/ej2-angular-charts';
import { ChartFormatAllComponent } from './chart-format-all/chart-format-all.component';
import { PieSeriesService, AccumulationLegendService, AccumulationTooltipService, AccumulationAnnotationService,
   AccumulationDataLabelService } from '@syncfusion/ej2-angular-charts';
import { ChartFormatAll2Component } from './chart-format-all2/chart-format-all2.component';
import { ChartsModule } from 'ng2-charts';
import { ChartStatusAllComponent } from './chart-status-all/chart-status-all.component';


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
      Test2Component,
      EposidesComponent,
      Test3Component,
      EpisodeRegComponent,
      EpisodeComponent,
      EpisodeAllComponent,
      Upload2Component,
      TestDownloadComponent,
      EpisodeDownloadComponent,
      EpisodeEditComponent,
      ScreenplayEditComponent,
      UploadTest2Component,
      ChartFormatAllComponent,
      ChartFormatAll2Component,
      ChartStatusAllComponent
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
      //BackButtonDisableModule.forRoot(),
      MatTableModule,
      MatFormFieldModule,
      BrowserAnimationsModule,
      MatTableModule,
      MatPaginatorModule,
      MatSortModule,
      MatInputModule,
      MDBBootstrapModule.forRoot(),
      NgbModule,
      DataTablesModule,
      MaskedTextBoxModule,
      NumericTextBoxModule,
      // PdfViewerModule,
      FileUploadModule,
      ChartModule,
      AccumulationChartModule,
      ChartsModule
   ],
   providers: [
      AuthService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
