
/// <reference path="../../typings/globals/es6-shim/index.d.ts" />
import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import 'rxjs/add/operator/map';
import { enableProdMode } from '@angular/core';
//import { Observable } from 'rxjs/Observable';
enableProdMode();
import { MembershipService } from "../app/core/services/membership.service";
//import {CategoryService } from '../../core/services/category.ts.service'
//import { Category} from    '../../core/domain/BlogDomain'
import { User } from '../app/core/domain/user';

@Component({
    selector: 'zindeblog-app',
    templateUrl: 'app/app.component.html'
})
export class AppComponent implements OnInit {

    constructor(public membershipService: MembershipService,
        public location: Location
     //   ,public categoryService:CategoryService
        ) { }
   // public _category: Observable<Category>;
    ngOnInit() {


        //this._category = this.categoryService.all();
    }
 

    isUserLoggedIn(): boolean {
        return this.membershipService.isUserAuthenticated();
    }

    getUserName(): string {
        if (this.isUserLoggedIn()) {
            var _user = this.membershipService.getLoggedInUser();
            return _user.Username;
        }
        else
            return 'Account';
    }

    logout(): void {
        this.membershipService.logout()
            .subscribe(res => {
                localStorage.removeItem('user');
            },
            error => console.error('Error: ' + error),
            () => { });
    }

   
 //   getCategoryAll() {
   //    this._category = this.categoryService.all();
         
    //}
     
}
