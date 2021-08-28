import { RawMaterial, Unit } from './../../../service/Interface/interfaces.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { ServicesService } from 'src/app/service/Services/services.service';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-add-raw-material',
  templateUrl: './add-raw-material.component.html',
  styleUrls: ['./add-raw-material.component.scss']
})
export class AddRawMaterialComponent implements OnInit {

  form: FormGroup = this.fb.group({
    RawMaterialName: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
    QuantityOnhand: ['', Validators.compose([Validators.required, Validators.maxLength(50), Validators.minLength(2)])],
    Rawmaterialdescription: ['', Validators.compose([Validators.required])],
    UnitID: ['', Validators.compose([Validators.required])],
  });

  observeData: Observable<Unit[]> = this.service.getUnit();
  UnitData!: Unit[];
  Unitparams: Unit=
  {
UnitID:0,
UnitMeasurement: "",

  }

  constructor(private service: ServicesService, private fb: FormBuilder,
    private snack: MatSnackBar, private dialogRef: MatDialogRef<AddRawMaterialComponent>,
    private router: Router) { }

  ngOnInit(): void {
    this.observeData.subscribe(res => {
      this.UnitData = res;
      console.log(res);
     
    })
  }

  CreateRawMaterial()
  {
  
    this.service.CreateRawMaterials(this.form.value).subscribe((res:any) => {
      
      if (res.Success===false)
      {
        this.snack.open('Raw Material not added.', 'OK', {
          verticalPosition: 'bottom',
          horizontalPosition: 'center',
          duration: 3000
        });
        this.form.reset();
        return;
      }

      else if (res.Success===true)
      {
        this.snack.open('Successful Added Raw Material ', 'OK', {
          horizontalPosition: 'center',
          verticalPosition: 'bottom',
          duration: 3000
        });
        this.router.navigateByUrl("RawMaterials")
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
    this.router.navigateByUrl("RawMaterials")
  }

}
