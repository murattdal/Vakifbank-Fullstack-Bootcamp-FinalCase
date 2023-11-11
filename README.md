
# Bayi Sistemi

Bayi Sistemi, dinamik stok yönetimi, sipariş işlemleri ve admin onay süreçlerini içeren bir B2B (Business to Business) projesidir. Bu proje, code-first yaklaşımıyla geliştirilmiş olup, MSSQL veritabanı kullanılarak hayata geçirilmiştir. Bayi Sistemi, toptan ürün alımı için tasarlanmış bir web sitesidir, bayilerin kullanıcı dostu bir arayüzle stoktaki ürünleri görüntülemelerine, sipariş vermelerine ve bu siparişlerin admin onayını beklemelerine olanak tanır.


## Projenin Temel Özellikleri

- **Stok Yönetimi:** Bayiler, dinamik bir şekilde stoktaki ürünleri görüntüleyebilir ve bu ürünleri detaylı bir şekilde inceleyebilir.

- **Sipariş İşlemleri:** Bayiler, web sitesi üzerinden sipariş verebilir ve bu siparişlerin admin onayını bekleyebilir. Ayrıca, bekleyen siparişlerini görüntüleyebilir ve gerektiğinde iptal edebilir.

- **İletişim:** Bayiler, web sitesi sahibi ile mail aracılığıyla iletişime geçebilirler. Bu, sipariş durumu, ürün talepleri veya genel sorular için bir iletişim kanalı sağlar.

- **Güvenli Giriş:** Proje, token tabanlı bir kimlik doğrulama sistemi ile güvenli girişi destekler. Bu sayede, bayilerin hesapları güvende tutulur.

- **MSSQL Veritabanı:** Veritabanı yönetimi ve güncellemeleri için migrationlar kullanılmıştır, bu da veritabanının düzenli ve güncel kalmasını sağlar.

- **CQRS ve Unit of Work Prensipleri:** Bu projede, CQRS ve Unit of Work prensipleri kullanılarak, komut ve sorgu işlemleri ayrılmıştır. Bu, performans ve ölçeklenebilirlik avantajları sağlar.

## Ekran Görüntüleri


![ScreenShot_1](https://github.com/murattdal/Vakifbank-Fullstack-Bootcamp-FinalCase/assets/69681710/e71bd4f5-b5fc-47dc-b03e-e89674d85fe7)
<p align="center"> <strong>Şekil 1:</strong> İlk Giriş Ekranı </p>

![image](https://github.com/murattdal/Vakifbank-Fullstack-Bootcamp-FinalCase/assets/69681710/5c436bf2-99db-4072-bbf4-89416bbab5b8)
<p align="center">  <strong>Şekil 2:</strong> Yönetici Paneli </p>

![image](https://github.com/murattdal/Vakifbank-Fullstack-Bootcamp-FinalCase/assets/69681710/63636303-75af-456e-b127-c887e2ada83b)
<p align="center">  <strong>Şekil 3:</strong> Kullanıcı Paneli </p>

![image](https://github.com/murattdal/Vakifbank-Fullstack-Bootcamp-FinalCase/assets/69681710/c94027b1-1489-4a8d-ba58-892d4796c3f0)
<p align="center">  <strong>Şekil 4:</strong> Swagger Paneli </p>

![image](https://github.com/murattdal/Vakifbank-Fullstack-Bootcamp-FinalCase/assets/69681710/83c6cede-6163-4e3e-bf0b-d6b544f14b49)
<p align="center">  <strong>Şekil 5:</strong> Veri Tabanı Tabloları ve Bağlantıları </p>
