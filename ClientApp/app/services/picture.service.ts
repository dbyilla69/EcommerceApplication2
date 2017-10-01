import { Injectable } from '@angular/core';
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';

@Injectable()
export class PictureService {

    constructor(private http: Http) { }

    upload(productId:any, picture:any) {
        var formData = new FormData();
        formData.append('file', picture)
        return this.http.post(`/api/pictures/products/${productId}`, formData)
            .map(res => res.json());
    }

    getPictures(productId:any) {
        return this.http.get(`/api/pictures/products/${productId}`)
            .map(res => res.json());
    }

    getAllPicture() {
    return this.http.get('/api/pictures/products' )
      .map(res => res.json());
  }
}