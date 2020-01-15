# Dotnet Core ile API Projesi Oluşturma
.Net Core ve mimari yapı kullanılarak örnek bir api projesi geliştirilmesi amaçlanmıştır.
Sql scripti eklenmiştir. Örnek 4-5 tane data vardır.

Örnek Sorgu: Post oluşturmak için
URL: {your localhost}/api/post/new-post
Body:
```json
{
	"Title":"Merhaba Satürn",
	"Description":"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
	"UserId":3,
	"CategoryId":1
}
```


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
