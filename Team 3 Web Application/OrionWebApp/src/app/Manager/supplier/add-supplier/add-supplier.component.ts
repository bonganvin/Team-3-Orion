import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ServicesService } from 'src/app/service/Services/services.service';

@Component({
  selector: 'app-add-supplier',
  templateUrl: './add-supplier.component.html',
  styleUrls: ['./add-supplier.component.scss']
})
export class AddSupplierComponent implements OnInit {

  form: FormGroup = this.fb.group({
    SupplierName: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
    SupplierPhoneNumber: ['', Validators.compose([Validators.required, Validators.maxLength(10), Validators.minLength(10)])],
    SupplierAddress: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
  });

  constructor(private service: ServicesService, private fb: FormBuilder, 
    private snack: MatSnackBar, private dialogRef: MatDialogRef<AddSupplierComponent>,
    private router: Router) { }

  ngOnInit(): void {
  }

  CreateSupplier(){
    this.service.RegisterSupplier(this.form.value).subscribe((res:any) => {
     // this.dialogRef.close();
console.log(res)
      if (res.Success===false)
      {
        this.snack.open('Supplier not added.', 'OK', {
          verticalPosition: 'bottom',
          horizontalPosition: 'center',
          duration: 3000
        });
        this.form.reset();
        return;
      }

      else if (res.Success===true)
      {
        this.snack.open('Successful Added Supplier', 'OK', {
          horizontalPosition: 'center',
          verticalPosition: 'bottom',
          duration: 3000
        });
        this.router.navigateByUrl("Suppliers")
        console.log(res);
        
      }
    }, (error: HttpErrorResponse) => {
      if (error.status === 403) {
        this.snack.open('This Supplier has already exists.', 'OK', {
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
    this.router.navigateByUrl("Supplier")
  }

}
