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
/// <reference path="../../typings/globals/es6-shim/index.d.ts" />
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
require("rxjs/add/operator/map");
var core_2 = require("@angular/core");
//import { Observable } from 'rxjs/Observable';
core_2.enableProdMode();
var membership_service_1 = require("../app/core/services/membership.service");
var AppComponent = (function () {
    function AppComponent(membershipService, location) {
        this.membershipService = membershipService;
        this.location = location;
    }
    // public _category: Observable<Category>;
    AppComponent.prototype.ngOnInit = function () {
        //this._category = this.categoryService.all();
    };
    AppComponent.prototype.isUserLoggedIn = function () {
        return this.membershipService.isUserAuthenticated();
    };
    AppComponent.prototype.getUserName = function () {
        if (this.isUserLoggedIn()) {
            var _user = this.membershipService.getLoggedInUser();
            return _user.Username;
        }
        else
            return 'Account';
    };
    AppComponent.prototype.logout = function () {
        this.membershipService.logout()
            .subscribe(function (res) {
            localStorage.removeItem('user');
        }, function (error) { return console.error('Error: ' + error); }, function () { });
    };
    return AppComponent;
}());
AppComponent = __decorate([
    core_1.Component({
        selector: 'zindeblog-app',
        templateUrl: 'app/app.component.html'
    }),
    __metadata("design:paramtypes", [membership_service_1.MembershipService,
        common_1.Location])
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map