import { ServicesService } from './../../service/Services/services.service';
import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Route, Router } from '@angular/router';
import { OpenDialogComponent } from 'src/app/Dialog/open-dialog/open-dialog.component';
import { Employee } from 'src/app/service/Interface/interfaces.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {

  observeEmployees: Observable<Employee[]> = this.service.getEmployee();
  EmployeeData!: Employee[];

  constructor(private router: Router,
    private service: ServicesService,
    private fb: FormBuilder,
    private snack: MatSnackBar,
    private dialogRef: MatDialog,) { }

  ngOnInit(): void {
    this.observeEmployees.subscribe(res => {
      this.EmployeeData = res;
    })
  }

  AddEmployee() {


    this.router.navigateByUrl("AddEmployee")
  }
  editEmployee() {
    this.router.navigateByUrl("EditEmployee")
  }
  deleteEmployee(EmployeeID: number) {
    this.service.deleteEmployee(EmployeeID).subscribe((res: any) => {
      console.log(res);
      if (res.Success === false) {
        this.snack.open('Employee not deleted.', 'OK', {
          verticalPosition: 'bottom',
          horizontalPosition: 'center',
          duration: 3000
        });

        return;
      }

      else if (res.Success === true) {
        this.snack.open('Successful Deleted Employee', 'OK', {
          horizontalPosition: 'center',
          verticalPosition: 'bottom',
          duration: 3000
        });
      }
      window.location.reload();
    });

  }
}

