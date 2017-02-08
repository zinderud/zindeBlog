import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import 'rxjs/add/operator/map';
import { enableProdMode } from '@angular/core';
import { Observable } from 'rxjs/Observable';
enableProdMode();
import { CategoryService } from '../../core/services/category.ts.service';
import { Category } from '../../core/domain/BlogDomain';
@Component({
    selector: 'category',
    templateUrl: './app/components/category/category.component.html'

              

})
export class CategoryComponent implements OnInit
{
    pageTitle: string = 'Category Test';
                _category:Observable< Category>;
    constructor(public categoryService: CategoryService) {





       // var c = new Category();
       // c.Description = "ss";

       //this._category.push(c);
    }

 

     

    ngOnInit(): void {
         this._category = this.categoryService.all();
    }
}
