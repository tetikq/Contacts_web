# Contacs
Halilibrahim Tetik
-----

Databaseler'i aktif hale getirmek için;

package manager console'dan 

enable-migrations

add-migration "initialsetup"

add-migration "ShowSearchForm"

Update-Database

--------

Yapılanlar:

*Rehbere kişi ekleme/çıkarma ve düzenleme komutları

*Şehire göre kişileri filtreleme

*Belli konumdaki veriler için Filtrele sekmesini kullanabilirsiniz

-------

Teknik Yapı:

ASP.Net üzerinden MVC yapısıyla kurulduğı için sistem asenkron çalışıyor.

View modeller controllerla HTTP/api protokolüyle iletişim sağlıyor.

Controller'dan view modellere veriler yerel değişkenlerle aktarılıyor. 

Rehber ve Rapor için 2 Database tablosu oluşturuldu.

migration yapıları tamam.

-------
Eksiklikler:

uuid değişkeni rastgele üretiliyor, veri kontrolü yapılmadığı için hiç bir veri hücresi eşsiz değildir.

2 farklı view için iki controller eklendi, Tüm işlemler ContactData View model ve ContactDataController üzerinde yapıldı.

Raporlama eksik.

Api, ve query kontrol eksik.

İstediğiniz biçime gelmediği için unit testing code coverage testi yapılmadı.

-------

Saygılarımla, İyi Çalışmalar.
