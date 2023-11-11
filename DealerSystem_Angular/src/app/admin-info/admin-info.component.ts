import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-admin-info',
  templateUrl: './admin-info.component.html',
  styleUrls: ['./admin-info.component.css']
})
export class AdminInfoComponent {

    // Toplam satış fiyatları değişkenleri
    totalOrderAmountOneDay: number = 0;
    totalOrderAmountSevenDays: number = 0;
    totalOrderAmountThirtyDays: number = 0;


  constructor(private http: HttpClient,
    private userService: UserService,
    private router: Router,) { }


  
  ngOnInit(): void {
    this.getData();
  }

  getData() {
    const apiUrl = `${environment.apiUrl}CustomerOrders`;
    this.http.get(apiUrl).subscribe((response: any) => {
      const orders = response.response;
      const currentDate = new Date();
  
      // Son 1 gün ve Complated olmuş siparişler
      const filterDateOneDay = new Date(currentDate.setDate(currentDate.getDate() - 1));
      this.totalOrderAmountOneDay = this.calculateTotalOrderAmount(orders, filterDateOneDay, 'Completed');
  
      // Son 7 gün ve Complated olmuş siparişler
      const filterDateSevenDays = new Date(currentDate.setDate(currentDate.getDate() - 6));
      this.totalOrderAmountSevenDays = this.calculateTotalOrderAmount(orders, filterDateSevenDays, 'Completed');
  
      // Son 30 gün ve Complated olmuş siparişler
      const filterDateThirtyDays = new Date(currentDate.setDate(currentDate.getDate() - 23));
      this.totalOrderAmountThirtyDays = this.calculateTotalOrderAmount(orders, filterDateThirtyDays, 'Completed');
    });
  }

  // Toplam satış fiyatını hesapla
  calculateTotalOrderAmount(orders: any[], filterDate: Date, status: string): number {
    return orders
      .filter((order: any) => new Date(order.insertDate) >= filterDate && order.orderStatus === status)
      .reduce((total: number, order: any) => total + order.orderAmount, 0);
  }

  logout() {
    this.userService.clearLoggedInUser(); 
    this.router.navigateByUrl(`/Login`);
    Swal.fire({
      title: 'Başarılı!',
      text: 'Başarıyla Çıkış Yapıldı.',
      icon: 'success',
      confirmButtonText: 'Tamam',
      timer: 2000, 
      timerProgressBar: true, 
    });
  }


}
