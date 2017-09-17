import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../services/product.service";
import { Observable } from "rxjs/Observable";
import { Product } from "../../models/SaveProduct";
import { PictureService } from "../../services/picture.service";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: 'app-customer-view',
  templateUrl: './customer-view.component.html',
  styleUrls: ['./customer-view.component.css']
})
export class CustomerViewComponent implements OnInit {
  products: any;
  productId: number;
  pictures: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService,
    private pictureService: PictureService) {


  }

  ngOnInit() {
    this.productService.getAllProduct().subscribe(p => {
      this.products = p;
    });

    //  this.productService.getProduct(this.productId).subscribe(p => {
    //   this.products = p;
    //   console.log("CATEGORIES", this.products);
    // });


    this.pictureService.getAllPicture()
      .subscribe(p => this.pictures = p);
  }

}
