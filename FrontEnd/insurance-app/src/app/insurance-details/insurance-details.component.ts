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
   this.calculatePremium();
    console.warn(value);
  }

  sumInsuredChange(value: any) {
    console.log(value.value);
    this.sumInsured = value.value;
    this.showClear = true;
    this.calculatePremium();
  }

  calculatePremium() {
    if (this.occupationRating != undefined && this.age > 0 && this.sumInsured > 0) {
      this.oService.calculatePremium(this.age,this.occupationRating,this.sumInsured).subscribe((result) => {
        console.log(result);
        this.monthlyPremium =Number(result).toPrecision(4).toString() +" AUD";
        console.log(this.occupations);
      })
      
    }
  }

  clearButton(){
    this.showClear = false;
    this.dateOfBirth = ' ';
    this.age =0;
    this.sumInsured = 0;
    this.defaultOccupation = '';
    if(this.nameChange != undefined){
      this.nameControl.target.value = ''
     }
  }

  nameChange(event: any){
    this.nameControl = event;
    this.showClear = true;
    console.warn(event.target.value);
  }

  calculateAge(event : any){
    const convertAge = new Date(this.dateOfBirth);
    const timeDiff = Math.abs(Date.now() - convertAge.getTime());
    this.age = Math.floor((timeDiff / (1000 * 3600 * 24))/365);
    this.calculatePremium();
  }

  selected = new FormControl('', [
    Validators.required
  ]);

  matcher = new MyErrorStateMatcher();

  formatSumInsuredSliderLabel(value: number) {
    return value + "k";
  }

  formatAgeSliderLabel(value: number) {
    return value + " Y";
  }


}
