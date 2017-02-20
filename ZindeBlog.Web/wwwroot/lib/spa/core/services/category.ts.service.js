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
require("rxjs/add/operator/do");
require("rxjs/add/operator/catch");
require("rxjs/add/operator/map");
var CategoryService = (function () {
    function CategoryService(categoryService) {
        this.categoryService = categoryService;
        this._categoryAllAPI = 'api/category/all/';
        this._categoryAddAPI = 'api/category/';
        this._categoryRemoveAPI = 'api/category/remove/';
        this._categoryEditAPI = 'api/category/{id:number}/';
        this.category = [];
        this.category = [];
    }
    CategoryService.prototype.all = function () {
        this.categoryService.set(this._categoryAllAPI);
        return this.categoryService.getAll();
    };
    CategoryService.prototype.addcategory = function (newcat) {
        this.categoryService.set(this._categoryAddAPI);
        return this.categoryService.post(JSON.stringify(newcat)).map(function (response) { return response.json(); });
    };
    CategoryService.prototype.deleteCategory = function (id) {
        this.categoryService.set(this._categoryRemoveAPI);
        return this.categoryService.delete(id);
    };
    CategoryService.prototype.getProduct = function (id) {
        var _this = this;
        this.categoryService.get(id).subscribe(function (category) { return _this.category = category; }, function (error) { return _this.errorMessage = error; });
    };
    return CategoryService;
}());
CategoryService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [data_service_1.DataService])
], CategoryService);
exports.CategoryService = CategoryService;
