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
var core_2 = require('@angular/core');
core_2.enableProdMode();
var category_ts_service_1 = require('../../core/services/category.ts.service');
var CategoryComponent = (function () {
    function CategoryComponent(categoryService) {
        this.categoryService = categoryService;
        this.pageTitle = 'Category Test';
        this.category = [];
        this.editId = 0;
    }
    CategoryComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.categoryService.all().subscribe(function (data) { return _this.category = (data); });
    };
    CategoryComponent.prototype.Addcat = function () {
        var _this = this;
        this.categoryService.addcategory(this.newcategory)
            .subscribe(function (status) {
            if (status) {
                _this.editId = 0;
            }
            else {
                _this.errorMessage = 'Unable to save category';
            }
        });
    };
    CategoryComponent = __decorate([
        core_1.Component({
            selector: 'category',
            templateUrl: './app/components/category/category.component.html'
        }), 
        __metadata('design:paramtypes', [category_ts_service_1.CategoryService])
    ], CategoryComponent);
    return CategoryComponent;
}());
exports.CategoryComponent = CategoryComponent;
//# sourceMappingURL=category.component.js.map