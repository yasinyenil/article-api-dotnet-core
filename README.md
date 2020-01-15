# Dotnet Core ile API Projesi Oluşturma
.Net Core ve mimari yapı kullanılarak örnek bir api projesi geliştirilmesi amaçlanmıştır.

### Kullanılan Tasarım Desenleri
- Generic Repository (CRUD işlemlerinin yapıldığı yerdir. Tip bağımsız halde çalışır.)
- UnitOfWork (Tüm repositorilerin tek bir noktadan kontrol edilebilir olması ve database işlemlerindeki değişikliklerin kontrolü sağlanır.)
- Singleton (Genellikle Veri tabanı bağlantılarını kontrol etmemizi sağlar. Sınıfın yalnızca bir örneğinin oluşmasını sağlamak için kullanıldı.)

#### Kullanılan Teknoloji ve Frameworks
- .Net Core 2.2 web Api, Entity Framework Core, Newtonsoft.json (De/Serialization)
Yaklaşık 1 senedir .Net Core, EF Core ile projeler yapıldı. Örnek amaçlı bu proje github'a konmuştur. 
Loyalty uygulamaları, İç uygulamalar, e-commerce (nop-commerce) gibi projelerde geliştirmelerde kullandım.

#### Eklenecek Diğer Özellikler
- JWT Token, Logger (NLog veya Log4Net), Mapper (Auto mapper veya manuel olarak yapılacak)

Kısa bir sürede yaptığım için bu özellikleri ekleyemedim. Zamanla üstüne ekleyip tamamlayacağım. 
Ayrıca API işlemi bittikten sonra UI katmanını da hazırlayacağım. (Vue.js veya react.js düşünüyorum)
