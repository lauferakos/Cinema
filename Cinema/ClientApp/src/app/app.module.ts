import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';


import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatCardModule } from '@angular/material/card';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FilmListComponent } from './film-list/film-list.component';
import { FilmService } from './services/film.service';
import { ProjectionListComponent } from './projection-list/projection-list.component';
import { ProjectionService } from './services/projection.service';
import { OrderListComponent } from './order-list/order-list.component';
import { OrderService } from './services/order.service';
import { AdministrationComponent } from './administration/administration.component';
import { AdditemComponent } from './additem/additem.component';
import { RoomService } from './services/room.service';
import { ViewerService } from './services/viewer.service';
import { ModifyitemComponent } from './modifyitem/modifyitem.component';
import { BasketComponent } from './basket/basket.component';
import { BasketListComponent } from './basket-list/basket-list.component';
import { DetailsComponent } from './details/details.component';
import { TicketComponent } from './ticket/ticket.component';
import { ReservationService } from './services/reservation.service';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthService } from './services/auth.service';
import { AuthGuardService as AuthGuard } from './services/auth-guard.service';
import { LogoutComponent } from './logout/logout.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    FilmListComponent,
    ProjectionListComponent,
    OrderListComponent,
    AdministrationComponent,
    AdditemComponent,
    ModifyitemComponent,
    BasketComponent,
    BasketListComponent,
    DetailsComponent,
    TicketComponent,
    LoginComponent,
    RegisterComponent,
    LogoutComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatSelectModule,
    MatCardModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'film', component: FilmListComponent, canActivate: [AuthGuard]  },
      { path: 'projection/:filmId', component: ProjectionListComponent, canActivate: [AuthGuard] },
      { path: 'order/:viewerId', component: OrderListComponent, canActivate: [AuthGuard]},
      { path: 'administration', component: AdministrationComponent, canActivate: [AuthGuard]},
      { path: 'add/:type', component: AdditemComponent, canActivate: [AuthGuard]},
      { path: 'edit/:type/:id', component: ModifyitemComponent, canActivate: [AuthGuard]},
      { path: 'basket/add/:projectionid/:viewerid', component: BasketComponent, canActivate: [AuthGuard]},
      { path: 'basket/:viewerid', component: BasketListComponent, canActivate: [AuthGuard]},
      { path: 'details/:filmid', component: DetailsComponent, canActivate: [AuthGuard]},
      { path: 'tickets/:viewerid', component: TicketComponent, canActivate: [AuthGuard]},
      { path: 'login', component: LoginComponent },
      { path: 'logout', component: LogoutComponent,canActivate: [AuthGuard]},
      { path: 'register', component: RegisterComponent }
    ]),
    
  ],
  providers: [FilmService, ProjectionService, OrderService, RoomService, ViewerService, ReservationService, AuthService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
