import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../services/product.service";
import { SaveProduct } from "../../models/SaveProduct";
import { ActivatedRoute, Router } from "@angular/router";


@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {
  categories: any[];
  subCategories: any[];
  product: SaveProduct = {
    id: 0,
    productName: '',
    details: '',
    unitPrice: 0,
    unitsInStock: 0,
    categoryId: 0,
    subCategoryId: 0,

  };
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService) { 
      route.params.subscribe(p => {
        this.product.id = +p['id'] || 0;
      });
    }

  ngOnInit() {
    this.productService.getCategories().subscribe(categories => {
      this.categories = categories;
    });

    this.productService.getProduct(this.product.id).subscribe(p => {
      this.product = p;
    });
  }

  onCategoryChange() {
    console.log("PRODUCT", this.product)
    var selectedCategory = this.categories.find(c => c.id == this.product.categoryId);
    this.subCategories = selectedCategory ? selectedCategory.subCategories : [];
  }

  submit() {
    this.productService.create(this.product).subscribe(x => console.log(x));
  }
}
