# Dotnet Core ile API Projesi Oluşturma
.Net Core ve mimari yapı kullanılarak örnek bir api projesi geliştirilmesi amaçlanmıştır.

### Kullanılan Tasarım Desenleri
- Generic Repository (CRUD işlemlerinin yapıldığı yerdir. Tip bağımsız halde çalışır.)
- UnitOfWork (Tüm repositorilerin tek bir noktadan kontrol edilebilir olması ve database işlemlerindeki değişikliklerin kontrolü sağlanır.)
- Singleton (Genellikle veri tabanı bağlantılarını veya gerekli sınıfların üretilmesi konusunda tekillik sağlar. Sınıfın yalnızca bir örneğinin oluşmasını sağlamak için kullanılır.)

#### Kullanılan Teknoloji ve Frameworks
- .Net Core 2.2 web Api, Entity Framework Core, Newtonsoft.json (De/Serialization), .Net Core Dependency Injection
Yaklaşık 1 senedir .Net Core, EF Core ile projeler yapıldı. Loyalty uygulamaları, İç uygulamalar, e-commerce (nop-commerce) gibi projelerde geliştirmelerde kullandım. Örnek amaçlı bu proje github'a konmuştur.

#### Eklenecek Diğer Özellikler
- JWT Token, Logger (NLog veya Log4Net), Mapper (Auto mapper veya manuel olarak yapılacak)

Kısa bir sürede yaptığım için bu özellikleri ekleyemedim. Zamanla üstüne ekleyip tamamlayacağım. 
Ayrıca API işlemi bittikten sonra UI katmanını da hazırlayacağım. (Vue.js veya react.js düşünüyorum)
