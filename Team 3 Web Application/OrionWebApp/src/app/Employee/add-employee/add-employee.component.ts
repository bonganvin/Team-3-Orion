import { ServicesService } from './../../service/Services/services.service';
import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { OpenDialogComponent } from 'src/app/Dialog/open-dialog/open-dialog.component';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.scss']
})
export class AddEmployeeComponent implements OnInit {

  form: FormGroup = this.fb.group({
    EmployeeName: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
    EmployeeSurname: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
    EmployeePhoneNumber: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
    EmployeeEmailAddress: ['', Validators.compose([Validators.required, Validators.email])],
  });

  constructor(private service: ServicesService, private fb: FormBuilder, 
    private snack: MatSnackBar, private dialogRef: MatDialogRef<AddEmployeeComponent>,
    private router: Router) { }

  ngOnInit(): void {
  }

  RegisterEmployee() {
    this.service.RegisterEmployee(this.form.value).subscribe(res => {
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
