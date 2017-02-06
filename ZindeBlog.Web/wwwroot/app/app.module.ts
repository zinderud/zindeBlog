
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { Location, LocationStrategy, HashLocationStrategy } from '@angular/common';
import { Headers, RequestOptions, BaseRequestOptions } from '@angular/http';

import { AccountModule } from '../app/module/account/account.module';
import { AppComponent } from './app.component';
 
import { HomeComponent } from '../app/components/home/home.component';
 
import { routing } from '../app/routes';


import { DataService } from '../app/core/services/data.service';
import { MembershipService } from '../app/core/services/membership.service';
import { UtilityService } from '../app/core/services/utility.service';
import { NotificationService } from '../app/core/services/notification.service';
//import{CategoryService} from '../../core/services/category.ts.service'
class AppBaseRequestOptions extends BaseRequestOptions {
    headers: Headers = new Headers();

    constructor() {
        super();
        this.headers.append('Content-Type', 'application/json');
        this.body = '';
    }
}

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        routing,
        AccountModule
    ],
    declarations: [AppComponent, HomeComponent],
    providers: [DataService, MembershipService, UtilityService, NotificationService,
    //CategoryService,
        { provide: LocationStrategy, useClass: HashLocationStrategy },
        { provide: RequestOptions, useClass: AppBaseRequestOptions }],
    bootstrap: [AppComponent]
})
export class AppModule { }

