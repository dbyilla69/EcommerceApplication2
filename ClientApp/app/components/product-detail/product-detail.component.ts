import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ProductService } from "../../services/product.service";
import { ActivatedRoute, Router } from "@angular/router";
import { SaveProduct } from "../../models/SaveProduct";
import { PictureService } from "../../services/picture.service";

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  @ViewChild('fileInput') fileInput: ElementRef;
  product: any;
  productId: number;
  pictures: any;


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
    this.pictureService.getPictures(this.productId)
      .subscribe(pictures => this.pictures = pictures);

    this.productService.getProduct(this.productId).subscribe(p => {
      this.product = p;
      //console.log("CATEGORIES", this.categories);
    });
  }

  uploadPicture() {
    var nativeElement: HTMLInputElement = this.fileInput.nativeElement;

    this.pictureService.upload(this.productId, this.fileInput.nativeElement.files[0])
      .subscribe(picture => {
        this.pictures.push(picture);
      });
  }

}
