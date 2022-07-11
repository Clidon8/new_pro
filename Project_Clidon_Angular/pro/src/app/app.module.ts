import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ClidonHomeComponent } from './components/clidon-home/clidon-home.component';
import { ClidonManagerPasswordComponent } from './components/clidon-manager-password/clidon-manager-password.component';
import { ClidonSingInComponent } from './components/clidon-sing-in/clidon-sing-in.component';
import { ClidonManagementOperationsComponent } from './components/clidon-management-operations/clidon-management-operations.component';
import { ClidonChangeManagerPasswordComponent } from './components/clidon-change-manager-password/clidon-change-manager-password.component';
import { ClidonTypedPageComponent } from './components/clidon-typed-page/clidon-typed-page.component';
import { ClidonViewFilesComponent } from './components/clidon-view-files/clidon-view-files.component';
import { ClidonPaymentComponent } from './components/clidon-payment/clidon-payment.component';
import { ClidonSaveAFileComponent } from './components/clidon-save-a-file/clidon-save-a-file.component';
import { ClidonEntranceComponent } from './components/clidon-entrance/clidon-entrance.component';
import { ClidonChangeUserPasswordComponent } from './components/clidon-change-user-password/clidon-change-user-password.component';
import { ClidonUserTableComponent } from './components/clidon-user-table/clidon-user-table.component';
import { ClidonUserManagementComponent } from './components/clidon-user-management/clidon-user-management.component';
import { ClidonIsManagerComponent } from './components/clidon-is-manager/clidon-is-manager.component';
import { Router, RouterModule, Routes } from '@angular/router';
import { ChildHomePageComponent } from './components/child-home-page/child-home-page.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule, DatePipe } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './Modules/material/material.module';
import { MatDialogModule } from '@angular/material/dialog';
import { UserManagementComponent } from './components/user-management/user-management.component';
import { NewhelloComponent } from './components/newhello/newhello.component';
import { UpdateFirstNameComponent } from './components/update-first-name/update-first-name.component';
import { UpdateLastnameComponent } from './components/update-lastname/update-lastname.component';
import { UpdatePasswordComponent } from './components/update-password/update-password.component';
import { DeletUserComponent } from './components/delet-user/delet-user.component';
import { AddDocumentComponent } from './add-document/add-document.component';
import { FilesComponent } from './files/files.component';
import {MatTabsModule} from '@angular/material/tabs';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';


// import { DeletUserComponent } from './delet-user/delet-user.component';
// import { UpdateFirstNameComponent } from './update-first-name/update-first-name.component';
// import { UpdatePasswordComponent } from './update-password/update-password.component';
// import { UpdateLastnameComponent } from './update-lastname/update-lastname.component';
// import { DocumentEditorContainerAllModule } from '@syncfusion/ej2-angular-documenteditor';
// import { DocumentEditorContainerAllModule } from '@syncfusion/ej2-angular-documenteditor';
import { NgxDocViewerModule } from 'ngx-doc-viewer';
import { DialogtextComponent } from './dialogtext/dialogtext.component';
const appRoutes:Routes=[
{path:'clidon-home',component:ClidonHomeComponent},
{path:'clidon-sing-in',component:ClidonSingInComponent},
{path:'clidon-entrance',component:ClidonEntranceComponent},
{path:'clidon-manager-password',component:ClidonManagerPasswordComponent},
{path:'child-home-page',component:ChildHomePageComponent},
{path:'clidon-typed-page',component:ClidonTypedPageComponent},
{path:'clidon-change-user-password',component:ClidonChangeUserPasswordComponent},
{path:'clidon-management-operations',component:ClidonManagementOperationsComponent},
{path:'clidon-user-management',component:ClidonUserManagementComponent},
{path:'clidon-change-manager-password',component:ClidonChangeManagerPasswordComponent},
{path:'clidon-is-manager',component:ClidonIsManagerComponent},
{path:'clidon-payment',component:ClidonPaymentComponent},
{path:'clidon-user-table',component:ClidonUserTableComponent}
]


@NgModule({
  declarations: [
    AppComponent,
    ClidonHomeComponent,
    ClidonManagerPasswordComponent,
    ClidonSingInComponent,
    ClidonManagementOperationsComponent,
    ClidonChangeManagerPasswordComponent,
    ClidonTypedPageComponent,
    ClidonViewFilesComponent,
    ClidonPaymentComponent,
    ClidonSaveAFileComponent,
    ClidonEntranceComponent,
    ClidonChangeUserPasswordComponent,
    ClidonUserTableComponent,
    ClidonUserManagementComponent,
    ClidonIsManagerComponent,
    ChildHomePageComponent,
    UserManagementComponent,
    NewhelloComponent,
    UpdateFirstNameComponent,
    UpdatePasswordComponent,
    UpdateLastnameComponent,
    DeletUserComponent,
    AddDocumentComponent,
    FilesComponent,
    DialogtextComponent

  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    HttpClientModule,
    CommonModule,
    RouterModule,
    BrowserAnimationsModule,
    MaterialModule,
    MatDialogModule,
    // DocumentEditorContainerAllModule
    NgxDocViewerModule,
    MatTabsModule,
    MatProgressSpinnerModule
  ],
  //ספקי מידע-כל הסרויסים
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
