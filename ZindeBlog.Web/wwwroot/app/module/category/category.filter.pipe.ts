import { PipeTransform, Pipe } from '@angular/core';
import { ICategory } from './category';

@Pipe({
    name: 'categoryFilter',
    pure: false
})
export class CategoryFilterPipe implements PipeTransform {

    transform(value: ICategory[], filterBy: string): ICategory[] {
         filterBy = filterBy ? filterBy.toLocaleLowerCase() : null;

        return filterBy ? value.filter((category: ICategory) =>
            category.Description.toLocaleLowerCase().indexOf(filterBy) !== -1) : value;

    }
}