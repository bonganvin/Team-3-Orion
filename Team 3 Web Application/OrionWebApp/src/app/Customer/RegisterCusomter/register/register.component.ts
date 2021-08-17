import { OpenDialogComponent } from './../../../Dialog/open-dialog/open-dialog.component';
import { ServicesService } from './../../../service/Services/services.service';
import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  form: FormGroup = this.fb.group({
    CustomerName: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
    CustomerSurname: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
    CustomerCellphone: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
    EmailAddress: ['', Validators.compose([Validators.required, Validators.email])],
    CustomerAddress: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
    CustomerDateOfBirth: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
 
  });

  constructor(private service: ServicesService, private fb: FormBuilder, 
    private snack: MatSnackBar, private dialogRef: MatDialogRef<RegisterComponent>,
    private router: Router) { }

  ngOnInit(): void {
  }

  Register() {
    this.service.RegisterCustomer(this.form.value).subscribe(res => {
      this.dialogRef.close();
      this.snack.open('Successful registration', 'OK', {
        horizontalPosition: 'center',
        verticalPosition: 'bottom',
        duration: 3000
      });
    }, (error: HttpErrorResponse) => {
      if (error.status === 403) {
        this.snack.open('This user has already been registered.', 'OK', {
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
      this.dialogRef.close();
    })
  }

  back(){
    this.router.navigateByUrl("Login")
  }

}
