import { Component, OnInit } from '@angular/core';
import { Router , ActivatedRoute} from '@angular/router';
import { ServicesService } from 'src/app/service/Services/services.service';
import { InterfacesService, Product, ProductCategory, ProductSize } from 'src/app/service/Interface/interfaces.service';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  productID!: number;
  product_id!: string;
  ProductName!: string;
 observeProductD: Observable<any> = this.service.GetProductByID(this.productID);
 ProductdData!:any ;
// product!: Product[];

 observeProduct: Observable<ProductSize[]> = this.service.getProductSizes();
 ProductData!: any;


  constructor(private route: Router , 
    private service : ServicesService ,
     private interfaces : InterfacesService,
     private actRoute: ActivatedRoute) { 
      if (this.actRoute.snapshot.params["id"]) {  
        this.productID = this.actRoute.snapshot.params["id"];  
    } 
    this.product_id = this.actRoute.snapshot.params.id;
    this.ProductName = this.actRoute.snapshot.params.id;
     }

  ngOnInit(): void {

    this.service.GetProductSizeByProductID(this.productID).subscribe(x=>
      {
        console.log(x);
        this.ProductData=x;
    
      })
  
  }

  DisplayProductDetails(catid : number)
  {
    this.service.GetProductByID(catid).subscribe(x=>
    {
      console.log(x);
      this.ProductData=x;
  
    })
 
  }

  // DisplayProductSizes(id : number)
  // {
  //   this.service.GetProductSizesBySizeID(id).subscribe(x=>
  //     {
  //       this.ProductData=x;
  //     })

  // }

  


  openLogin(){
    this.route.navigateByUrl("Login")
  }

}
