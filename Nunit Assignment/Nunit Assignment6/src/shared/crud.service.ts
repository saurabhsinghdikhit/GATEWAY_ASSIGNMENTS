import { Injectable } from '@angular/core';
import { Product } from 'src/models/product';

@Injectable({
  providedIn: 'root'
})
export class CRUDService {

  public products:Product[] = [
    {id: 1, productName: 'AC',category:'Electronics',price:13000},
    {id: 2, productName: 'TV',category:'Electronics',price:15000},
    {id: 3, productName: 'CPU',category:'Electronics',price:10000},
    {id: 4, productName: 'Monitor',category:'Electronics',price:9000},
  ];
  async getProducts():Promise<Product[]>{
    return this.products;
  }
  async getProduct(id:number){
    return this.products.find(x=>x.id==id);
  }
  async createProduct(model:Product){
    this.products.push(model);
    return this.products;
  }
  async updateProduct(model:Product){
    this.products.find(x=>x.id==model.id).id=model.id;
    this.products.find(x=>x.id==model.id).productName=model.productName;
    this.products.find(x=>x.id==model.id).category=model.category;
    this.products.find(x=>x.id==model.id).price=model.price;
    return this.products;
  }
  async deleteProduct(id:number){
    this.products.splice(id, 1);
    return this.products;
  }
  
}
