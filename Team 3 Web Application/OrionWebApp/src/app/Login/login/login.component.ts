import { RegisterComponent } from './../../Customer/RegisterCusomter/register/register.component';
import { ServicesService } from './../../service/Services/services.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginGroup: FormGroup = this.fb.group({
    UserName: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
    UserPassword: ['', Validators.compose([Validators.required, Validators.maxLength(12), Validators.minLength(8)])],
  });

  constructor(private fb: FormBuilder,
    private service: ServicesService, private snack: MatSnackBar,
    private router: Router, private dialog: MatDialog) { }

  ngOnInit(): void {
  }

  Login(): void {
    this.service.sendUserLogin(this.loginGroup.value).subscribe(res => {
      // route to home
      localStorage.setItem('user', JSON.stringify(res));
      this.router.navigateByUrl('Login');
    }, (error: HttpErrorResponse) => {

      if (error.status === 404) {
        this.snack.open('Invalid credentials.', 'OK', {
          verticalPosition: 'bottom',
          horizontalPosition: 'center',
          duration: 3000
        });
        this.loginGroup.reset();
        return;
      }
      this.snack.open('An error occured on our servers. Try again later.', 'OK', {
        verticalPosition: 'bottom',
        horizontalPosition: 'center',
        duration: 3000
      });
      this.loginGroup.reset();
    });
  }

  // OpenRegister() {
  //   this.router.navigateByUrl("Register")
  // }

OpenRegister() {
    const register = this.dialog.open(RegisterComponent, {
      disableClose: true
    });
  }

}
