import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css']
})
export class AdminPageComponent implements OnInit {

  // Arrays to store waiting and completed orders
  waitingOrders: any[] = [];
  completedOrders: any[] = [];


  constructor(
    private http: HttpClient,
    private userService: UserService,
    private router: Router
  ) { }

  ngOnInit(): void {
    // Load orders on component initialization
    this.loadOrders();
  }

  // Function to load orders
  loadOrders() {
    this.http.get(`${environment.apiUrl}CustomerOrders`).subscribe((data: any) => {
      // Filter orders based on status
      this.waitingOrders = (data.response as any[]).filter((order: any) => order.orderStatus === 'Waiting');
      this.completedOrders = (data.response as any[]).filter((order: any) => order.orderStatus === 'Completed');
    });
  }

  // Function to delete an order
  deleteOrder(order: any) {
    this.http.delete(`${environment.apiUrl}CustomerOrders/${order.id}`).subscribe(() => {
      // Reload orders after deleting an order
      this.loadOrders();
      Swal.fire({
        title: 'Başarılı!',
        text: 'İptal Edildi.',
        icon: 'success',
        confirmButtonText: 'Tamam',
        timer: 2000, 
        timerProgressBar: true, 
      });
    });
    
  }

  // Function to update order status
  updateOrder(order: any) {
    // Prepare updated order object
    const updatedOrder = {
      id: order.id,
      orderStatus: 'Completed',
      orderPaymentMethod: order.orderPaymentMethod,
      orderAmount: order.orderAmount
    };

    // Update order status
    this.http.put(`${environment.apiUrl}CustomerOrders/${order.id}`, updatedOrder).subscribe((data: any) => {
      // Update order status locally
      order.orderStatus = 'Completed';
      // Reload orders after updating an order
      this.loadOrders();
    });
  }

  // Function to log out the user
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
