import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { EventsComponent } from './events/event.component';
import { EventDetailComponent } from './events/event-detail/event-detail.component';

import { TablesComponent } from './tables/table.component';
import { TableDetailComponent } from './tables/table-detail/table-detail.component';

import { MenusComponent } from './menus/menus.component';

import { OrdersComponent } from './orders/orders.component';

import { PaymentsComponent } from './payments/payments.component';


@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },

                    { path: 'events', component: EventsComponent, data: { permission: 'Pages.Events' }, canActivate: [AppRouteGuard] },
                    { path: 'events/:eventId', component: EventDetailComponent },
                    
                    { path: 'tables', component: TablesComponent, data: { permission: 'Pages.Tables' }, canActivate: [AppRouteGuard] },
                    { path: 'tables/:tableId', component: TableDetailComponent },

                    { path: 'menus', component: MenusComponent, data: { permission: 'Pages.Menus' }, canActivate: [AppRouteGuard] },

                    { path: 'orders', component: OrdersComponent, data: { permission: 'Pages.Orders' }, canActivate: [AppRouteGuard] },

                    { path: 'payments', component: PaymentsComponent, data: { permission: 'Pages.Payments' }, canActivate: [AppRouteGuard] },
                    
                    { path: 'about', component: AboutComponent, canActivate: [AppRouteGuard] },
                    { path: 'update-password', component: ChangePasswordComponent, canActivate: [AppRouteGuard] }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
