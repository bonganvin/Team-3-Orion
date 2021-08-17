import { OpenDialogComponent } from './../../Dialog/open-dialog/open-dialog.component';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServicesService } from 'src/app/service/Services/services.service';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  

  constructor(private route: Router , private service : ServicesService) { }

  ngOnInit(): void {
  }
  

  openLogin(){
    this.route.navigateByUrl("Login")
  }

  displayProductCategory(){

    let CatagoryID: number[] =  [];
    let CatagoryName: string[] =  [];

    this.service.getCategories().subscribe(x => {
       CatagoryID= x.map(x => x.ProductCategoryID);
       CatagoryName = x.map(x => x.ProductCategoryName)
    })
  }

  displayProductType(){
    let ProductTypeID: number[] =  [];
    let ProductTypeName: string[] =  [];
    let CatagoryID: number[] =  [];

    this.service.getProductTypes().subscribe(x => {
      ProductTypeID= x.map(x => x.ProductTypeID);
      ProductTypeName = x.map(x => x.ProductTypeName);
      CatagoryID= x.map(x => x.CategoryID);

      CatagoryID = ProductTypeID;
    })
  }
}
