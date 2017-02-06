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
var user_1 = require("../../core/domain/user");
var operationResult_1 = require("../../core/domain/operationResult");
var membership_service_1 = require("../../core/services/membership.service");
var notification_service_1 = require("../../core/services/notification.service");
var LoginComponent = (function () {
    function LoginComponent(membershipService, notificationService, router) {
        this.membershipService = membershipService;
        this.notificationService = notificationService;
        this.router = router;
    }
    LoginComponent.prototype.ngOnInit = function () {
        this._user = new user_1.User('', '');
    };
    LoginComponent.prototype.login = function () {
        var _this = this;
        var _authenticationResult = new operationResult_1.OperationResult(false, '');
        this.membershipService.login(this._user)
            .subscribe(function (res) {
            _authenticationResult.Succeeded = res.ok;
            _authenticationResult.Message = res.statusText;
        }, function (error) { return console.error('Error: ' + error); }, function () {
            if (_authenticationResult.Succeeded) {
                _this.notificationService.printSuccessMessage('Welcome back ' + _this._user.Username + '!');
                localStorage.setItem('user', JSON.stringify(_this._user));
                _this.router.navigate(['home']);
            }
            else {
                _this.notificationService.printErrorMessage(_authenticationResult.Message);
            }
        });
    };
    ;
    return LoginComponent;
}());
LoginComponent = __decorate([
    core_1.Component({
        selector: 'albums',
        templateUrl: './login.component.html'
    }),
    __metadata("design:paramtypes", [membership_service_1.MembershipService,
        notification_service_1.NotificationService,
        router_1.Router])
], LoginComponent);
exports.LoginComponent = LoginComponent;
