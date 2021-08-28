import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class InterfacesService {

  constructor() { }

}

export interface User {
  UserID: number;
  UserPassword: string;
  UserName: string;
  UserRoleDesc: string;
  UserAccessPermissionID: number;
}

export interface UserAccess{
  UserAccessPermissionID: number;
  UserRoleName: string;
  UserRoleDescription: string;
}

export interface Customer {
CustomerId: number;
CustomerName: string;
CustomerSurname : string;
CustomerCellphoneNumber : number ;
CustomerDateOfBirth : Date;
CustomerEmailAddress: string ;
CustomerPhysicalAddress : string ;
}




export interface ProductCategory {
ProductCategoryID : number;
ProductCategoryName: string;

}

export interface ProductType {
  ProductTypeID: number;
  ProductTypeName: string;
  ProductCategoryID: number;
}

export interface Employee{
  EmployeeID: number;
  UserID: number;
  EmployeeTypeID: number;
  EmployeeName: String;
  EmployeeSurname: String;
  EmployeePhoneNumber: number;
  EmployeeEmailAddress: string;

}




export interface VAT {
  VATID : number;
  VATDate : Date ;
  VATPercentage: number;
}

export interface Branches{
  BranchID: number;
  BranchName: string;
  BranchLocationStorageCapacity: number;
  BranchAddress: string;
}

export interface Product{
  ProductID: number;
  ProductName : string;
  ProductDescription: string;
  ProductImage: any;
  ProductTypeID: number;
  Quantityonhand:number;
}


export interface CashRegister{
  RegisterID: number;
  CashRegisterName: string;
  BranchID: number;
}

export interface RawMaterial{
  RawMaterialID : number;
  RawMaterialName : string;
  QuantityOnhand : number;
  Rawmaterialdescription: string;
  UnitID : number;
}


export interface Unit {
  UnitID : number;
  UnitMeasurement: string;
}


export interface Discount {
  DiscountID : number;
  DiscountName: string;
  DiscountDescription: string;
  DiscountPercentage: number;
}

export interface EmployeeType{

  EmployeeTypeID: number;
  EmployeeTypeDescription: string;
}

export interface Recipe{
  RecipeID: number;
  RecipeDescription: string;
  QuantityProduced: number;
  RecipeName: string;
}

export interface Supplier{
  SupplierID : number;
  SupplierName : string;
  SupplierPhoneNumber: number;
  SupplierAddress: string;
}