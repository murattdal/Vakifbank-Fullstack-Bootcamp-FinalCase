import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-dealer-payment',
  templateUrl: './dealer-payment.component.html',
  styleUrls: ['./dealer-payment.component.css']
})
export class DealerPaymentComponent {

  ngOnInit(): void {
    const loggedInUser = this.userService.getLoggedInUser();
    this.loggedInUserId = loggedInUser.Id;
    this.loadBaskets();
  }

  constructor(private http: HttpClient, private userService: UserService, private router: Router) { }

  products: any[] = [];
  loggedInUserId!: number;
  baskets: any[] = [];
  insertDate: string = this.getCurrentDate();
  selectedPaymentMethod: string = '';

  loadBaskets() {
    let Id = this.loggedInUserId;
    Id = Number(Id);

    this.http.get(`${environment.apiUrl}ShoppingBaskets?userId=${this.loggedInUserId}`).subscribe((data: any) => {
      this.baskets = data.response.filter((item: any) => item.basketStatus == true && item.userId === Id);

      this.baskets.forEach(basket => {
        this.getProductNameById(basket.productId, basket);
      });
    });
  }

  getProductNameById(productId: number, basket: any) {
    this.http.get(`${environment.apiUrl}Products/${productId}`).subscribe((data: any) => {
      if (basket) {
        basket.productName = data.response.productName;
      }
    });
  }

  getTotalPrice(): number {
    return this.baskets.reduce((acc, curr) => acc + curr.basketPrice, 0);
  }

  getCurrentDate(): string {
    const currentDate = new Date();
    const year = currentDate.getFullYear();
    const month = ('0' + (currentDate.getMonth() + 1)).slice(-2);
    const day = ('0' + currentDate.getDate()).slice(-2);
    const hours = ('0' + currentDate.getHours()).slice(-2);
    const minutes = ('0' + currentDate.getMinutes()).slice(-2);
    const seconds = ('0' + currentDate.getSeconds()).slice(-2);

    const formattedDate = `${year}-${month}-${day}T${hours}:${minutes}:${seconds}`;
    return formattedDate;
  }

  makePayment() {
    if (!this.selectedPaymentMethod) {
      this.showInfoAlert('Lütfen bir kart türü seçiniz.');
      return;
    }

    let Id = this.loggedInUserId;
    Id = Number(Id);

    const orderData = {
      userId: Id,
      orderStatus: 'Waiting',
      orderPaymentMethod: this.selectedPaymentMethod,
      orderAmount: this.getTotalPrice(),
      insertDate: this.getCurrentDate()
    };

    this.http.post(`${environment.apiUrl}CustomerOrders`, orderData).subscribe(
      (response) => {
        console.log('Response from API:', response);

        this.baskets.forEach(product => {
          this.updateBasketStatus(product.id);
          this.updateProductStock(product.productId, product.basketQuantity);
        });

        this.showSuccessAlert('Ödeme başarıyla tamamlandı.');
        this.router.navigateByUrl(`/DealerPage`);
      },
      (error) => {
        console.log('Error from API:', error);
        this.showErrorAlert('Ödeme işlemi sırasında bir hata oluştu. Lütfen tekrar deneyin.');
      }
    );
  }

  updateProductStock(productId: number, quantity: number) {
    this.http.get(`${environment.apiUrl}Products/${productId}`).subscribe((data: any) => {
      const product = data.response;

      if (product) {
        quantity = 1; // 1 adet eksilecek
        product.productQuantity -= quantity;

        console.log(`Updating stock for product ID ${productId}. New quantity: ${product.productQuantity}`);

        this.http.put(`${environment.apiUrl}Products/${productId}`, product).subscribe();
      }
    });
  }

  updateBasketStatus(basketId: number) {
    const updatedBasket = {
      basketStatus: false
    };

    console.log('Updating basket status for basket ID:', basketId);

    this.http.put(`${environment.apiUrl}ShoppingBaskets/${basketId}`, updatedBasket).subscribe(
      (response) => {
        this.products = this.products.filter(product => product.id !== basketId);
      }
    );
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

  showInfoAlert(message: string) {
    Swal.fire({
      title: 'Bilgi!',
      text: message,
      icon: 'info',
      confirmButtonText: 'Tamam'
    });
  }

  showSuccessAlert(message: string) {
    Swal.fire({
      title: 'Başarılı!',
      text: message,
      icon: 'success',
      confirmButtonText: 'Tamam'
    });
  }

  showErrorAlert(message: string) {
    Swal.fire({
      title: 'Hata!',
      text: message,
      icon: 'error',
      confirmButtonText: 'Tamam'
    });
  }
}
