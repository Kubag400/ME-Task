import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ItemsListComponent } from "./items-list/items-list.component";
import { InputFormComponent } from "./input-form/input-form.component";
import { Product, ProductRequest } from './Interfaces/Product';
import { ProductService } from './Services/product.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ItemsListComponent, InputFormComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  ngOnInit(): void {
    this.loadData();
  }

 constructor(private productService:ProductService) {}

  title = 'Jakub Gaweda ME-Task';
  products:Product[] = []

  createProduct(request:ProductRequest){
    this.productService.createProduct(request).subscribe(() => {
      this.loadData()
    });
  }

  loadData(option:number = 0){
    console.log(option)
    this.productService.getProducts(option).subscribe(result => {
      this.products = result;
    });
  }

  onRefresh(option:number){
    console.log(option)
    this.loadData(option);
  }
}
