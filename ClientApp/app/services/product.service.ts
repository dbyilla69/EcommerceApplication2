import { Injectable } from '@angular/core';
import { Http } from "@angular/http";
import { SaveProduct } from "../models/SaveProduct";
import 'rxjs/add/operator/map';
//import { Observable } from "rxjs/Observable";

@Injectable()
export class ProductService {

  constructor(private http: Http) { }

  create(product) {
    return this.http.post('/api/products', product)
      .map(res => res.json());
  }

 getProduct(id) {
    return this.http.get('/api/products/' + id)
      .map(res => res.json());
  }

    getAllProduct() {
    return this.http.get('/api/products/' )
      .map(res => res.json());
  }

  update(product: SaveProduct) {
    return this.http.put('/api/products/' + product.id, product)
      .map(res => res.json());
  }

  delete(id) {
    return this.http.delete('/api/products/' + id)
      .map(res => res.json());
  }

    getCategories() {
    return this.http.get('/api/categories')
      .map(res => res.json());
  }

    //   getProduct(id: number): Observable<SaveProduct> {
    //     return this.getAllProduct()
    //         .map((products: SaveProduct[]) => products.find(p => p.productId === id));
    // }

}
