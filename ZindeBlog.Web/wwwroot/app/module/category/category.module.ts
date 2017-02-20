import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
 import { BrowserModule } from '@angular/platform-browser';
// Imports for loading & configuring the in-memory web api
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { ICategory } from './category';
import { CategoryService } from './category.ts.service';
import {CategoryListComponent} from './category.list.component';
 import {CategoryFilterPipe} from './category.filter.pipe';
 import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';



@NgModule({
    imports: [CommonModule,FormsModule,
        BrowserModule ,
        ReactiveFormsModule,
        RouterModule.forChild([

            {path:'categorylist',component:CategoryListComponent}
        ])
      
    ],
    declarations: [
        CategoryListComponent,CategoryFilterPipe
       
    ],
    providers: [
        CategoryService
    ]
})
export class CategoryModule { }
