import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ServicesService } from 'src/app/service/Services/services.service';
import { OpenDialogComponent } from 'src/app/Dialog/open-dialog/open-dialog.component';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss']
})
export class AddUserComponent implements OnInit {

  form: FormGroup = this.fb.group({
    UserName: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
    UserPassword: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
  });

  constructor(private service: ServicesService, private fb: FormBuilder, 
    private snack: MatSnackBar, private dialogRef: MatDialogRef<AddUserComponent>,
    private router: Router) { }

  ngOnInit(): void {
  }


  RegisterUser() {
    this.service.AddUser(this.form.value).subscribe((res:any) => {
     // this.dialogRef.close();
     console.log(res);
      this.snack.open('Successful registration', 'OK', {
        horizontalPosition: 'center',
        verticalPosition: 'bottom',
        duration: 3000
      });
 
      if (res.Success===false)
      {
        this.snack.open('Enter valid details.', 'OK', {
          verticalPosition: 'bottom',
          horizontalPosition: 'center',
          duration: 3000
        });
        this.form.reset();
        return;
      }

      else if (res.Success===true)
      {
        this.snack.open('This user has already been registered.', 'OK', {
          horizontalPosition: 'center',
          verticalPosition: 'bottom',
          duration: 3000
      
        });
        this.router.navigateByUrl("Login")
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
     // this.dialogRef.close();
    })
  }

  back(){
    this.router.navigateByUrl("Login")
  }

  backLogin(){
    this.router.navigateByUrl("Login")
  }
}
