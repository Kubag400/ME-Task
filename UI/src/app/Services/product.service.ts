import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Product, ProductRequest } from "../Interfaces/Product";

@Injectable({
  providedIn:'root'
})
export class ProductService{
  private baseUrl = "http://localhost:5115"
  private controller = "/Product"

  constructor(private httpClient: HttpClient){}

  getProducts(sort:number = 0){
    return this.httpClient.get<Product[]>(this.baseUrl + this.controller + '?options=' + sort)
  }

  createProduct(request: ProductRequest){
      return this.httpClient.post<Product[]>(this.baseUrl + this.controller, request);
  }
}