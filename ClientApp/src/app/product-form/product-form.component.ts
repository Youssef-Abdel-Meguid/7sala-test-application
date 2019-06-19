import { ProductService } from './../services/product.service';
import { CategoryService } from './../services/category.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {

  categories;
  product: any = {};

  constructor(private categoryService: CategoryService,
              private route: ActivatedRoute,
              private router: Router,
              private productService: ProductService) { 

              route.params.subscribe(p => {
                  if(p['id']) {
                    this.product.id = +p['id'];
                  }
              });
  }

  ngOnInit() {

    this.productService.getProduct(this.product.id)
                       .subscribe(p => {this.product = p});

    this.categoryService.getCategories()
                        .subscribe(categories => {this.categories = categories});
  }

  submit() {

      if(this.product.id) {
          this.productService.updateProduct(this.product)
                             .subscribe(x => console.log(x));
      }
      else {
        this.productService.addProduct(this.product)
                           .subscribe(x => console.log(x));
      }
  }

  delete() {
    this.productService.deleteProdcut(this.product.id)
                       .subscribe(x => {
                         this.router.navigate(['/home']);
                         console.log(x);
                       });
  }

}
