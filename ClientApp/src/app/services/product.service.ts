import { Injectable } from '@angular/core';
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';

@Injectable()
export class ProductService {

  constructor(private http: Http) { }

  getProductsByCategoryId(categoryId) {
    return this.http.get('api/products/' + categoryId)
                    .map(res => res.json());
  }

  getProduct(id) {
    return this.http.get('api/product/' + id)
                    .map(res => res.json());
  }

  addProduct(product) {
    return this.http.post('api/addProduct/', product)
                    .map(res => res.json());
  }

  updateProduct(product) {
    return this.http.put('api/updateProduct/' + product.id, product)
                    .map(res => res.json());
  }

  deleteProdcut(id) {
    return this.http.delete('api/deleteProduct/' + id)
                    .map(res => res.json());
  }

}
