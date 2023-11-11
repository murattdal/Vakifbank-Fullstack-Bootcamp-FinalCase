import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { routes } from './routes/routes';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { DealerPageComponent } from './dealer-page/dealer-page.component';
import { DealerOrdersComponent } from './dealer-orders/dealer-orders.component';
import { AboutPageComponent } from './about-page/about-page.component';
import { AdminStockControlComponent } from './admin-stock-control/admin-stock-control.component';
import { AdminInfoComponent } from './admin-info/admin-info.component';
import { AdminDealerInquiryComponent } from './admin-dealer-inquiry/admin-dealer-inquiry.component';
import { AdminMailComponent } from './admin-mail/admin-mail.component';
import { ToastrModule } from 'ngx-toastr';
import { AdminProductAddComponent } from './admin-product-add/admin-product-add.component';
import { AdminDealerAddComponent } from './admin-dealer-add/admin-dealer-add.component';
import { DealerMailComponent } from './dealer-mail/dealer-mail.component';
import { DealerPaymentComponent } from './dealer-payment/dealer-payment.component';




@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    AdminPageComponent,
    DealerPageComponent,
    DealerOrdersComponent,
    AboutPageComponent,
    AdminStockControlComponent,
    AdminInfoComponent,
    AdminDealerInquiryComponent,
    AdminMailComponent,
    AdminProductAddComponent,
    AdminDealerAddComponent,
    DealerMailComponent,
    DealerPaymentComponent
  ],
  imports: [
    ToastrModule.forRoot(),
    HttpClientModule,
    BrowserModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
