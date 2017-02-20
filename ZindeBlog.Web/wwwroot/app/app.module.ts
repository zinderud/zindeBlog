
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { Location, LocationStrategy, HashLocationStrategy } from '@angular/common';
import { Headers, RequestOptions, BaseRequestOptions } from '@angular/http';
import { AppComponent } from './app.component';
import { routing } from './routes';
import { HomeComponent } from './components/home/home.component';
import { CategoryComponent } from './components/category/category.component';


import { DataService } from './core/services/data.service';
import { MembershipService } from './core/services/membership.service';
import { UtilityService } from './core/services/utility.service';
import { NotificationService } from './core/services/notification.service';
import{CategoryService} from './core/services/category.ts.service'
import { AccountModule } from './module/account/account.module';
import {CategoryModule} from './module/category/category.module'
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
        routing, AccountModule,
        CategoryModule
    
    ],
    declarations: [AppComponent,HomeComponent,CategoryComponent],
    providers: [DataService, MembershipService, UtilityService, NotificationService,
    CategoryService,
   
        { provide: LocationStrategy, useClass: HashLocationStrategy },
        { provide: RequestOptions, useClass: AppBaseRequestOptions }],
    bootstrap: [AppComponent]
})
export class AppModule { }

