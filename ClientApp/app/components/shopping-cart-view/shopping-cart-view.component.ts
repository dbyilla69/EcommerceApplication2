import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PictureService } from '../../services/picture.service';

@Component({
  selector: 'app-shopping-cart-view',
  templateUrl: './shopping-cart-view.component.html',
  styleUrls: ['./shopping-cart-view.component.css']
})
export class ShoppingCartViewComponent implements OnInit {
  pictures: any;
  product:any;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private pictureService:PictureService,
    //private cartService: ShoppingCartService;
    ) {

    //add api here to get product with id
  }

  ngOnInit() {
    this.pictureService.getAllPicture().subscribe(p => {
      this.pictures = p;
      });
  }

  addToCart(){
    //this.cartservice.addToCart(this.product);
  }

}
