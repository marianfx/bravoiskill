import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoginComponent } from './modules/login/components/login.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { JwtInterceptor } from './auth/interceptors/jwt.interceptor';
import { ErrorInterceptor } from './auth/interceptors/error.interceptor';
import { ChartsModule } from 'ng2-charts';
import { HomeComponent } from './modules/home/components/home.component';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from './shared/shared-modules/navbar/navbar.component';
import { FooterComponent } from './shared/shared-modules/footer/footer.component';
import { UserService } from './shared/shared-services/user.service';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { AccordionModule } from 'primeng/accordion';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { CalendarModule } from 'primeng/calendar';
import { TabMenuModule } from 'primeng/tabmenu';
import { SkillService } from './shared/shared-services/skill.service';
import { DropdownModule } from 'primeng/dropdown';
import { ProfileComponent } from './modules/profile/components/profile.component';
import { AgmCoreModule } from '@agm/core';
import { MatSliderModule } from '@angular/material/slider';
import { MatChipsModule } from '@angular/material/chips';
import { UsersTableComponent } from './modules/users-table/components/users-table.component';
import { ProfileReviewsComponent } from './modules/profile-reviews/components/profile-reviews.component';
import { ReviewsCommentsComponent } from './modules/reviews-comments/components/reviews-comments.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    LoginComponent,
    HomeComponent,
    UsersTableComponent,
    ProfileComponent,
    ProfileReviewsComponent,
    ReviewsCommentsComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    NgbModule,
    FormsModule,
    RouterModule,
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    ButtonModule,
    TableModule,
    DialogModule,
    AccordionModule,
    BrowserAnimationsModule,
    CalendarModule,
    TabMenuModule,
    DropdownModule,
    MatSliderModule,
    MatChipsModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyC1ReIVGVAdDP09g6YUAYhzhCtmSFiXxeY'}),
    ChartsModule
  ],
  exports: [],
  providers: [
    SkillService,
    UserService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
