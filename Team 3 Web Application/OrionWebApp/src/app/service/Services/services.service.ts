import { Branches, CashRegister, Discount, EmployeeType, Product, RawMaterial, Unit, Recipe, Supplier, JobStatus, Job } from './../Interface/interfaces.service';
import { BehaviorSubject } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User, UserAccess, Customer, ProductType, ProductCategory, Employee, VAT } from '../Interface/interfaces.service';

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

  AddUser(user: User) {
    return this.http.post(`${this.server}User/CreateUser`, user, this.httpOptions);
  }

  GetUser(): Observable<User[]> {
    return this.http.get<User[]>(`${this.server}User/GetUser`).pipe(map(res => res));
  }
  //Login
  sendUserLogin(user: User) {
    return this.http.post(`${this.server}User/Login`, user, this.httpOptions);
  }

  //UserPermission
  getUserPermission(): Observable<UserAccess[]> {
    return this.http.get<UserAccess[]>(`${this.server}UserAccess/GetUserAccess`)
      .pipe(map(res => res));
  }

  //get ID
  GetUserAccessByID(UserAccessID: number) {
    return this.http.post(`${this.server}UserAccess/getUserAccessByID/` + UserAccessID, this.httpOptions);
  }

  DeleteUserAccess(userAccessId: number) {

    return this.http.delete(`${this.server}UserAccess/DeleteUserAccess/` + userAccessId,
      this.httpOptions);
  }

  //Customer

  //Register Customer 
  RegisterCustomer(customer: Customer) {
    return this.http.post(`${this.server}Customer/CreateCustomer`, customer, this.httpOptions);
  }

  //Get Customer
  getCustomer(): Observable<Customer[]> {
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

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.server}Product/GetProduct`)
      .pipe(map(res => res));
  }

  GetProductByTypeID(typeID: number) {
    return this.http.get<Product[]>(`${this.server}Product/getProductByCatTypeID/ ${typeID}`).pipe(map(res => res));
  }

  GetProductByID(ID: number) {
    return this.http.get<Product[]>(`${this.server}Product/GetProductsByID/ ${ID}`).pipe(map(res => res));
    //return this.http.post(`${this.server}Product/GetProductsByID/`+ ID ,this.httpOptions);
  }



  DeleteProducts(productId: number) {
    return this.http.delete(`${this.server}Product/DeleteProduct/` + productId,
      this.httpOptions);
  }

  getTestProduct(product: FormData) {
    return this.http.get(`${this.server}Product/CreateProduct`)
      .pipe(map(res => res));
  }

  //Product Category

  getCategories(): Observable<ProductCategory[]> {
    return this.http.get<ProductCategory[]>(`${this.server}ProductCategory/GetProductCategory`)
      .pipe(map(res => res));
  }



  //AddCategory
  CreateCategory(category: ProductCategory) {
    return this.http.post(`${this.server}ProductCategory/CreateProductCategory`, category, this.httpOptions);
  }


  DeleteCategory(catId: number) {
    return this.http.delete(`${this.server}ProductCategory/DeleteProductCatagory/` + catId,
      this.httpOptions);
  }

  //Product Type 

  getProductTypes(): Observable<ProductType[]> {
    return this.http.get<ProductType[]>(`${this.server}ProductType/GetProductType`)
      .pipe(map(res => res));
  }
  // get Product Types by Cat id
  GetProductTypesByCatID(CatID: number) {
    return this.http.get<ProductType[]>(`${this.server}ProductType/getProductTypeCategoryID/ ${CatID}`).pipe(map(res => res));
  }
  //Create Product type
  CreateProductType(type: ProductType) {
    return this.http.post(`${this.server}ProductType/CreateProductType`, type, this.httpOptions);
  }


  DeleteProductType(typeId: number) {
    return this.http.delete(`${this.server}ProductType/DeleteProductType/` + typeId,
      this.httpOptions);
  }


  //Employee Typescript
  getEmployeeType(): Observable<EmployeeType[]> {
    return this.http.get<EmployeeType[]>(`${this.server}EmployeeType/GetEmployeeType`)
      .pipe(map(res => res));
  }

  RegisterEmployeeType(employee: EmployeeType) {
    return this.http.post(`${this.server}EmployeeType/CreateEmployeeType`, employee, this.httpOptions);
  }

  DeleteEmployeeType(typeId: number) {
    return this.http.delete(`${this.server}EmployeeType/DeleteEmployeeType/` + typeId,
      this.httpOptions);
  }

  //Employee

  //Get Employee
  getEmployee(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.server}Employee/GetEmployee`)
      .pipe(map(res => res));
  }

  //Create EmployeesComponent
  RegisterEmployee(employee: Employee) {
    return this.http.post(`${this.server}Employee/CreateEmployee`, employee, this.httpOptions);
  }

  //Update Employee
  UpdateEmployee(employee: Employee): Observable<any> {
    return this.http.post(`${this.server}Employee/UpdateEmployee`, employee, this.httpOptions);
  }

  //Delete Employee
  deleteEmployee(employeeid: number) {
    return this.http.delete(`${this.server}Employee/DeleteEmployee/` + employeeid,
      this.httpOptions);
  }


  //VAT 
  //Get VAT
  getVAT(): Observable<VAT[]> {
    return this.http.get<VAT[]>(`${this.server}VAT/GetVAT`)
      .pipe(map(res => res));
  }

  //Create VAT 
  CreateVAT(vat: VAT) {
    return this.http.post(`${this.server}VAT/AddVAT`, vat, this.httpOptions);
  }

  //Branch
  //Get Branch
  getBranch(): Observable<Branches[]> {
    return this.http.get<Branches[]>(`${this.server}Branch/GetBranch`)
      .pipe(map(res => res));
  }
  // get branch by id
  GetBranchByID(BranchID: number) {
    return this.http.post(`${this.server}Branch/GetBranchByID/` + BranchID, this.httpOptions);
  }

  //Create Branch
  CreateBranch(branches: Branches) {
    return this.http.post(`${this.server}Branch/CreateBranch`, branches, this.httpOptions);
  }

  //Update Branch
  UpdateBranch(branches: Branches): Observable<Branches> {
    return this.http.put<Branches>(`${this.server}Branch/UpdateBranch`, branches, this.httpOptions);
  }

  //Remove Branch
  removeBranch(branchid: number) {

    return this.http.delete(`${this.server}Branch/DeleteBranch/` + branchid,
      this.httpOptions);
  }

  //Cash Register

  //get cash -register
  getCashRegister(): Observable<CashRegister[]> {
    return this.http.get<CashRegister[]>(`${this.server}CashRegister/GetCashRegister`)
      .pipe(map(res => res));
  }


  //Create Branch
  CreateCashRegister(register: CashRegister) {
    return this.http.post(`${this.server}CashRegister/CreateCashRegister`, register, this.httpOptions);
  }

  //Update Branch
  UpdateCashRegister(register: CashRegister): Observable<any> {
    return this.http.post(`${this.server}CashRegister/UpdateCashRegister`, register, this.httpOptions);
  }

  //Remove Cash Register
  removeCashRegister(CashRegisterID: number) {
    return this.http.delete(`${this.server}CashRegister/DeleteCashRegister/` + CashRegisterID,
      this.httpOptions);
  }

  //AddCategory
  CreateProduct(product: FormData) {
    return this.http.post(`${this.server}Product/CreateProduct`, product, this.httpOptions);
  }

  //Raw Materials
  //Get Raw Materials
  getRawMaterials(): Observable<RawMaterial[]> {
    return this.http.get<RawMaterial[]>(`${this.server}rawmaterials/Getrawmaterials`)
      .pipe(map(res => res));
  }

  //Create Raw Materials
  CreateRawMaterials(rawmaterials: RawMaterial) {
    return this.http.post(`${this.server}rawmaterials/CreateRawMaterial`, rawmaterials, this.httpOptions);
  }

  //Update Raw Materials
  UpdateRawMaterials(rawmaterials: RawMaterial): Observable<any> {
    return this.http.post(`${this.server}rawmaterials/UpdateRawMaterial`, rawmaterials, this.httpOptions);
  }

  //Delete Raw Materials 
  removeRM(RMID: number) {
    return this.http.delete(`${this.server}rawmaterials/DeleteRawMaterial/` + RMID,
      this.httpOptions);
  }

  getUnit(): Observable<Unit[]> {
    return this.http.get<Unit[]>(`${this.server}unit/GetUnit`)
      .pipe(map(res => res));
  }



  //Discount
  //Get Discount
  getDiscount(): Observable<Discount[]> {
    return this.http.get<Discount[]>(`${this.server}discount/GetDiscount`)
      .pipe(map(res => res));
  }
  // get Discount by id
  GetDiscountByID(DiscountID: number) {
    return this.http.post(`${this.server}discount/getDiscountByID/` + DiscountID, this.httpOptions);
  }

  //Create Discount
  CreateDiscount(Discounts: Discount) {
    return this.http.post(`${this.server}discount/CreateDiscount`, Discounts, this.httpOptions);
  }

  //Update Discount
  UpdateDiscount(Discounts: Discount): Observable<Discount> {
    return this.http.put<Discount>(`${this.server}discount/updatediscount`, Discounts, this.httpOptions);
  }


  DeleteDiscount(DiscountID: number) {

    return this.http.delete(`${this.server}discount/DeleteDiscount/` + DiscountID,
      this.httpOptions);
  }

  //Recipe
  //Get Recipe
  getRecipe(): Observable<Recipe[]> {
    return this.http.get<Recipe[]>(`${this.server}Recipe/GetRecipe`)
      .pipe(map(res => res));
  }
  // get Recipe by id
  GetRecipeByID(RecipeID: number) {
    return this.http.post(`${this.server}Recipe/getRecipeByID/` + RecipeID, this.httpOptions);
  }

  //Create Recipe
  CreateRecipe(Recipe: Recipe) {
    return this.http.post(`${this.server}Recipe/CreateRecipe`, Recipe, this.httpOptions);
  }

  //Update Discount
  UpdateRecipe(Recipe: Recipe): Observable<Recipe> {
    return this.http.put<Recipe>(`${this.server}Recipe/UpdateRecipe`, Recipe, this.httpOptions);
  }

  //Delete Recipe
  DeleteRecipe(RecipeID: number) {
    return this.http.delete(`${this.server}Recipe/DeleteRecipe/` + RecipeID,
      this.httpOptions);
  }


    //Get Supplier
    getSupplier(): Observable<Supplier[]> {
      return this.http.get<Supplier[]>(`${this.server}Supplier/GetSupplierr`)
        .pipe(map(res => res));
    }
  
    //Create Supplier
    RegisterSupplier(Supplier: Supplier) {
      return this.http.post(`${this.server}Supplier/CreateSupplier`, Supplier, this.httpOptions);
    }
  
    //Update Supplier
    UpdateSupplier(Supplier: Supplier): Observable<any> {
      return this.http.post(`${this.server}Supplier/UpdateSupplier`, Supplier, this.httpOptions);
    }
  
    //Delete Supplier
    deleteSupplier(Supplierid: number) {
      return this.http.delete(`${this.server}Supplier/DeleteSupplier/` +Supplierid,
        this.httpOptions);
    }

//Job Status
    getJobStatus(): Observable<JobStatus[]> {
      return this.http.get<JobStatus[]>(`${this.server}JobStatus/GetJobStatus`)
        .pipe(map(res => res));
    }
  
  
  //Create Job
    CreateJob(job: Job) {
      return this.http.post(`${this.server}Job/CreateJob`, job, this.httpOptions);
    }
}
