import { ProductService } from './../services/product.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products: any = {};
  productss: Product[];

  constructor(private productService: ProductService,
              private route: ActivatedRoute,
              private router: Router) {
              
              route.params.subscribe(p => {
                  if(p['categoryId']) {
                    this.products.categoryId = +p['categoryId'];
                  }
              });
  }

  ngOnInit() {
    this.productService.getProductsByCategoryId(this.products.categoryId)
                       .subscribe(p => {
                         this.productss = p;
                      });
  }

}
