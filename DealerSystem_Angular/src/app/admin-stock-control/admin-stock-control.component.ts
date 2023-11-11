import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-admin-stock-control',
  templateUrl: './admin-stock-control.component.html',
  styleUrls: ['./admin-stock-control.component.css']
})
export class AdminStockControlComponent {

  selectedProduct: any;
  products: any[] = [];
  newStock: number = 0;
  newQuantity: number=0;
  
  constructor(private http: HttpClient,
    private userService: UserService,
    private router: Router,) { }

  ngOnInit() {
    this.loadProducts();
  }


  selectProduct(product: any) {
    this.selectedProduct = product;
    this.newStock = product.productQuantity;
  }


  // Ürünleri Getir
  loadProducts() {
    this.http.get<any>(`${environment.apiUrl}Products`).subscribe(data => {
      this.products = data.response;
      console.log(this.products)
    });
  }

  // Function to delete an product
  deleteProduct(product: any) {
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
        this.http.delete(`${environment.apiUrl}Products/${product.id}`).subscribe(() => {
          // Reload orders after deleting an order
          this.loadProducts();
        });
        Swal.fire('Başarılı!', 'İşlem başarıyla gerçekleştirildi.', 'success');
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        // İptal edildi
        Swal.fire('İptal Edildi', 'İşlem iptal edildi', 'error');
      }
    });
    
    
  }


  //Stokları Güncelle
  updateProductQuantity(product: any) {
    const updatedProduct = {
        id: product.id,
        productName: product.productName,
        productImage: "image.jpg",
        productQuantity: product.productQuantity + 10, // Yeni stok miktarını hesaplayın
        productPrice: product.productPrice,
        productInformation: product.productInformation
    };

    this.http.put<any>(`${environment.apiUrl}Products/` + product.id, updatedProduct)
        .subscribe(data => {
            // Güncelleme işlemi tamamlandıktan sonra verileri tekrar yükleme işlemi burada yapılabilir
            this.loadProducts(); // Ürünleri yeniden yükle

            Swal.fire({
              title: 'Başarılı!',
              text: '10 tane ürün eklendi.',
              icon: 'success',
              confirmButtonText: 'Tamam',
              timer: 2000, 
              timerProgressBar: true, 
            });

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
    timer: 3000, 
    timerProgressBar: true, 
  });
}

}
