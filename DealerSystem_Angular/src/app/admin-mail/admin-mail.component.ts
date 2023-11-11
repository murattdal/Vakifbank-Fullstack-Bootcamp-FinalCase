// Import necessary modules
import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';



// Import statements...

@Component({
  selector: 'app-admin-mail',
  templateUrl: './admin-mail.component.html',
  styleUrls: ['./admin-mail.component.css']
})
export class AdminMailComponent {

  // Properties with default empty values
  name: string = '';
  email: string = '';
  phone: string = '';
  message: string = '';

  // Constructor with injected dependencies
  constructor(
    private http: HttpClient,
    private userService: UserService,
    private router: Router,
  ) {}

  // Function to send mail
  sendMail() {

    // Check if required fields are empty
    if (!this.name || !this.email || !this.message) {
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
        this.showSuccessAlert();
        this.router.navigateByUrl(`/AdminPage`);
      },
      (error) => {
        console.error('Error:', error);
        this.showErrorAlert();
      }
    );
  }

  // Function to show success alert
  showSuccessAlert() {
    Swal.fire({
      title: 'Başarılı!',
      text: 'Mesajınız başarıyla gönderildi.',
      icon: 'success',
      confirmButtonText: 'Tamam',
    });
  }

  // Function to show error alert
  showErrorAlert() {
    Swal.fire({
      title: 'Hata!',
      text: 'Bir hata oluştu. Lütfen tekrar deneyin.',
      icon: 'error',
      confirmButtonText: 'Tamam',
    });
  }

  // Logout function
  logout() {
    this.userService.clearLoggedInUser();
    this.router.navigateByUrl(`/Login`);
    this.showLogoutAlert();
  }

  // Function to show logout success alert
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
