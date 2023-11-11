import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment'
import Swal from 'sweetalert2';

@Component({
  selector: 'app-admin-dealer-inquiry',
  templateUrl: './admin-dealer-inquiry.component.html',
  styleUrls: ['./admin-dealer-inquiry.component.css']
})
export class AdminDealerInquiryComponent {

  constructor(private http: HttpClient,
    private userService: UserService,
    private router: Router,) { }

  ngOnInit(): void {
    this.loadDealers();
  }


  dealers: any[] = [];


  loadDealers() {
    this.http.get(`${environment.apiUrl}Users`).subscribe((data: any) => {
      this.dealers = (data.response as any[]).filter((user: any) => user.userRole === "Dealer");


    });
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

   // Function to delete an dealer
   deleteUser(user: any) {
    Swal.fire({
      title: 'Emin misiniz?',
      text: 'Bu işlemi gerçekleştirmek istediğinizden emin misiniz?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Evet, devam et',
      cancelButtonText: 'Hayır, vazgeç',
    }).then((result) => {
      if (result.isConfirmed) {
        // Onaylandı
        this.http.delete(`${environment.apiUrl}Users/${user.id}`).subscribe(() => {
          // Reload orders after deleting an order
          this.loadDealers();
        });
        Swal.fire('Başarılı!', 'İşlem başarıyla gerçekleştirildi.', 'success');
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        // İptal edildi
        Swal.fire('İptal Edildi', 'İşlem iptal edildi', 'error');
      }
    });
    
    
  }

}
