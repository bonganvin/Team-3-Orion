import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class InterfacesService {

  constructor() { }

}

export interface User {
  UserId: number;
  UserPassword: string;
  UserName: string;
  UserRoleDesc: string;
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

export interface UserAccess {
  UserAccessID: number;
  UserRoleName: string;
  UserRoleDesc: string;
}


export interface ProductCategory {
ProductCategoryID : number;
ProductCategoryName: string;

}

export interface ProductType {
  ProductTypeID: number;
  ProductTypeName: string;
  CategoryID: number;
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

export interface EmployeeType{
  EmployeeTypeID: number;
  EmployeeDescription: number;
}