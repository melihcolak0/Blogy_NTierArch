# 💎 ASP.NET Core 9.0 ile Blog Platformu
Bu repository, M&Y Yazılım Akademi bünyesinde yaptığım dördüncü proje olan ASP.NET Core 9.0 ile Blogy Platformu projesini içermektedir. Bu eğitimde bana yol gösteren Murat Yücedağ'a çok teşekkür ederim.

Bu proje, ASP.NET Core 9.0 (MVC) teknolojisi kullanılarak geliştirilmiş, yazarların içerik üretebildiği ve kullanıcıların bu içeriklere yorum yapabildiği kapsamlı bir çok katmanlı (N-Tier) blog yönetim sistemidir. Projede, yazılım mimarisinde sürdürülebilirliği ve test edilebilirliği artırmak amacıyla katmanlı mimari, Repository Design Pattern ve Dependency Injection gibi modern yazılım geliştirme prensipleri uygulanmıştır. Veritabanı işlemleri için Entity Framework Core tercih edilmiş olup, kullanıcı kimlik doğrulama ve yetkilendirme süreçleri ASP.NET Identity ile entegre edilmiştir.

Bu projede N-Tier Architecture (N Katmanlı Mimari) ve MVC tabanlı bir yapı kullandım. SOLID prensiplerine ve dosya organizasyonuna uygun şekilde geliştirme yaparak kod tekrarını en aza indirmeye çalıştım. Entity Framework Core - Code First yaklaşımını kullanarak veritabanı bağlantılarını oluşturdum.
N-Tier Architecture (N Katmanlı Mimari), yazılım uygulamalarını birden fazla bağımsız katmana (layer) bölerek geliştirmeye olanak tanıyan bir yazılım mimari modelidir. Bu mimari, uygulamanın farklı katmanlarını belirleyerek modülerlik, ölçeklenebilirlik ve bakım kolaylığı sağlar.
Genel anlamda 4 katman üzerinde projeyi oluşturdum. Presentation Layer (Sunum Katmanı), kullanıcının doğrudan etkileşimde bulunduğu katmandır. Burada HTML5, CSS3, Bootstrap ve JavaScript kullanarak web sayfaları oluşturdum. Business Logic Layer (İş Mantığı Katmanı), uygulamanın kurallarını ve iş mantığını barındırır. Service ve Manager olarak tüm entity'lerin metotlarını oluşturup kontrollerini yaptım. Data Access Layer (Veri Erişim Katmanı), veri tabanı ile etkileşimi sağlar. Burada veri tabanındaki verileri gereken şekilde kullandım. Entity Layer (Varlık Katmanı), verileri saklayan katmandır. Burası Code-First yaklaşımının başlangıcıdır. Veri tabanındaki tablolar ve sütunlar yerine bu katmanda sınıflar ve property'ler kullandım. Kullanıcı'ların yönetimini Identity ile yaptım. ASP.NET Core Identity, kimlik doğrulama (authentication) ve yetkilendirme (authorization) işlemlerini yönetmek için kullanılan bir sistemdir.

Yorum altyapısında ise kullanıcı deneyimini artırmak ve içerik kalitesini kontrol altında tutmak adına Hugging Face platformu üzerinden sunulan BERT tabanlı toxicity detection modeli entegre edilmiştir. Bu sayede sistem, yorumların toksik olup olmadığını otomatik olarak analiz etmekte ve toksik içerikler doğrudan yayına alınmayarak yöneticilerin denetimine bırakılmaktadır. Böylece platform, güvenli ve sağlıklı bir iletişim ortamı sunmayı hedeflemektedir.

Frontend tarafında Bootstrap, jQuery, AJAX gibi teknolojilerle zenginleştirilmiş etkileşimli bir kullanıcı arayüzü oluşturulmuştur. Kullanıcıların yorum yapma, makale inceleme gibi işlemleri minimum sayfa yenilemesiyle hızlı şekilde gerçekleşmektedir. Proje; yönetici paneli, yazar profili, makale oluşturma/güncelleme, kategori yönetimi ve kullanıcı yorum yönetimi gibi birçok özelliği modüler ve genişletilebilir bir yapıda sunmaktadır.

