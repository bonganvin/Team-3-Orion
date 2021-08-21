import { ProductType } from './../../service/Interface/interfaces.service';
import { OpenDialogComponent } from './../../Dialog/open-dialog/open-dialog.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ServicesService } from 'src/app/service/Services/services.service';
import { InterfacesService , ProductCategory } from 'src/app/service/Interface/interfaces.service';
import { Observable } from 'rxjs';
import {MatMenuModule, MatMenuTrigger} from '@angular/material/menu';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {
  observeCategories: Observable<ProductCategory[]> = this.service.getCategories();
  CategoryData!: ProductCategory[];

  observeProductType: Observable<ProductType[]> = this.service.getProductTypes();
  TypeData!: ProductType[];

  check: boolean = true;
  
  constructor(private route: Router , private service : ServicesService , private interfaces : InterfacesService) { }

  ngOnInit(): void {
    this.observeCategories.subscribe(res => {
      this.CategoryData = res;
    })

    this.observeProductType.subscribe(res => {
      this.TypeData = res;
    })
  }
  
  @ViewChild('menuuTrigger')
  clickHoverMenuTrigger!: MatMenuTrigger;

  openOnMouseOver() {
    this.clickHoverMenuTrigger.openMenu();
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
      CatagoryID= x.map(x => x.ProductCategoryID);

      CatagoryID = ProductTypeID;
    })
  }
}
