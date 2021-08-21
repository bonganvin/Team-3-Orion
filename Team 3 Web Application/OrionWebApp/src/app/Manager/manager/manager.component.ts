import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.scss']
})
export class ManagerComponent implements OnInit {

  constructor(private router: Router) {}

  ngOnInit(): void {
  }

  employee()
  {
    this.router.navigateByUrl("Employee")
  }
  branch()
  {
    this.router.navigateByUrl("Branch")
  }
  CashRegister()
  {
    this.router.navigateByUrl("CashRegster")
  }
  jobs()
  {
    this.router.navigateByUrl("Jobs")
  }
  reports()
  {
    this.router.navigateByUrl("Reports")
  }
  shift()
  {
    this.router.navigateByUrl("Shift")
  }
  VAT()
  {
    this.router.navigateByUrl("VAT")
  }

}
