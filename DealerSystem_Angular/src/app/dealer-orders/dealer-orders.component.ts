import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-dealer-orders',
  templateUrl: './dealer-orders.component.html',
  styleUrls: ['./dealer-orders.component.css']
})
export class DealerOrdersComponent implements OnInit {
  loggedInUserId!: number;
  waitingOrders: any[] = [];
  completedOrders: any[] = [];

  constructor(private http: HttpClient, private userService: UserService, private router: Router) { }

  ngOnInit(): void {
    this.loadLoggedInUserId();
    this.loadOrders();
  }

  loadLoggedInUserId(): void {
    const loggedInUser = this.userService.getLoggedInUser();
    this.loggedInUserId = loggedInUser ? Number(loggedInUser.Id) : 0;
  }

  loadOrders(): void {
    this.http.get(`${environment.apiUrl}CustomerOrders`).subscribe((data: any) => {
      const allOrders = data.response as any[];
      this.waitingOrders = this.filterOrders(allOrders, 'Waiting');
      this.completedOrders = this.filterOrders(allOrders, 'Completed');
    });
  }

  filterOrders(orders: any[], status: string): any[] {
    return orders.filter((order: any) => order.orderStatus === status && order.userId === this.loggedInUserId);
  }

  deleteOrder(order: any): void {
    this.http.delete(`${environment.apiUrl}CustomerOrders/${order.id}`).subscribe(
      () => {
        this.showSuccessAlert('Sipariş başarıyla silindi.');
        this.loadOrders(); // Siparişi sildikten sonra verileri yeniden yükle
      },
      (error) => {
        console.error('Error:', error);
        this.showErrorAlert('Sipariş silinirken bir hata oluştu. Lütfen tekrar deneyin.');
      }
    );
  }

  logout(): void {
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

  // Method to show success alert
  showSuccessAlert(message: string) {
    Swal.fire({
      title: 'Başarılı!',
      text: message,
      icon: 'success',
      confirmButtonText: 'Tamam'
    });
  }

  // Method to show error alert
  showErrorAlert(message: string) {
    Swal.fire({
      title: 'Hata!',
      text: message,
      icon: 'error',
      confirmButtonText: 'Tamam'
    });
  }
}
