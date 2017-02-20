import { Injectable  } from '@angular/core';
import{Http,Response } from '@angular/http';
import { DataService } from './data.service';
import { Category } from '../domain/BlogDomain';
import { Observable } from 'rxjs/Observable';
 
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { Subscription } from 'rxjs/Subscription';
@Injectable()
export class CategoryService     {

    private _categoryAllAPI: string = 'api/category/all/';
    private _categoryAddAPI: string = 'api/category/';
    private _categoryRemoveAPI: string = 'api/category/remove/';
    private _categoryEditAPI: string = 'api/category/{id:number}/';

    category: Category[] = []; 
    catefory: Category;
    errorMessage: string;
    private sub: Subscription;
    constructor(public categoryService: DataService) {

       this.category = [];
    }
    



all() {
     this.categoryService.set(this._categoryAllAPI);
   return this.categoryService.getAll()
  }

 

 
addcategory(newcat: Category) {

    this.categoryService.set(this._categoryAddAPI);

    return this.categoryService.post(JSON.stringify(newcat)).map(response => <any>(<Response>response).json());
}


deleteCategory(id: number) {
    this.categoryService.set(this._categoryRemoveAPI);
    return this.categoryService.delete(id);

}

 

getProduct(id: number) {
    this.categoryService.get(id).subscribe(
        category => this.category = category,
        error => this.errorMessage = <any>error);
}


 



 

}  


 