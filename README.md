#ShopsRUsMicroserviceCancel changes

Program üç servisten oluşmaktadır.

ShopsRUs.IdentityServer MicroService - .net Core 5.0, EntityFramework, Mssql, DIP, AutoMapper, FluentValidations, GenericRepos, FluentApi <br />
ShopsRUs.Basket MicroService - .net Core 5.0, Redis,DIP <br />
ShopsRUs.Discount MicroService  - .net Core 5.0, PostreSQL, Dapper.Contrib ,DIP<br />

ShopsRUs.IdentityServer : Kullanıcı üyelik ve diğer kullanıcı operasyonları için görevli servis <br />
ShopsRUs.Basket :  Kullanıcı sepete ürün eklemek için istek yaptığında ürünü sepete eklemeden DiscountMicroServisine istek atar ve üyelik durumuna göre gerekli indirim ve hesaplamalar yapılarak dönüş alınır ve indirimli tutarla memorye sepeti kayıt eder<br />
ShopsRUs.Discount :  Basketten gelen indirim isteğine gerekli hesaplalamarı yaparak geri dönüş yapar. <br />

Servislerin Çalışacağı Portlar <br />
"ShopsRUs.IdentityServer"	   : "http://localhost:5010" <br />
"ShopsRUs.Basket" : "http://localhost:5015" <br />
"ShopsRUs.Discount"  : "http://localhost:5014" <br />

Port Ayarları Proje İçerisind Solution Items>Shared>portes.txt altındadır.

Diğer Detaylar;
Bir UI yazmayı planlamıştım identity microservisini bu yüzden kaldırmıştım ama yoğunluk sebebi ile sürece devam edemiyorum. Mevcut yapıda yapılan discountu kayıt işlemi ödeme sonrası kayıt edilebilir ama çeşitlilik ve sistemin çalışır durumunun görüntülenebilmesi için yapılan indirimler de kayıt altına alınıyor.

https://localhost:5015/api/Baskets linkine aşağıdaki yapı ile post isteği atabilirsiniz. size indirim microservisi ile iletişime geçip sonucu döndürecektir.(user oluşturmanıza gerek yok random bir id ile istek atabilirsiniz.)<br />


![jsondata](https://user-images.githubusercontent.com/63802797/163184148-44c23fa2-5b9f-46c7-b62b-bd9476dff518.png)<br />

json dataya txt dosyasını indirerek ulaşabilirsiniz. [jsondata.txt](https://github.com/CoskunGulcicek/ShopsRUs/files/8481556/jsondata.txt) <br />

