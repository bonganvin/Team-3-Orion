import { Product } from 'src/app/service/Interface/interfaces.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ServicesService } from 'src/app/service/Services/services.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-manage-products',
  templateUrl: './manage-products.component.html',
  styleUrls: ['./manage-products.component.scss']
})
export class ManageProductsComponent implements OnInit {

  observeData: Observable<Product[]> = this.service.getProducts();
  ProductData!: Product[];

  constructor(private service: ServicesService, private fb: FormBuilder, 
    private snack: MatSnackBar, private dialogRef: MatDialog,
    private router: Router) { }

  ngOnInit(): void {
    this.observeData.subscribe(res => {
      this.ProductData = res;
    })
  }

  AddProduct(){
    this.router.navigateByUrl("AddProduct")
  }

  editProduct(){
    this.router.navigateByUrl("EditProduct")
  }

  deleteProduct(productId:number){
    this.service.DeleteProducts(productId).subscribe((res: any) => {
      console.log(res);
      if (res.Success === false) {
        this.snack.open('Product not deleted.', 'OK', {
          verticalPosition: 'bottom',
          horizontalPosition: 'center',
          duration: 3000
        });

        return;
      }

      else if (res.Success === true) {
        this.snack.open('Successful Deleted Product', 'OK', {
          horizontalPosition: 'center',
          verticalPosition: 'bottom',
          duration: 3000
        });
      }
      window.location.reload();
    });
  }

}