### Hugging Face Nedir?
Hugging Face, özellikle doğal dil işleme (NLP) alanında kullanılan açık kaynaklı yapay zeka modelleri sağlayan bir platformdur.<br>
- En bilinen ürünü: Transformers kütüphanesi — binlerce hazır eğitimli modeli birkaç satır kodla kullanmanı sağlar.<br>
- Kullanım alanları: metin sınıflandırma, çeviri, özetleme, duygu analizi, soru-cevap sistemleri, toksik içerik tespiti gibi birçok NLP uygulaması.<br>
- Hugging Face API üzerinden, hazır modelleri REST API çağrısıyla doğrudan projene entegre edebilirsin.<br>
- En popüler modelleri: BERT, GPT, RoBERTa, DistilBERT, T5, BART vb.<br><br>
📌 Hugging Face = Yapay zeka modellerinin GitHub'ı gibi düşünebilirsin.<br>

###  BERT Nedir?
BERT (Bidirectional Encoder Representations from Transformers), Google tarafından geliştirilmiş transformer tabanlı bir dil modelidir. Özellikleri:<br>
Cümleleri bağlama göre iki yönlü (bidirectional) olarak işler.<br>
Yani bir kelimeyi hem öncesine hem sonrasına bakarak anlar.<br>
Bu, geleneksel tek yönlü modellerden çok daha doğru sonuçlar üretmesini sağlar.<br>

BERT Ne İşe Yarar?<br>
- Cümle sınıflandırma (örneğin yorum olumlu mu, toksik mi?)<br>
- Soru-cevap sistemleri<br>
- Metin tamamlama<br>
- Duygu analizi<br>
- Anahtar kelime çıkarımı<br><br>
🎯 Hugging Face üzerinde “unitary/toxic-bert” gibi modeller, BERT mimarisi üzerine kurulmuştur ve toksik içerikleri tespit etmek için eğitilmişlerdir.<br>

### Projedeki Kullanım
Bu platformda siteye giriş yapan herkes yazılmış makaleleri yazarlara ve kategorilere özel filtreleyerek görüntüleyebilir. Yorum yapma bölümünde kullanıcının platforma üye olması beklenir ve böylece yazar paneline giriş yapmış olur. Buradan kendi bir makale oluşturabilir, kendi makalelerini ve yorumlarını görebilir ve çeşitli istatistiki bilgiler elde edebilir. Kullanıcının üye olması bir makaleye yorum yapabilmesi anlamına da gelir. Yorum yapılırken Hugging Face BERT kullanılarak yorumun toksiklik seviyesi belirlenir ve buna göre verilen notla yorum ya yayınlanır ya da onaylanmak üzere yazar panelinde bekler. 

### Kullandığım Teknolojiler <br>
⚙️ ASP.NET Core MVC<br>
🗂️ N-Tier Architecture<br>
🧠 Hugging Face Transformers (Toxic-BERT ile yorum analizi)<br>
🗃️ Entity Framework Core<br>
🔐 ASP.NET Identity<br>
🧱 Repository Design Pattern<br>
💬 AJAX & jQuery<br>
🗄️ MS SQL Server<br>
📦 Dependency Injection<br>
🎨 HTML5, CSS3, Bootstrap 5 ve JavaScript <br>

## :arrow_forward: Projeden Ekran Görüntüleri

### :triangular_flag_on_post: Ana Sayfa
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/localhost_7056_Default_Index.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/localhost_7056_Default_Authors.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/localhost_7056_Default_Categories.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/localhost_7056_Default_ArticlesByAuthor_5cab3c14-5e69-4874-909b-6e39060d7a6b.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/localhost_7056_Default_ArticlesByCategory_1.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/localhost_7056_Article_ArticleDetail_fffff.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-16%20162917.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-16%20162937.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-16%20202450.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202025-07-16%20202508.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Yazar Paneli
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/localhost_7056_Author_Dashboard%20(1).png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/localhost_7056_Author_Dashboard%20(3).png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/localhost_7056_Author_GetProfile.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/localhost_7056_Author_MyArticleList.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/localhost_7056_Author_CreateArticle.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/localhost_7056_Author_MyCommentsList.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/localhost_7056_Author_MyCommentsList.png" alt="image alt">
</div>

### :triangular_flag_on_post: Diğer Sayfalar
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/localhost_7056_LogIn_LogIn.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/Blogy_NTierArch/blob/cc24d8cb0ed94a7721aa53eeed5baaec97f5f057/ss/localhost_7056_register_index.png" alt="image alt">
</div>


