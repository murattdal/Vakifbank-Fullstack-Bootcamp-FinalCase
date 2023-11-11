import { Routes } from "@angular/router";
import { LoginPageComponent } from "../login-page/login-page.component";
import { AboutPageComponent } from "../about-page/about-page.component";
import { DealerPageComponent } from "../dealer-page/dealer-page.component";
import { DealerOrdersComponent } from "../dealer-orders/dealer-orders.component";
import { AdminPageComponent } from "../admin-page/admin-page.component";
import { AdminDealerInquiryComponent } from "../admin-dealer-inquiry/admin-dealer-inquiry.component";
import { AdminInfoComponent } from "../admin-info/admin-info.component";
import { AdminStockControlComponent } from "../admin-stock-control/admin-stock-control.component";
import { AdminMailComponent } from "../admin-mail/admin-mail.component";
import { AdminProductAddComponent } from "../admin-product-add/admin-product-add.component";
import { AdminDealerAddComponent } from "../admin-dealer-add/admin-dealer-add.component";
import { DealerMailComponent } from "../dealer-mail/dealer-mail.component";
import { DealerPaymentComponent } from "../dealer-payment/dealer-payment.component";


export const routes: Routes = [

    {path:"", component:LoginPageComponent},
    {path:"Login", component:LoginPageComponent},
    {path:"About", component:AboutPageComponent},
    {path:"DealerPage", component:DealerPageComponent},
    {path:"AdminPage", component:AdminPageComponent},
    {path:"AdminDealerInquiry", component:AdminDealerInquiryComponent},
    {path:"AdminInfo", component:AdminInfoComponent},
    {path:"AdminStockControl", component:AdminStockControlComponent},
    {path:"AdminMail", component:AdminMailComponent},
    {path:"AdminProductAdd", component:AdminProductAddComponent},
    {path:"AdminDealerAdd", component:AdminDealerAddComponent},
    {path:"DealerOrders", component:DealerOrdersComponent},
    {path:"DealerMail", component:DealerMailComponent},
    {path:"DealerPayment", component:DealerPaymentComponent},

];