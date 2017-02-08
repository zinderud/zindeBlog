"use strict";
var router_1 = require("@angular/router");
var home_component_1 = require("./components/home/home.component");
var category_component_1 = require("./components/category/category.component");
var appRoutes = [
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: home_component_1.HomeComponent
    },
    {
        path: 'category',
        component: category_component_1.CategoryComponent
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
