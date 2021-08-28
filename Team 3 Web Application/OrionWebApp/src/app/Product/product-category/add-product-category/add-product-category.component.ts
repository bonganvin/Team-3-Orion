import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ServicesService } from 'src/app/service/Services/services.service';

@Component({
  selector: 'app-add-product-category',
  templateUrl: './add-product-category.component.html',
  styleUrls: ['./add-product-category.component.scss']
})
export class AddProductCategoryComponent implements OnInit {

  form: FormGroup = this.fb.group({
    ProductCategoryName: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
  });

  constructor(private service: ServicesService, private fb: FormBuilder, 
    private snack: MatSnackBar, private dialogRef: MatDialogRef<AddProductCategoryComponent>,
    private router: Router) { }

  ngOnInit(): void {
  }

  CreateCategory(){
    this.service.CreateCategory(this.form.value).subscribe((res:any) => {
     // this.dialogRef.close();

      if (res.Success===false)
      {
        this.snack.open('Category not added.', 'OK', {
          verticalPosition: 'bottom',
          horizontalPosition: 'center',
          duration: 3000
        });
        this.form.reset();
        return;
      }

      else if (res.Success===true)
      {
        this.snack.open('Successful Added Product Category', 'OK', {
          horizontalPosition: 'center',
          verticalPosition: 'bottom',
          duration: 3000
        });
        this.router.navigateByUrl("ProductCategory")
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
    this.router.navigateByUrl("ProductCategory")
  }

}
