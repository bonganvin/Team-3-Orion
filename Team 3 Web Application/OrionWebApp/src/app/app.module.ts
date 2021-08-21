import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Login/login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HttpClientModule } from '@angular/common/http';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatDialogModule , MatDialogRef} from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSelectModule } from '@angular/material/select';
import { MatCardModule} from '@angular/material/card';
import { MatNativeDateModule } from '@angular/material/core';
import {MatButtonModule} from '@angular/material/button';
import { ProductsComponent } from './Product/products/products.component';
import { CustomersComponent } from './Customer/customers/customers.component';
import {MatIconModule} from '@angular/material/icon';
import {MatMenuModule} from '@angular/material/menu';
import { OpenDialogComponent } from './Dialog/open-dialog/open-dialog.component';
import { RegisterComponent } from './Customer/RegisterCusomter/register/register.component';
import { EmployeesComponent } from './Employee/employees/employees.component';
import { AddEmployeeComponent } from './Employee/add-employee/add-employee.component';
import { AddUserComponent } from './User/add-user/add-user.component';
import { ManagerComponent } from './Manager/manager/manager.component';
import { BranchesComponent } from './Manager/Branch/branches/branches.component';
import { CashRegisterComponent } from './Manager/CashRegister/cash-register/cash-register.component';
import { JobsComponent } from './Manager/Jobs/jobs/jobs.component';
import { ReportsComponent } from './Manager/Reports/reports/reports.component';
import { ShiftsComponent } from './Manager/Shift/shifts/shifts.component';
import { VATComponent } from './Manager/VAT/vat/vat.component';
import { EditEmployeeComponent } from './Employee/edit-employee/edit-employee.component';
import { AddVATComponent } from './Manager/VAT/add-vat/add-vat.component';
import { AddBranchComponent } from './Manager/Branch/branches/AddBranch/add-branch/add-branch.component';
import { EditBranchComponent } from './Manager/Branch/branches/editBranch/edit-branch/edit-branch.component';
import { DeleteBranchComponent } from './Manager/Branch/branches/deleteBranch/delete-branch/delete-branch.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ProductsComponent,
    CustomersComponent,
    OpenDialogComponent,
    RegisterComponent,
    EmployeesComponent,
    AddEmployeeComponent,
    AddUserComponent,
    ManagerComponent,
    BranchesComponent,
    CashRegisterComponent,
    JobsComponent,
    ReportsComponent,
    ShiftsComponent,
    VATComponent,
    EditEmployeeComponent,
    AddVATComponent,
    AddBranchComponent,
    EditBranchComponent,
    DeleteBranchComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule, 
    MatAutocompleteModule,
    MatDialogModule,
    CommonModule,
    MatDatepickerModule,
    MatSelectModule,
    MatInputModule,
    MatMenuModule,
    MatDatepickerModule,
    MatIconModule,
    FormsModule,
    ReactiveFormsModule,
    MatNativeDateModule,
    MatSnackBarModule,
    MatDialogModule,
    MatCardModule,
    MatButtonModule, 
    HttpClientModule,
    
  ],
  providers: [{provide: MatDialogRef,
    useValue: {}}
    
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
