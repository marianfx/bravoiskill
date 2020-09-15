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
import { AuthenticationErrorInterceptor } from './auth/interceptors/error.interceptor';
import { ServerErrorInterceptor } from './auth/interceptors/servererror.interceptor';
import { ChartsModule } from 'ng2-charts';
import { HomeComponent } from './modules/home/components/home.component';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from './shared/shared-modules/navbar/navbar.component';
import { FooterComponent } from './shared/shared-modules/footer/footer.component';
import { UserService } from './shared/shared-services/user.service';
import { TableModule } from 'primeng/table';
import { MessageModule } from 'primeng/message';
import { MessagesModule } from 'primeng/messages';
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
import { ReviewsCommentsComponent } from './modules/review-modules/reviews-comments/components/reviews-comments.component';
import { CardComponent } from './modules/review-modules/review-card/components/review-card.component';
import { AddReviewComponent } from './modules/review-modules/add-review/add-review.component';
import { ProfileReviewsComponent } from './modules/review-modules/profile-reviews/components/profile-reviews.component';
import { SkillCardComponent } from './modules/review-modules/skill-card/components/skill-card.component';
import { SkillCategoryComponent } from './modules/review-modules/skill-category/components/skill-category.component';
import { CardModule } from 'primeng/card'
import { SliderModule } from 'primeng/slider';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { LoaderComponent } from './shared/loader/loader.component';
import { LoaderService } from './auth/service/loader.service';
import { LoaderInterceptor } from './auth/interceptors/loader.interceptor';
import { SkillPoints } from './modules/review-modules/skill-points.service';
import { ToastModule } from 'primeng/toast';
import { AlertToastComponent } from './shared/alert-toast/alert-toast.component';
import { MessageService } from 'primeng/api';
import { ServerErrorService } from './auth/service/servererror.service';
import { ExportService } from './modules/users-table/services/export.service';
import { CarouselModule } from 'primeng/carousel';
import { DepartmentService } from './shared/shared-services/department.service';
import { TestModuleComponent } from './test-module/test-module.component';
import {FieldsetModule} from 'primeng/fieldset';
import {ToolbarModule} from 'primeng/toolbar';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material';
import {MultiSelectModule} from 'primeng/multiselect';
import {ProgressBarModule} from 'primeng/progressbar';
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
    ReviewsCommentsComponent,
    CardComponent,
    AddReviewComponent,
    SkillCardComponent,
    SkillCategoryComponent,
    LoaderComponent,
    AlertToastComponent,
    TestModuleComponent
  ],
  imports: [
    CarouselModule,
    MatProgressSpinnerModule,
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
    MessageModule,
    MessagesModule,
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
    ChartsModule,
    CardModule,
    SliderModule,
    ToastModule,
    FieldsetModule,
    ToolbarModule,
    MatProgressBarModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatFormFieldModule,
    MatInputModule,
    MultiSelectModule,
    ProgressBarModule,
  ],
  exports: [],
  providers: [
    SkillPoints,
    LoaderService,
    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true },
    SkillService,
    UserService,
    DepartmentService,
    MessageService,
    ExportService,
    ServerErrorService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: AuthenticationErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ServerErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
