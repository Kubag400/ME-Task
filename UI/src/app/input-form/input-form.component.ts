import { Component, EventEmitter, Output } from '@angular/core';
import { Product, ProductRequest } from '../Interfaces/Product';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-input-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './input-form.component.html',
  styleUrl: './input-form.component.css'
})
export class InputFormComponent {
  @Output() onCreateProduct = new EventEmitter<ProductRequest>();
  name:string = "";
  code:string = "";
  price:number = 1;
  errorState:boolean = false;
  errorMessage:string = ''
  onCreate(){

    if(!this.checkFields())
    {
      let item:ProductRequest = {
        Name: this.name,
        Code: this.code,
        Price: this.price
      };
      this.onCreateProduct.emit(item)
  
      this.name ='';
      this.code = '';
      this.price = 0;
      
    }
  }

  checkFields():boolean{
    if(this.code === '' || this.code.length < 2)
    {
        this.errorMessage = "Code field cannot be empty and requires at least 2 characters";
        this.errorState = true;
        return true;
    }
    if(this.name === '' || this.name.length < 3) 
      {
        this.errorMessage = "Name field cannot be empty and requires at lest 3 characters";
        this.errorState = true;
        return true;
      }
    if(this.price <= 0 )
    {
      this.errorMessage = "Price field has to be greater than 0";
      this.errorState = true;
      return true;
    }
    this.errorState = false;
    return false
  }
}
