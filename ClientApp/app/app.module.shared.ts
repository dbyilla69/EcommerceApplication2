import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '@angular/material';


import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { ProductViewComponent } from './components/product-view/product-view.component';
import { ProductFormComponent } from './components/product-form/product-form.component';
import { ProductDetailComponent } from './components/product-detail/product-detail.component';
import { CustomerViewComponent } from './components/customer-view/customer-view.component';
import { ShoppingCartViewComponent } from './components/shopping-cart-view/shopping-cart-view.component';

import { ProductService } from './services/product.service';
import { PictureService } from './services/picture.service';
import { ShoppingCartService } from './services/shopping-cart.service';





@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        ProductViewComponent,
        ProductFormComponent,
        ProductDetailComponent,
        CustomerViewComponent,
        ShoppingCartViewComponent

    ],
    imports: [
        CommonModule,
        HttpModule,
        MaterialModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'products/new', component: ProductFormComponent },
            { path: 'products/:id', component: ProductDetailComponent },
            { path: 'products', component: ProductViewComponent },
            { path: 'customers', component: CustomerViewComponent },
            { path: 'shoppings', component: ShoppingCartViewComponent },
            { path: 'home', component: HomeComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        ProductService,
        PictureService,
        ShoppingCartService
    ]
})
export class AppModuleShared {
}
