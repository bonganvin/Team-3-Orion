import { AddBranchComponent } from './AddBranch/add-branch/add-branch.component';
import { Branches } from './../../../service/Interface/interfaces.service';
import { Component, OnInit } from '@angular/core';
import { ServicesService } from 'src/app/service/Services/services.service';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-branches',
  templateUrl: './branches.component.html',
  styleUrls: ['./branches.component.scss']
})
export class BranchesComponent implements OnInit {

  observeData: Observable<Branches[]> = this.service.getBranch();
  BranchData!: Branches[];

  constructor(private service: ServicesService, private fb: FormBuilder, 
    private snack: MatSnackBar, private dialogRef: MatDialog,
    private router: Router) { }

  ngOnInit(): void {
    this.observeData.subscribe(res => {
      this.BranchData = res;
    })
  }

  AddBranch(){
    this.router.navigateByUrl("AddBranch")
  }

  editBranch(){
    this.router.navigateByUrl("editBranch")
  }

  deleteBranch(){
    this.router.navigateByUrl("deleteBranch")
  }

}
