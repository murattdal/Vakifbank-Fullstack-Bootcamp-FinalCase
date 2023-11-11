import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../user.service';
import { environment } from '../../environments/environment';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {
  loginObj: any = {
    "userEmail": "",
    "userPassword": ""
  };

  constructor(
    private http: HttpClient,
    private router: Router,
    private toastr: ToastrService,
    private userService: UserService
  ) { }

  onLogin() {
    if (!this.loginObj.userEmail || !this.loginObj.userPassword) {
      Swal.fire({
        title: 'Hata!',
        text: 'Lütfen tüm alanları doldurun.',
        icon: 'info',
        timer: 2000,
        confirmButtonText: 'Tamam',
      });
      return;
    }

    const body = JSON.stringify(this.loginObj);
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

    this.http.post(`${environment.apiUrl}Tokens`, body, { headers: headers }).subscribe((res: any) => {
      if (res.success) {
        Swal.fire({
          title: 'Başarılı!',
          text: 'Başarıyla giriş yapıldı.',
          icon: 'success',
          confirmButtonText: 'Tamam',
          timer: 2000, 
          timerProgressBar: true, 
        });
        localStorage.setItem('loginToken', res.response.token);
        const tokenPayload = JSON.parse(atob(res.response.token.split('.')[1]));

        this.userService.setLoggedInUser(tokenPayload);

        const userRole = tokenPayload.UserRole;
        const userId = parseInt(tokenPayload.Id);

        if (userRole === 'Admin') {
          this.router.navigateByUrl(`/AdminPage`);
        } else if (userRole === 'Dealer') {
          this.router.navigateByUrl(`/DealerPage`);
        }
      } else {
        alert(res.message);
      }
    }, error => {
      console.error(error);
      alert('An error occurred during login.');
    });
  }
}
