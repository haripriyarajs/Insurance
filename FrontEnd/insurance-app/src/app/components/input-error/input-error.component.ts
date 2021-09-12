import { Component } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-input-error',
  templateUrl: './input-error.component.html'
  
})

export class InputErrorComponent {
  nameFormControl = new FormControl('', [
    Validators.required,
  
  ]);

}
