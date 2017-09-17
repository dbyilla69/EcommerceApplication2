import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { ProductService } from "../../services/product.service";
import { SaveProduct, Product } from "../../models/SaveProduct";
import { PictureService } from "../../services/picture.service";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.css']
})
export class ProductViewComponent implements OnInit {
  @ViewChild('fileInput')fileInput: ElementRef;
  pageTitle: string = 'Product List';
  products: any;
  productId: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService,
    private pictureService: PictureService) {

          route.params.subscribe(p => {
      this.productId = +p['id'];
      if (isNaN(this.productId) || this.productId <= 0) {
        router.navigate(['/products']);
        return;
      }
    });
    }

  ngOnInit() {
      this.productService.getAllProduct().subscribe(products => {
      this.products = products;
      });
  }
  uploadPicture(){
      var nativeElement: HTMLInputElement = this.fileInput.nativeElement;

      this.pictureService.upload(this.productId, nativeElement.files[0])
      .subscribe(x => console.log(x));
  }

}
