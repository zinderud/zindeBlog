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
var core_1 = require('@angular/core');
//import {ICategory} from './category';
var core_2 = require('@angular/core');
core_2.enableProdMode();
//import {CategoryService } from './category.ts.service';
var category_ts_service_1 = require('../../core/services/category.ts.service');
var CategoryListComponent = (function () {
    function CategoryListComponent(categoryService) {
        this.categoryService = categoryService;
        this.pageTitle = 'category List';
        this.category = [];
    }
    CategoryListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.categoryService.all().subscribe(function (data) { return _this.category = (data); });
    };
    CategoryListComponent = __decorate([
        core_1.Component({
            templateUrl: './app/module/category/category-list.component.html'
        }), 
        __metadata('design:paramtypes', [category_ts_service_1.CategoryService])
    ], CategoryListComponent);
    return CategoryListComponent;
}());
exports.CategoryListComponent = CategoryListComponent;
//# sourceMappingURL=category-list.component.js.map