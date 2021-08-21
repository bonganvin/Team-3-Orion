import { AddVATComponent } from './Manager/VAT/add-vat/add-vat.component';
import { DeleteBranchComponent } from './Manager/Branch/branches/deleteBranch/delete-branch/delete-branch.component';
import { EditBranchComponent } from './Manager/Branch/branches/editBranch/edit-branch/edit-branch.component';
import { EditEmployeeComponent } from './Employee/edit-employee/edit-employee.component';
import { VATComponent } from './Manager/VAT/vat/vat.component';
import { ShiftsComponent } from './Manager/Shift/shifts/shifts.component';
import { ReportsComponent } from './Manager/Reports/reports/reports.component';
import { JobsComponent } from './Manager/Jobs/jobs/jobs.component';
import { CashRegisterComponent } from './Manager/CashRegister/cash-register/cash-register.component';
import { BranchesComponent } from './Manager/Branch/branches/branches.component';
import { AddEmployeeComponent } from './Employee/add-employee/add-employee.component';
import { RegisterComponent } from './Customer/RegisterCusomter/register/register.component';
import { CustomersComponent } from './Customer/customers/customers.component';
import { LoginComponent } from './Login/login/login.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './Product/products/products.component';
import { EmployeesComponent } from './Employee/employees/employees.component';
import { AddUserComponent } from './User/add-user/add-user.component';
import { ManagerComponent } from './Manager/manager/manager.component';
import { AddBranchComponent } from './Manager/Branch/branches/AddBranch/add-branch/add-branch.component';

const routes: Routes = [
  {
    path: '',
    component: ProductsComponent
  },
  {
    path: 'Login',
    component: LoginComponent
  },
  {
    path: 'AddCustomer',
    component: CustomersComponent
  },
  {
    path: 'Register',
    component: RegisterComponent
  },
  {
    path: 'Employee',
    component: EmployeesComponent
  },
  {
    path: 'AddEmployee',
    component: AddEmployeeComponent
  },
  {
    path: 'AddUser',
    component: AddUserComponent
  },
  {
    path: 'Manager',
    component: ManagerComponent
  },
  {
    path: 'Branch',
    component: BranchesComponent
  },  
  {
    path: 'AddBranch',
    component: AddBranchComponent
  },
  {
    path: 'CashRegster',
    component: CashRegisterComponent
  },  
  {
    path: 'Jobs',
    component: JobsComponent
  }, 
   {
    path: 'Reports',
    component: ReportsComponent
  },  
  {
    path: 'Shift',
    component: ShiftsComponent
  },  
  {
    path: 'VAT',
    component: VATComponent
  },
  {
    path: 'AddVAT',
    component: AddVATComponent
  },
  {
    path: 'EditEmployee',
    component: EditEmployeeComponent
  },
  {
    path: 'editBranch',
    component: EditBranchComponent
  },
    {
    path: 'deleteBranch',
    component: DeleteBranchComponent
  },

]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
