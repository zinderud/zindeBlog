import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CategoryComponent} from './components/category/category.component';

import { accountRoutes, accountRouting } from './module/account/routes';
 

const appRoutes: Routes = [
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'category',
        component:CategoryComponent
    }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
