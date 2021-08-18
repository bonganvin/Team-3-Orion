import { AddEmployeeComponent } from './Employee/add-employee/add-employee.component';
import { RegisterComponent } from './Customer/RegisterCusomter/register/register.component';
import { CustomersComponent } from './Customer/customers/customers.component';
import { LoginComponent } from './Login/login/login.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './Product/products/products.component';
import { EmployeesComponent } from './Employee/employees/employees.component';
import { AddUserComponent } from './User/add-user/add-user.component';

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
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
