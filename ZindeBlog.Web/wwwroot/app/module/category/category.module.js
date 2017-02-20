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
var router_1 = require('@angular/router');
var forms_1 = require('@angular/forms');
var platform_browser_1 = require('@angular/platform-browser');
var category_ts_service_1 = require('./category.ts.service');
var category_list_component_1 = require('./category.list.component');
var category_filter_pipe_1 = require('./category.filter.pipe');
var common_1 = require('@angular/common');
var forms_2 = require('@angular/forms');
var CategoryModule = (function () {
    function CategoryModule() {
    }
    CategoryModule = __decorate([
        core_1.NgModule({
            imports: [common_1.CommonModule, forms_2.FormsModule,
                platform_browser_1.BrowserModule,
                forms_1.ReactiveFormsModule,
                router_1.RouterModule.forChild([
                    { path: 'categorylist', component: category_list_component_1.CategoryListComponent }
                ])
            ],
            declarations: [
                category_list_component_1.CategoryListComponent, category_filter_pipe_1.CategoryFilterPipe
            ],
            providers: [
                category_ts_service_1.CategoryService
            ]
        }), 
        __metadata('design:paramtypes', [])
    ], CategoryModule);
    return CategoryModule;
}());
exports.CategoryModule = CategoryModule;
//# sourceMappingURL=category.module.js.map