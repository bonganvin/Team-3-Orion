import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ServicesService } from 'src/app/service/Services/services.service';

@Component({
  selector: 'app-add-recipe',
  templateUrl: './add-recipe.component.html',
  styleUrls: ['./add-recipe.component.scss']
})
export class AddRecipeComponent implements OnInit {

  form: FormGroup = this.fb.group({
    RecipeName: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
    RecipeDescription: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
    QuantityProduced: ['', Validators.compose([Validators.required, Validators.maxLength(20), Validators.minLength(2)])],
  });

  constructor(private service: ServicesService, private fb: FormBuilder, 
    private snack: MatSnackBar, private dialogRef: MatDialogRef<AddRecipeComponent>,
    private router: Router) { }

  ngOnInit(): void {
  }
  CreateRecipe(){
    this.service.CreateRecipe(this.form.value).subscribe((res:any) => {
      if (res.Success===false)
      {
        this.snack.open('Recipe not added.', 'OK', {
          verticalPosition: 'bottom',
          horizontalPosition: 'center',
          duration: 3000
        });
        console.log(res);
        this.form.reset();
        return;
      }

      else if (res.Success===true)
      {
        this.snack.open('Successful Added Recipe', 'OK', {
          horizontalPosition: 'center',
          verticalPosition: 'bottom',
          duration: 3000
        });
        this.router.navigateByUrl("Recipe")
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
    })

    
  }

  back(){
    this.router.navigateByUrl("Recipe")
  }

}
