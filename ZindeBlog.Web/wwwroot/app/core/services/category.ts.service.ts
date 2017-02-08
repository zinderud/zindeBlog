import { Injectable } from '@angular/core';
import{Http,Response,Request } from '@angular/http';
import { DataService } from './data.service';
import { Category } from '../domain/BlogDomain';
import { Observable } from 'rxjs/Observable';
import { NotificationService } from '../../core/services/notification.service';
 
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
@Injectable()
export class CategoryService {

    private _categoryAllAPI: string = 'api/category/all/';
    private _categoryAddAPI: string = 'api/category/';
    private _categoryRemoveAPI: string = 'api/category/remove/';
    private _categoryEditAPI: string = 'api/category/{id:number}/';

    constructor(public categoryService: DataService, public notificationService: NotificationService ) { }

//all():Observable<Category>{
// return this._http.get(this._categoryAllAPI)
//             .map((response: Response) => <Category> response.json())
//            .do(data => console.log('All: ' +  JSON.stringify(data)))
//             ; 
//}
 
all() {
    this.categoryService.set(this._categoryAllAPI);
    return this.categoryService.getAll().map((response: Response) => <Category>response.json()).do(data => console.log('All: ' + JSON.stringify(data)));
    }

addcategory(newcat: Category) {

    this.categoryService.set(this._categoryAddAPI);

    return this.categoryService.post(JSON.stringify(newcat));
}


deleteCategory(id: number) {
    this.categoryService.set(this._categoryRemoveAPI);
    return this.categoryService.delete(id);

}






 

}  


 