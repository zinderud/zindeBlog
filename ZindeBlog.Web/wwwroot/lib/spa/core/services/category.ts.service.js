"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var data_service_1 = require("./data.service");
var notification_service_1 = require("../../core/services/notification.service");
require("rxjs/add/operator/do");
require("rxjs/add/operator/catch");
require("rxjs/add/operator/map");
var CategoryService = (function () {
    function CategoryService(categoryService, notificationService) {
        this.categoryService = categoryService;
        this.notificationService = notificationService;
        this._categoryAllAPI = 'api/category/all/';
        this._categoryAddAPI = 'api/category/';
        this._categoryRemoveAPI = 'api/category/remove/';
        this._categoryEditAPI = 'api/category/{id:number}/';
    }
    //all():Observable<Category[]>{
    // return this._http.get(this._categoryAllAPI)
    //             .map((response: Response) => <Category[]> response.json())
    //            .do(data => console.log('All: ' +  JSON.stringify(data)))
    //            .catch(this.handleError); 
    //}
    //addCotegory(cat: Category): Observable<Category> {
    //    let catString = JSON.stringify(cat); // Stringify payload
    //    return this._http.post(this._categoryAddAPI, catString) // ...using post request
    //        .map((res: Response) => res.json()) // ...and calling .json() on the response to return data
    //        .catch((error: any) => Observable.throw(error.json().error || 'Server error')); //...errors if any
    //} 
    CategoryService.prototype.all = function () {
        this.categoryService.set(this._categoryAllAPI);
        return this.categoryService.getAll();
    };
    CategoryService.prototype.addcategory = function (newcat) {
        this.categoryService.set(this._categoryAddAPI);
        return this.categoryService.post(JSON.stringify(newcat));
    };
    CategoryService.prototype.deleteCategory = function (id) {
        this.categoryService.set(this._categoryRemoveAPI);
        return this.categoryService.delete(id);
    };
    CategoryService.prototype.getCategory = function (id) {
        //this.categoryService.set(this._categoryEditAPI);
        return this.all()
            .map(function (cat) { return cat.find(function (p) { return p.ID === id; }); });
    };
    return CategoryService;
}());
CategoryService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [data_service_1.DataService, notification_service_1.NotificationService])
], CategoryService);
exports.CategoryService = CategoryService;
