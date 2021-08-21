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

  constructor(private router : Router, private service : ServicesService) { }

  ngOnInit(): void {
    this.observeEmployees.subscribe(res => {
      this.EmployeeData = res;
    })
  }

  AddEmployee()
  {

  
    this.router.navigateByUrl("AddEmployee")
  }
  editEmployee(){
    this.router.navigateByUrl("EditEmployee")
  }
  deleteEmployee(){
    this.router.navigateByUrl("AddEmployee")
  }

}
