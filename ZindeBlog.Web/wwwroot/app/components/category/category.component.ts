import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
 
 
import { enableProdMode } from '@angular/core';
 
enableProdMode();
import { CategoryService } from '../../core/services/category.ts.service';
import { Category } from '../../core/domain/BlogDomain';
@Component({
    selector: 'category',
    templateUrl: './app/components/category/category.component.html'



})
export class CategoryComponent implements OnInit {
    pageTitle: string = 'Category Test';

    

    category: Category[] = []; 
    newcategory: Category;
    editId: number = 0;
    errorMessage: string;

    constructor(public categoryService: CategoryService) {
  
    }
 
    ngOnInit(): void {
    
       this.categoryService.all().subscribe((data: Category[]) => this.category = (data))
    
    }

    Addcat()
    {
        this.categoryService.addcategory(this.newcategory)
         .subscribe((status: boolean) => {
                if (status) {
                    this.editId = 0;
                } else {
                    this.errorMessage = 'Unable to save category';
                }
            })
    }
}
