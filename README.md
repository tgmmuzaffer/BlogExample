# BlogExample
BLOG UYGULAMASI

PROJE DÖKÜMANTASYONU

YUSUF MUZAFFER DEVECİ

MAYIS 2021

İÇİNDEKİLER

1. Projenin Amacı
2. Projenin Kapsamı
3. Kullanılan Geliştirme Araçları ve Ortamları
4. API Endpoitleri
5. Kurulum

PROJENİN AMACI

Projeninn amacı; restful api kullanarak CRUD işlemlerini gerçekleştirebilen web sitesi
olusturmak.

PROJENİN KAPSAMI

Standart olarak değerlendirebileceğimiz bir yazı içeriği ve yazıya ait kategorilerinde
bulunduğu bir web sitesidir.


KULLANILAN GELİŞTİRME ARAÇLARI VE ORTAMLARI

1.Dapper
2.Html
3.Css
4.C#
5.Mssql
6.VS 2019


API ENDPOİNTLERİ

Bu endpointler kullanılarak başka bir arayüze entegre edilip Blog ve Category entity
leri için CRUD işlemleri yapılabilir. Taban url: “https://localhost:44308/” .
Yazı oluşturmak : "api/blog/createblog"
Tüm yazıları listelemek: "api/blog/getbloglist"
Belirli bir yazıyı getirmek: "api/blog/getblogbyid?Id="
Belirli bir yazıyı silmek: "api/blog/deleteblog?Id="
Belirli bir yazıyı güncellemek: "api/blog/updateblog"
Kategori oluşturmak: "api/category/createcategory"
Tüm kategorileri listelemek: "api/category/getcategorybyid?Id="
Belirli bir kategori getirmek: "api/category/getcategorylist"
Belirli bir kategori silmek: "api/category/deletecategory?Id=";
Belirli bir kategori güncellemek: "api/category/updatecategory"

KURULUM

Kurulum için link den projeyi indirmelisiniz. İndirdikten sonra projeyi derlemenizde
fayda var. DataAccess>Context>ApplicationDbcontext içindeki veritabanı bağlantı bilgilerini
kendi bilgilerinizle değiştirmelisiniz. Migrationları DataAccess katmanında vardır Package
Manager Console üzerinden “Update-Database” komutunu girmeniz yeterlidir. İlk kayıtları
ister Postman ile ister veritabanı üzerinden yapabilirsiniz.
