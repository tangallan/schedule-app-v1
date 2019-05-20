import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: 'customer',
        loadChildren: './modules/customer/customer.module#CustomerModule'
    },
    {
        path: 'vendor',
        loadChildren: './modules/vendor/vendor.module#VendorModule'
    },
    { path: '**', component: PageNotFoundComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}
