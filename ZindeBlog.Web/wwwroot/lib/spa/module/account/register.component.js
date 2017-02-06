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
var registration_1 = require("../../core/domain/registration");
var operationResult_1 = require("../../core/domain/operationResult");
var membership_service_1 = require("../../core/services/membership.service");
var notification_service_1 = require("../../core/services/notification.service");
var RegisterComponent = (function () {
    function RegisterComponent(membershipService, notificationService, router) {
        this.membershipService = membershipService;
        this.notificationService = notificationService;
        this.router = router;
    }
    RegisterComponent.prototype.ngOnInit = function () {
        this._newUser = new registration_1.Registration('', '', '');
    };
    RegisterComponent.prototype.register = function () {
        var _this = this;
        var _registrationResult = new operationResult_1.OperationResult(false, '');
        this.membershipService.register(this._newUser)
            .subscribe(function (res) {
            _registrationResult.Succeeded = res.ok;
            _registrationResult.Message = res.statusText;
        }, function (error) { return console.error('Error: ' + error); }, function () {
            if (_registrationResult.Succeeded) {
                _this.notificationService.printSuccessMessage('Dear ' + _this._newUser.Username + ', please login with your credentials');
                _this.router.navigate(['account/login']);
            }
            else {
                _this.notificationService.printErrorMessage(_registrationResult.Message);
            }
        });
    };
    ;
    return RegisterComponent;
}());
RegisterComponent = __decorate([
    core_1.Component({
        selector: 'register',
        providers: [membership_service_1.MembershipService, notification_service_1.NotificationService],
        templateUrl: './register.component.html'
    }),
    __metadata("design:paramtypes", [membership_service_1.MembershipService,
        notification_service_1.NotificationService,
        router_1.Router])
], RegisterComponent);
exports.RegisterComponent = RegisterComponent;
