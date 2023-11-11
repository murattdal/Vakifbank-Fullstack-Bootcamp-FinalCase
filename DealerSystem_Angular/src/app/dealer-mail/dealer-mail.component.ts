import { Component } from '@angular/core';
import { environment } from '../../environments/environment';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-dealer-mail',
  templateUrl: './dealer-mail.component.html',
  styleUrls: ['./dealer-mail.component.css']
})
export class DealerMailComponent {
  // Initialize properties with empty values
  name: string = '';
  email: string = '';
  phone: string = '';
  message: string = '';

  constructor(private http: HttpClient, private userService: UserService, private router: Router) {}

  // Function to send mail
  sendMail() {
    // Boşluk kontrolü
    if (!this.name || !this.email || !this.phone || !this.message) {
      Swal.fire({
        title: 'Hata!',
        text: 'Lütfen tüm alanları doldurun.',
        icon: 'info',
        confirmButtonText: 'Tamam',
      });
      return;
    }

    // Create an object with the data to be sent in the post request
    const data = {
      Name: this.name,
      Email: this.email,
      Phone: this.phone,
      Description: this.message
    };

    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    // Send a post request using HttpClient
    this.http.post(`${environment.apiUrl}Mails`, data, { headers: headers }).subscribe(
      (response) => {
        console.log('Response:', response);
        this.showSuccessAlert('Başarılı!');
        this.router.navigateByUrl(`/DealerPage`);
      },
      (error) => {
        console.error('Error:', error);
        this.showErrorAlert('Hata oluştu. Lütfen tekrar deneyin.');
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
