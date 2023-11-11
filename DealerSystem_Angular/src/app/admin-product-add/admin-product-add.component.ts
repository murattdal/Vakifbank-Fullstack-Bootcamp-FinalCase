import { Component } from '@angular/core';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-admin-product-add',
  templateUrl: './admin-product-add.component.html',
  styleUrls: ['./admin-product-add.component.css']
})
export class AdminProductAddComponent {
  // Properties for the product form
  public ProductName: string = '';
  public ProductImage: string = '';
  public ProductQuantity: number | null = null;
  public ProductPrice: number | null = null;
  public ProductInformation: string = '';

  constructor(
    private http: HttpClient,
    private userService: UserService,
    private router: Router
  ) {}

  // Method to handle logout
  logout() {
    this.userService.clearLoggedInUser();
    this.router.navigateByUrl(`/Login`);
    this.showLogoutAlert();
  }

  // Method to handle form submission
  submitProductForm() {
    // Check if required fields are empty
    if (!this.ProductName || !this.ProductImage || this.ProductQuantity === null || this.ProductPrice === null || !this.ProductInformation) {
      this.showEmptyFieldsAlert();
      return;
    }

    const data = {
      ProductName: this.ProductName,
      ProductImage: this.ProductImage,
      ProductQuantity: this.ProductQuantity,
      ProductPrice: this.ProductPrice,
      ProductInformation: this.ProductInformation,
    };

    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    // Send a post request using HttpClient
    this.http.post(`${environment.apiUrl}Products`, data, { headers: headers }).subscribe(
      (response) => {
        console.log('Response:', response);
        this.router.navigateByUrl(`/AdminPage`);
        this.showSuccessAlert();
      },
      (error) => {
        console.error('Error:', error);
        this.showErrorAlert();
      }
    );
  }

  // Method to show success alert
  showSuccessAlert() {
    Swal.fire({
      title: 'Başarılı!',
      text: 'Ürün başarıyla eklendi.',
      icon: 'success',
      confirmButtonText: 'Tamam'
    });
  }

  // Method to show error alert
  showErrorAlert() {
    Swal.fire({
      title: 'Hata!',
      text: 'Ürün eklenirken bir hata oluştu.',
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

  // Method to show empty fields alert
  showEmptyFieldsAlert() {
    Swal.fire({
      title: 'Hata!',
      text: 'Tüm alanları doldurunuz.',
      icon: 'info',
      confirmButtonText: 'Tamam'
    });
  }
}
