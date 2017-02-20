import { Component, OnInit, Input } from '@angular/core';
import { ICategory } from './category';
import { enableProdMode } from '@angular/core';

enableProdMode();
import { CategoryService } from './category.ts.service';
import { CategoryFilterPipe } from './category.filter.pipe';

@Component({
    templateUrl: './app/module/category/category.list.component.html',


})


export class CategoryListComponent implements OnInit {
    pageTitle: string = 'category List';

    listFilter: string;
    errorMessage: string;
    @Input() category: ICategory[] = [];;
    constructor(public categoryService: CategoryService) {

    }


    ngOnInit(): void {
        this.categoryService.all().subscribe((data: ICategory[]) => this.category = (data))


    }
}