
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


![image](https://github.com/murattdal/Vakifbank-Fullstack-Bootcamp-FinalCase/assets/69681710/4820e8ee-e58b-4843-8d6c-ddac992e4577)
<p align="center"> <strong>Şekil 1:</strong> İlk Giriş Ekranı </p>

![image](https://github.com/murattdal/Vakifbank-Fullstack-Bootcamp-FinalCase/assets/69681710/c6cbe2b4-d80c-4ec8-b201-26e4bb65d00a)
<p align="center">  <strong>Şekil 2:</strong> Yönetici Paneli </p>

![image](https://github.com/murattdal/Vakifbank-Fullstack-Bootcamp-FinalCase/assets/69681710/6ff004f8-80b3-471c-a658-5753e3d4236d)
<p align="center">  <strong>Şekil 3:</strong> Kullanıcı Paneli </p>

![image](https://github.com/murattdal/Vakifbank-Fullstack-Bootcamp-FinalCase/assets/69681710/b1cf6038-a941-4008-822f-6c4d5315f04c)
<p align="center">  <strong>Şekil 4:</strong> Swagger Paneli </p>

![image](https://github.com/murattdal/Vakifbank-Fullstack-Bootcamp-FinalCase/assets/69681710/2313a3f5-3273-4cd3-806b-b79cd5abaeb2)
<p align="center">  <strong>Şekil 5:</strong> Veri Tabanı Tabloları ve Bağlantıları </p>

![image](https://github.com/murattdal/Vakifbank-Fullstack-Bootcamp-FinalCase/assets/69681710/87081930-6086-41e2-907d-616687fddb7c)
<p align="center">  <strong>Şekil 6:</strong> Web Api Kullanılan Katmanlı Mimari </p>
