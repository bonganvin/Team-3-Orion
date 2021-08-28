import { EmployeeType } from './../../service/Interface/interfaces.service';
import { ServicesService } from './../../service/Services/services.service';
import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { OpenDialogComponent } from 'src/app/Dialog/open-dialog/open-dialog.component';
import { Observable } from 'rxjs';

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
    EmployeeTypeID: ['', Validators.compose([Validators.required])],
  });

  constructor(private service: ServicesService, private fb: FormBuilder, 
    private snack: MatSnackBar, private dialogRef: MatDialogRef<AddEmployeeComponent>,
    private router: Router) { }

    observeData: Observable<EmployeeType[]> = this.service.getEmployeeType();
    EmployeeTypeData!: EmployeeType[];
    EmployeeTypeParams : EmployeeType = {
      EmployeeTypeID: 0,
      EmployeeTypeDescription:'',
    }

  ngOnInit(): void {
    this.observeData.subscribe(res => {
      this.EmployeeTypeData = res;
    })
  }

  RegisterEmployee() {
    this.service.RegisterEmployee(this.form.value).subscribe((res:any) => {
     

      if (res.Success===false)
      {
        this.snack.open('Registration cancelled.', 'OK', {
          verticalPosition: 'bottom',
          horizontalPosition: 'center',
          duration: 3000
        });
        this.form.reset();
        return;
      }

      else if (res.Success===true)
      {
        this.snack.open('Successful registration', 'OK', {
          horizontalPosition: 'center',
          verticalPosition: 'bottom',
          duration: 3000
          
          
        });
        this.router.navigateByUrl("AddUser")
      }
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
  
    })
  }

  back(){
    this.router.navigateByUrl("Login")
  }

}
