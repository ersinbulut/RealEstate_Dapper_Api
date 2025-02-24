Proje Genel Bakış
------------------------
"RealEstate_Dapper_Api" projesi, modern ve performans odaklı bir emlakçı sitesi geliştirmeyi amaçlayan kapsamlı bir web uygulamasıdır. Bu projede kullanıcılar, istedikleri lokasyona göre uygun daireleri listeleyerek kiralama veya satın alma işlemleri için detaylı bilgi edinebilirler. Proje, hem backend hem de frontend bileşenlerini içeren modüler bir yapı sunarak esnek, genişletilebilir ve kullanıcı dostu bir deneyim sağlar.

Kullanılan Teknolojiler
------------------------
Backend
------------------------
ASP.NET Core & C#: Sunucu tarafı geliştirmeleri için güçlü ve modern ASP.NET Core framework’ü, C# diliyle hayata geçirilmiştir.
Dapper: Veritabanı işlemlerinde yüksek performans ve düşük kaynak tüketimi sağlamak amacıyla mikro ORM olarak Dapper kullanılmıştır. Bu sayede SQL sorguları doğrudan yazılarak hızlı veri erişimi mümkün hale gelir.
RESTful API: CRUD (Create, Read, Update, Delete) işlemleri için RESTful mimari prensipleri benimsenmiş, esnek ve farklı istemci uygulamalarla entegrasyonu kolaylaştırılmıştır.
Veritabanı: Genellikle MSSQL gibi ilişkisel veritabanları tercih edilerek, emlak ilanlarının ve kullanıcı verilerinin güvenli ve tutarlı bir şekilde yönetimi sağlanır.
Frontend
------------------------
HTML, CSS, JavaScript, SCSS: Kullanıcı arayüzü, modern web standartlarına uygun olarak HTML, CSS, JavaScript ve SCSS teknolojileri kullanılarak geliştirilmiştir.
Responsive Tasarım: Farklı ekran boyutlarına uyumlu, mobil ve masaüstü cihazlarda optimum kullanıcı deneyimi sunan, duyarlı (responsive) tasarım prensipleri uygulanmıştır.
Öne Çıkan Özellikler

Hızlı ve Verimli Veri İşlemleri: Dapper ile gerçekleştirilen veritabanı sorguları sayesinde, uygulama yüksek performans ve düşük gecikme süresiyle çalışır.
Kullanıcı Dostu Arayüz: Temiz, modern ve responsive tasarım sayesinde, kullanıcılar aradıkları emlak ilanlarına hızlı ve kolay erişim sağlayabilir.
Esnek RESTful API: API yapısı, farklı platformlardan (web, mobil vb.) erişime uygun olarak tasarlanmış olup, entegrasyon ve ölçeklenebilirlik açısından avantaj sağlar.
Modüler Mimari: Backend ve frontend’in ayrı projeler olarak ele alınması, kodun okunabilirliğini ve bakımını kolaylaştırırken, yeni özelliklerin eklenmesine de imkan tanır.
Lokasyon ve Kategori Bazlı Filtreleme: Kullanıcılar, ilanın lokasyonu, fiyat aralığı ve mülk tipine göre filtreleme yaparak aradıkları kriterlere uygun ilanlara ulaşabilir.
Teknik Özellikler
------------------------
Performans Odaklı: Dapper kullanımı sayesinde, veritabanı sorgularında maksimum verimlilik ve düşük kaynak tüketimi hedeflenmiştir.
Katmanlı Mimari: Controller, servis ve repository gibi katmanlara ayrılmış yapı, kodun modüler ve sürdürülebilir olmasını sağlar.
Güvenlik: API endpoint’leri üzerinde gerekli güvenlik önlemleri alınmış, kullanıcı verilerinin korunması için modern güvenlik standartları uygulanmıştır.
Kolay Genişletilebilirlik: Proje, yeni özelliklerin eklenmesine uygun esnek bir yapı sunar. Dependency Injection ve Repository Pattern gibi modern yazılım geliştirme teknikleri kullanılarak kod kalitesi artırılmıştır.
Proje Yapısı
------------------------
RealEstate_Dapper_Api:
Backend tarafını oluşturur. API endpoint’leri, veritabanı işlemleri ve iş mantığının yönetimi bu katmanda yer alır. Dapper’ın performans avantajlarından yararlanılarak, CRUD işlemleri ve hızlı veri erişimi sağlanır.

RealEstate_Dapper_UI:
Frontend kısmını temsil eder. HTML, CSS, JavaScript ve SCSS ile geliştirilmiş olan kullanıcı arayüzü, ziyaretçilere modern ve etkileşimli bir deneyim sunar.

Bu proje, emlak sektöründe kullanılabilecek gerçek dünya senaryolarına yönelik, performans, güvenlik ve kullanıcı deneyimini ön planda tutan bir çözüm sunar. Hem geliştiriciler hem de kullanıcılar için ölçeklenebilir ve sürdürülebilir bir yapı oluşturmayı hedefleyen proje, modern teknolojiler ve en iyi yazılım geliştirme teknikleri kullanılarak hayata geçirilmiştir.

![image](https://github.com/user-attachments/assets/9ba69aaa-1c00-4408-b8ed-4889382fcf61)
![image](https://github.com/user-attachments/assets/2199eb10-be12-4dbf-8f12-69cb455cfe0a)
![image](https://github.com/user-attachments/assets/e673eabb-df54-48da-9dab-d18dd20b8317)
![image](https://github.com/user-attachments/assets/bd9751e4-0a6d-4221-9168-3cc6c0cc794a)



