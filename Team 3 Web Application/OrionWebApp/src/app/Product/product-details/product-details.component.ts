import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ServicesService } from 'src/app/service/Services/services.service';
import { InterfacesService , Product, ProductCategory } from 'src/app/service/Interface/interfaces.service';
import { Observable } from 'rxjs';
import {MatMenuModule, MatMenuTrigger} from '@angular/material/menu';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  observeProductDetails: Observable<Product[]> = this.service.getProducts();
  ProductData!: Product[];
  constructor(private route: Router , private service : ServicesService , private interfaces : InterfacesService) { }

  ngOnInit(): void {
    this.observeProductDetails.subscribe(res => {
      this.ProductData = res;
      console.log(res);
      
    })
  }


  DisplayProduct(catid : number)
  {
    let ProductTypeID: number[] =  [];
    let ProductTypeName: string[] =  [];
    let ProductID: number[] =  [];
    this.service.GetProductByID(catid).subscribe(x=>
    {
      console.log(x);
      this.ProductData=x;
      ProductID= x.map(x => x.ProductID);

    })
  }

  openLogin(){
    this.route.navigateByUrl("Login")
  }

}
