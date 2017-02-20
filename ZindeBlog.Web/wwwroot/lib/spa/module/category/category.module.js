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
var router_1 = require("@angular/router");
var forms_1 = require("@angular/forms");
var category_ts_service_1 = require("./category.ts.service");
var category_list_component_1 = require("./category-list.component");
var CategoryModule = (function () {
    function CategoryModule() {
    }
    return CategoryModule;
}());
CategoryModule = __decorate([
    core_1.NgModule({
        imports: [
            forms_1.ReactiveFormsModule,
            router_1.RouterModule.forChild([
                { path: 'categorylist', component: category_list_component_1.CategoryListComponent }
            ])
        ],
        declarations: [
            category_list_component_1.CategoryListComponent
        ],
        providers: [
            category_ts_service_1.CategoryService
        ]
    }),
    __metadata("design:paramtypes", [])
], CategoryModule);
exports.CategoryModule = CategoryModule;
