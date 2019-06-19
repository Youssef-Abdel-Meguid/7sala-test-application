import { CategoryService } from './../services/category.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.css']
})
export class CategoryFormComponent implements OnInit {


  category: any = {};
  
  constructor(private categoryService: CategoryService,
              private route: ActivatedRoute,
              private router: Router) {

                  route.params.subscribe(p => {
                  if(p['id']) {
                    this.category.id = +p['id'];
                  }
                });
                
              }

  ngOnInit() {
    this.categoryService.getCategory(this.category.id)
                        .subscribe(c => {
                          this.category = c;
                        });
  }

  submit() {

    if(this.category.id) {
      this.categoryService.updateCategory(this.category)
                          .subscribe(x => {
                            this.router.navigate(['/home']);
                            console.log(x);
                          });
    }
    else {
      this.categoryService.addCategory(this.category)
                          .subscribe(x => {
                            this.router.navigate(['/home']);
                            console.log(x);
                          });
    }
  }

  delete() {
    this.categoryService.deleteCategory(this.category.id)
                        .subscribe(x => {
                          this.router.navigate(['/home']);
                          console.log(x);
                        });
  }

}
