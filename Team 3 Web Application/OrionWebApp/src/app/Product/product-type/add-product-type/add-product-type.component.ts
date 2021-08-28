import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ProductCategory, ProductType } from 'src/app/service/Interface/interfaces.service';
import { ServicesService } from 'src/app/service/Services/services.service';

@Component({
  selector: 'app-add-product-type',
  templateUrl: './add-product-type.component.html',
  styleUrls: ['./add-product-type.component.scss']
})
export class AddProductTypeComponent implements OnInit {

  form: FormGroup = this.fb.group({
    ProductTypeName: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
    ProductCategoryID: ['', Validators.compose([Validators.required])],
  });

  constructor(private service: ServicesService, private fb: FormBuilder,
    private snack: MatSnackBar, private dialogRef: MatDialogRef<AddProductTypeComponent>,
    private router: Router) { }


  observeData: Observable<ProductCategory[]> = this.service.getCategories();
  CategoryData!: ProductCategory[];
  CategoryParams: ProductCategory = {
    ProductCategoryName: '',
    ProductCategoryID: 0,
  }

  ngOnInit(): void {
    this.observeData.subscribe(res => {
      this.CategoryData = res;
    })
  }

  CreateProductType()
  {
    this.service.CreateProductType(this.form.value).subscribe((res:any) => {
      if (res.Success===false)
      {
        this.snack.open('Product Type not created.', 'OK', {
          verticalPosition: 'bottom',
          horizontalPosition: 'center',
          duration: 3000
        });
        this.form.reset();
        return;
      }

      else if (res.Success===true)
      {
        this.snack.open('Successful Added Product Type', 'OK', {
          horizontalPosition: 'center',
          verticalPosition: 'bottom',
          duration: 3000
        });
        this.router.navigateByUrl("ProductType")
        console.log(res);
        
      }
    }, (error: HttpErrorResponse) => {
      if (error.status === 403) {
        this.snack.open('This branch has already exists.', 'OK', {
          horizontalPosition: 'center',
          verticalPosition: 'bottom',
          duration: 3000
        });
      }
      this.snack.open('An error occurred on our servers, try again', 'OK', {
        horizontalPosition: 'center',
        verticalPosition: 'bottom',
        duration: 3000
      });
     //this.dialogRef.close();
    })
  }


  back(){
    this.router.navigateByUrl("ProductType")
  }
}
