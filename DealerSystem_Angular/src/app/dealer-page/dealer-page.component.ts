import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import Swal from 'sweetalert2';

interface Product {
  id: number;
  productName: string;
  productQuantity: number;
  productPrice: number;
  productInformation: string;
  productImage: string;
}

@Component({
  selector: 'app-dealer-page',
  templateUrl: './dealer-page.component.html',
  styleUrls: ['./dealer-page.component.css']
})
export class DealerPageComponent implements OnInit {
  products: Product[] = [];
  userId!: number;
  quantities: { [productId: number]: number } = {};

  constructor(private http: HttpClient, private userService: UserService, private router: Router) {}

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts() {
    this.http.get(`${environment.apiUrl}Products`).subscribe((data: any) => {
      this.products = data.response;

      this.products.forEach(product => {
        this.quantities[product.id] = 0;
      });
    });
  }

  addToBasket(product: Product) {
    const loggedInUser = this.userService.getLoggedInUser();
    let userId = loggedInUser.Id;
    userId = Number(userId);

    const request = {
      UserId: userId,
      ProductId: product.id,
      orderId: 0,
      BasketQuantity: 1, // Use the quantity from the quantities object
      BasketPrice: 1 * product.productPrice,
      BasketStatus: true
    };

    // Sepete ekleme yapar
    this.http.post(`${environment.apiUrl}ShoppingBaskets`, request).subscribe(
      (data: any) => {
        this.showSuccessAlert(product.productName);
      },
      (error: any) => {
        console.error('Error:', error);
        this.showErrorAlert();
      }
    );
  }

  logout() {
    this.userService.clearLoggedInUser(); 
    this.router.navigateByUrl(`/Login`);
    this.showLogoutAlert();
  }

  // Method to show success alert
  showSuccessAlert(productName: string) {
    Swal.fire({
      title: 'Başarılı!',
      text: `${productName} başarıyla sepete eklendi.`,
      icon: 'success',
      confirmButtonText: 'Tamam'
    });
  }

  // Method to show error alert
  showErrorAlert() {
    Swal.fire({
      title: 'Hata!',
      text: 'Ürün sepete eklenirken bir hata oluştu.',
      icon: 'error',
      confirmButtonText: 'Tamam'
    });
  }

  // Method to show logout success alert
  showLogoutAlert() {
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
