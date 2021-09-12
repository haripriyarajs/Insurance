import { Component, OnInit } from '@angular/core';
import { InsuranceDetailsService } from '../api/insurance-details.service';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-insurance-details',
  templateUrl: './insurance-details.component.html',
  styles: [
  ]
})


export class InsuranceDetailsComponent implements OnInit {

  constructor(private oService: InsuranceDetailsService) {  }
  nameControl: any;
  occupations: any = {};
  monthlyPremium: any;
  occupationRating: any;
  age: number = 0;
  sumInsured: number = 0;
  showClear: boolean = false;
  dateOfBirth: any;
  defaultOccupation : any; //created for clearing occupation
  ngOnInit(): void {
    this.oService.getOccupations().subscribe((result) => {
      console.log(result);
      this.occupations = result;
      console.log(this.occupations);
    })
  }
  occupationChange(value: any) {
    this.occupationRating = value;
    this.showClear = true;
  //  this.calculatePremium();
    console.warn(value);
  }

  nameChange(event: any){
    this.nameControl = event;
    this.showClear = true;
    console.warn(event.target.value);
  }
  selected = new FormControl('', [
    Validators.required
  ]);

  matcher = new MyErrorStateMatcher();

}
