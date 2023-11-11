import { Component } from '@angular/core';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-admin-dealer-add',
  templateUrl: './admin-dealer-add.component.html',
  styleUrls: ['./admin-dealer-add.component.css']
})
export class AdminDealerAddComponent {
  
  // Properties for the dealer form
  public UserNumber!: number;
  public UserName!: string;
  public UserEmail!: string;
  public UserPassword!: string;
  public UserRole!: string;
  public UserBalance!: number;
  public UserProfitMargin!: number;

  constructor(
    private http: HttpClient,
    private userService: UserService,
    private router: Router
  ) {}

  // Method to handle logout
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

  // Method to handle dealer form submission
  submitDealerForm() {
    
    if (!this.UserNumber || !this.UserName || !this.UserEmail || !this.UserPassword || !this.UserBalance || !this.UserProfitMargin) {
      Swal.fire({
        title: 'Hata!',
        text: 'Lütfen tüm alanları doldurun.',
        icon: 'info',
        confirmButtonText: 'Tamam',
      });
      return; // Formu gönderme işlemi burada sona erer.
    }

    const data = {
      UserNumber: this.UserNumber,
      UserName: this.UserName,
      UserEmail: this.UserEmail,
      UserPassword: this.UserPassword,
      UserRole: "Dealer",
      UserBalance: this.UserBalance,
      UserProfitMargin: this.UserProfitMargin
    };

    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    // Send a post request using HttpClient
    this.http.post(`${environment.apiUrl}Users`, data, { headers: headers }).subscribe(
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

  showSuccessAlert() {
    Swal.fire({
      title: 'Başarılı!',
      text: 'Kullanıcı başarıyla eklendi.',
      icon: 'success',
      confirmButtonText: 'Tamam',
      timer: 2000,
      timerProgressBar: true,
    });
  }
  
  showErrorAlert() {
    Swal.fire({
      title: 'Hata!',
      text: 'Bir hata oluştu. Lütfen tekrar deneyin.',
      icon: 'error',
      confirmButtonText: 'Tamam',
    });
  }
}
