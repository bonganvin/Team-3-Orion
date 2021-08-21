import { Branches } from './../Interface/interfaces.service';
import { BehaviorSubject } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User, UserAccess ,Customer, ProductType, ProductCategory, Employee, VAT} from '../Interface/interfaces.service';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {

    //Local host server
    server = 'https://localhost:44387/api/';
    
    httpOptions = {
      headers: new HttpHeaders({
        ContentType: 'application/json'
      })
  };
  constructor(private http: HttpClient) { }
//

AddUser(user: User){
  return this.http.post(`${this.server}User/CreateUser`, user, this.httpOptions);
}
  //Login
  sendUserLogin(user: User){
    return this.http.post(`${this.server}User/Login`, user, this.httpOptions);
  }

  //UserPermission
  getUserPermission(): Observable<UserAccess[]>{
    return this.http.get<UserAccess[]>(`${this.server}UserAccess/GetUserAccess`)
    .pipe(map(res => res));
  }

  //Customer

  //Register Customer 
  RegisterCustomer(customer: Customer) {
    return this.http.post(`${this.server}Customer/CreateCustomer`,customer, this.httpOptions);
  }

  //Get Customer
  getCustomer():  Observable<Customer[]> {
    return this.http.get<Customer[]>(`${this.server}Customer/GetCustomer`)
    .pipe(map(res => res));
  }

  //Update Customers
    updateCustomer(customer: Customer): Observable<any> {
      return this.http.post(`${this.server}Customer/UpdateCustomer`, customer, this.httpOptions);
    }
  
    //Delete Employee
    deleteCusotmer(toRemove: Customer): void {
      let _bs = new BehaviorSubject<Customer[]>([]);
      let customer = [..._bs.getValue()];
      const index = customer.findIndex(x => x.CustomerId === toRemove.CustomerId);
  
      if (index > -1) {
        customer.splice(index, 1);
        _bs.next(customer);
      }
    }

  //Product 

  //Product Category

  getCategories():  Observable<ProductCategory[]> {
    return this.http.get<ProductCategory[]>(`${this.server}ProductCategory/GetProductCategory`)
    .pipe(map(res => res));
  }

  //Product Type 


  getProductTypes():  Observable<ProductType[]> {
    return this.http.get<ProductType[]>(`${this.server}ProductType/GetProductType`)
    .pipe(map(res => res));
  }

  //Employee

  //Get Employee
  getEmployee(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.server}Employee/GetEmployee`)
    .pipe(map(res => res));
  }

  //Create EmployeesComponent
  RegisterEmployee(employee: Employee){
    return this.http.post(`${this.server}Employee/CreateEmployee`, employee, this.httpOptions);
  }

  //Update Employee
  UpdateEmployee(employee: Employee): Observable<any> {
    return this.http.post(`${this.server}Employee/UpdateEmployee`, employee, this.httpOptions);
  }

  //Delete Employee
  deleteEmployee(toRemove: Employee): void {
    let _bs = new BehaviorSubject<Employee[]>([]);
    let employee = [..._bs.getValue()];
    const index = employee.findIndex(x => x.EmployeeID === toRemove.EmployeeID);

    if (index > -1) {
      employee.splice(index, 1);
      _bs.next(employee);
    }
  }


  //VAT 
  //Get VAT
  getVAT(): Observable<VAT[]> {
    return this.http.get<VAT[]>(`${this.server}VAT/GetVAT`)
    .pipe(map(res => res));
  }

  //Create VAT 
  CreateVAT (vat: VAT) {
    return this.http.post(`${this.server}VAT/AddVAT`, vat, this.httpOptions);
  }

  //Branch
  //Get Branch
  getBranch(): Observable<Branches[]> {
    return this.http.get<Branches[]>(`${this.server}Branch/GetBranch`)
    .pipe(map(res => res));
  }

  //Create Branch
  CreateBranch (branches: Branches) {
    return this.http.post(`${this.server}Branch/CreateBranch`, branches, this.httpOptions);
  }

  //Update Branch
  UpdateBranch(branches: Branches): Observable<any> {
    return this.http.post(`${this.server}Branch/UpdateBranch`, branches, this.httpOptions);
  }

  //Delete Branch 
  deleteBranch(toRemove: Branches): void {
    let _bs = new BehaviorSubject<Branches[]>([]);
    let branches = [..._bs.getValue()];
    const index = branches.findIndex(x => x.BranchID === toRemove.BranchID);

    if (index > -1) {
      branches.splice(index, 1);
      _bs.next(branches);
    }
  }

}
