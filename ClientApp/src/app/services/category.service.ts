import { Injectable } from '@angular/core';
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';

@Injectable()
export class CategoryService {

  constructor(private http: Http) { }

  getCategories() {
    return this.http.get('api/categories')
                    .map(res => res.json());
  }

  addCategory(category) {
    return this.http.post('api/addCategory', category)
                    .map(res => res.json());
  }

  updateCategory(category) {
    return this.http.put('api/updateCategory/' + category.id, category)
                    .map(res => res.json());
  }

  deleteCategory(id) {
    return this.http.delete('api/deleteCategory/' + id)
                    .map(res => res.json());
  }

  getCategory(id) {
    return this.http.get('api/category/' + id)
                    .map(res => res.json());
  }

}
