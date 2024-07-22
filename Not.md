# Mikroservis Organizasyon Modelleri

Mikroservis mimarisi, bağımsız olarak geliştirilip dağıtılabilen küçük hizmetlerden oluşur. İşte mikroservis organizasyon modellerinin başlıca türleri:

## 1. Teknoloji Odaklı Model

**Açıklama:**
Mikroservisler, kullanılan teknolojiye göre gruplandırılır (örneğin, .NET, Java, Node.js).

**Avantajlar:**
- Teknolojik uzmanlık derinliği sağlanır.
- Geliştirme ve bakım süreçleri daha verimli olabilir.

**Dezavantajlar:**
- İş süreçlerine göre entegrasyon zor olabilir.
- Ekipler arası bağımlılıklar artabilir.

## 2. İş Odaklı Model

**Açıklama:**
Mikroservisler, iş fonksiyonlarına göre gruplandırılır (örneğin, sipariş yönetimi, müşteri hizmetleri).

**Avantajlar:**
- İş süreçlerine daha iyi hizalanma sağlar.
- İş birimleri, süreçlerine hızlıca adapte olabilir.

**Dezavantajlar:**
- Teknolojik tutarlılık zorlaşabilir.
- Farklı iş birimleri arasında bilgi paylaşımı zor olabilir.

## 3. Veri Odaklı Model

**Açıklama:**
Mikroservisler, veri türlerine veya veri kaynaklarına göre gruplandırılır (örneğin, kullanıcı verileri, sipariş verileri).

**Avantajlar:**
- Veri yönetimi ve bütünlüğü kolaylaşır.
- Veri odaklı optimizasyonlar yapılabilir.

**Dezavantajlar:**
- İş süreçleri ve teknolojiler arasındaki entegrasyon zorlaşabilir.
- Veri ekipleri arasındaki iş birliği zor olabilir.

## 4. Karışık Model

**Açıklama:**
Farklı modellerin kombinasyonunu içerir, mikroservisler hem teknoloji, hem iş fonksiyonu hem de veri türüne göre organize edilir.

**Avantajlar:**
- Hem teknolojik hem de iş odaklı uyum sağlanabilir.
- Esnek ve dinamik bir yapı oluşturulabilir.

**Dezavantajlar:**
- Yönetim ve koordinasyon daha karmaşık hale gelebilir.
- İyi bir planlama ve iletişim gerektirir.

# Mikroservis'ler de Servisler Arası İletişim Nasıl Gerçekleştirilir?

## 1. HTTP Tabanlı API'lar

Servisler, HTTP protokolü üzerinden RESTful API'lar kullanarak senkron iletişim kurar. Yaygın ve standart bir yöntemdir. Genellikle senkron senaryolarda kullanılır.

## 2. Message Broker

Servisler, mesaj kuyrukları (örneğin, RabbitMQ, Kafka) aracılığıyla asenkron olarak iletişim kurar. Yüksek performans ve güvenli mesaj işleme sağlar.

## 3. RPC (Remote Procedure Call)

Bir servis, uzak bir sunucudaki başka bir servisin metodunu çağırır. Performanslı ve düşük gecikmeli iletişim sunar.

## 4. API Gateway

API Gateway, mikroservisler arasındaki iletişimi yöneten merkezi bir giriş noktasıdır. Merkezi yönetim ve güvenlik sağlar.

# Mikroservis'ler de Servisler Arası Veri İletişiminde API Gateway'in Görevi Nedir?

### Merkezi Yönetim ve Kontrol:
API Gateway, tüm gelen istekleri tek bir merkezi noktada toplar ve yönlendirir. Bu, mikroservislerin doğrudan dış dünya ile iletişimini azaltarak sistemde merkezi bir nokta sağlar.

### Güvenlik ve Yetkilendirme:
API Gateway, gelen istekler üzerinde güvenlik politikalarını uygular ve yetkilendirme kontrollerini gerçekleştirir. Bu şekilde, mikroservislerin güvenliği sağlanır ve dış tehditlere karşı korunurlar.

### İstek Yönlendirme ve Yük Dengeleme:
Gelen istekleri, hedef mikroservise yönlendirir ve bu yönlendirmeyi sağlayarak yük dengesini optimize eder. Aynı zamanda, yüksek trafik durumlarında performansı artırmak için yük dengeleme stratejilerini uygular.

### Protokol Dönüşümü ve Adaptasyon:
Farklı servislerin farklı iletişim protokollerini (örneğin, HTTP, gRPC) desteklemesi durumunda, API Gateway bu protokoller arasında dönüşüm yapar ve uygun hale getirir.

### İzleme ve Analiz:
API Gateway, gelen ve giden trafiği izler, günlükler ve analiz eder. Bu sayede, sistemdeki performansı ölçer, hata ayıklama yapar ve iyileştirme için veri sağlar.

### API Versiyonlama ve Yönetim:
API Gateway, farklı API sürümlerini yönetir ve istemcilere sağlayacağı API sürümünü belirler. Bu, geriye dönük uyumluluğu sağlar ve API değişikliklerinin etkilerini yönetir.

API Gateway'in bu görevleri, mikroservislerin dağıtık yapısını merkezi bir kontrol noktası ile destekler ve yönetimini kolaylaştırır. Bu sayede, güvenlikten performansa kadar birçok operasyonel ihtiyacı etkin bir şekilde karşılar.

# Bir Mikroservis Mimarisinin Tasarımı Nasıl Gerçekleştirilir?

- **Gereksinimleri Anlama:** Mikroservis mimarisi için gereksinimleri, işlevsel ve teknik detayları anlayarak belirleme sürecidir.
- **Mikroservisleri Belirleme:** Uygulamanın parçalara ayrılması ve her bir parçanın bir mikroservis olarak tanımlanması sürecidir.
- **İletişim Protokollerinin Belirlenmesi:** Servisler arası iletişim için kullanılacak protokollerin (HTTP, gRPC vb.) belirlenmesi ve standardizasyonu.
- **Veritabanı Stratejisi:** Her mikroservis için uygun veritabanı teknolojisinin seçilmesi ve veri yönetim stratejilerinin oluşturulması sürecidir.
- **Güvenlik Tasarımı:** Mikroservisler arası iletişimin güvenliğini sağlamak için kullanılacak tekniklerin ve güvenlik politikalarının belirlenmesi.
- **Hata Yönetimi ve İzleme:** Hataların tanımlanması, izlenmesi ve uygun hata yönetim stratejilerinin geliştirilmesi sürecidir.
- **Ölçeklenebilirlik ve Yedekleme:** Servislerin ölçeklendirme gereksinimleri ve yüksek kullanılabilirlik için yedekleme stratejilerinin belirlenmesi.
- **Test ve Sürüm Yönetimi:** Mikroservislerin ayrı ayrı ve birlikte test edilmesi, sürüm kontrolü ve sürüm geçişlerinin yönetilmesi sürecidir.
- **Dökümantasyon:** Mikroservislerin kullanımı, API'leri ve sistem mimarisinin belgelendirilmesi sürecidir, bu da geliştirici ve kullanıcılar için referans sağlar.

# Mikroservis Mimarisinde Bir Servisin Sınırları Nasıl Belirlenir?

- **Tek Sorumluluk Prensibi:** Bir mikroservis, yalnızca belirli bir işlevi yerine getirmeli ve bu işlevi etkin bir şekilde gerçekleştirmelidir.
- **Dış Dünya Etkileşimi:** Mikroservis, dış dünya ile sınırlı ve belirli API'ler aracılığıyla iletişim kurmalıdır, böylece işlevselliği korunur ve güvenlik sağlanır.
- **Ekip ve Organizasyon Yapısı:** Mikroservis, geliştirici ekiplerinin yetkinliklerine ve organizasyonel yapıya uygun olarak sınırları belirlenir, böylece geliştirme süreçleri koordineli bir şekilde ilerler.
- **Bağımlılıklar ve Sınırlar:** Servisin dış bağımlılıkları ve sınırları, diğer mikroservislerle ve dış sistemlerle olan etkileşimleri kapsar, bu şekilde hata yayılması önlenir ve bağımlılıklar yönetilir.
- **Veri Yapısı ve Sınırları:** Mikroservis, belirli veri yapısı ve boyutları ile sınırlı olmalıdır, böylece performansı optimize edilir ve veri entegrasyonu yönetilir.

# Mikroservisler Kendi Aralarında Senkronizasyonu Nasıl Sağlarlar?

- **Saga Pattern**
- **Outbox Pattern**
- **Inbox Pattern**
- **2PC Two-Phase Commit Pattern**

# Kısa Bilgiler

- Bir mesaj yayınlanırken ya da yayınlandıktan sonra kaybolma ihtimaline sahiptir işte bu tarz durumlara karşın Outbox Design Pattern'i uygulayarak çözüm getirmeye çalışacağız.
- Kuyruktan elde edilen mesajlar işlenirken olası hatalar yüzünden bu işlemler yarıda kesilebilmektedir. Haliyle bu tarz durumlardan dolayı bir mesajın işlenip işlenmediği gibi durumları kesinleştirmek gerekmektedir. Bunun içinde Inbox Pattern'dan faydalanılıyor olacağız.
- Bazen bir servisteki sonuca göre, diğer servislerde yapılan işlemlerin geri alınması gerekebilmektedir. Aksi taktirde servisler arası verisel tutarsızlık meydana gelecektir. İşte servisler arası veri tutarlılığı problemine karşın çözüm getirebilmek için Compensable Transaction davranış

# Uygulama İzleme (Application Monitoring) Nedir? Neden Önemlidir?

Uygulama izleme, hangi mimaride temellendirilmiş olursa olsun bir yazılım uygulamasının çalışma durumunu, performansını ve kullanım sürecindeki ya da sonraki potansiyel sorunları sürekli olarak takip etmeyi içerir. Bu takip sayesinde, uygulamanın sağlığını değerlendirmek, performans sorunlarını tespit etmek ve kullanıcı deneyimini kesintiye uğratmaksızın hızlı aksiyonlar almak için kritik bir rol oynar. Uygulama izlemenin önemini aşağıdaki nedenlerle net bir şekilde izah edebiliriz:

- **Performans Sorunlarını Tespit Etme:** Uygulamanın performansını izleyerek darboğazları ve yavaşlamaları belirleyebilirsiniz.
- **Sorunları Önceden Belirleme:** Potansiyel problemleri proaktif olarak tespit edip önlem alabilirsiniz.
- **Kullanıcı Deneyimini Geliştirme:** Kullanıcıların uygulamayı sorunsuz ve hızlı bir şekilde kullanmasını sağlarsınız.
- **Hızlı Tepki ve Çözüm:** Oluşan sorunlara anında müdahale ederek kesintileri minimuma indirirsiniz.
- **Verimli Ölçeklendirme:** Uygulamanın kullanım eğilimlerini izleyerek doğru kaynak planlaması yapabilirsiniz.
- **Veri Odaklı Kararlar:** İzleme verilerini kullanarak bilinçli ve stratejik kararlar alabilirsiniz.
- **Güvenlik ve Hata İzleme:** Güvenlik açıklarını ve hataları hızlıca tespit ederek güvenliği sağlarsınız.

## Mikroservisler'de İzleme ve Loglama Nasıl ve Hangi Yöntem/Yaklaşımlarla Yapılmalıdır?

Mikroservis mimarisinde izleme ve loglama, sistemin sağlığını ve performansını takip etmek için kritik öneme sahiptir. Bu sayede sorunları hızlıca tespit edebilir ve kullanıcı deneyimini kesintiye uğratmadan müdahale edebilirsiniz.

### Monitoring
- **Metrikler (Metrics):** Uygulamanın performansını ve kullanım istatistiklerini izlemek için belirli ölçümleri toplar.
- **Uyarılar (Alerts):** Önceden tanımlanmış metriklerin belirli eşikleri aştığında bildirim gönderir.
- **Gözlemlemek (Observability):** Sistemin genel sağlığını ve davranışlarını anlamak için çeşitli veri kaynaklarını kullanarak izleme sağlar.

### Loglama
- **Yapılandırılmış Loglar (Structured Logging):** Logların belirli bir formatta düzenlenmesi, analiz ve arama işlemlerini kolaylaştırır.
- **Merkezi Günlük Toplama (Centralized Log Collection):** Farklı mikroservislerden gelen logların tek bir yerde toplanması, yönetimi ve analizi kolaylaştırır.
- **İzlenebilirlik (Traceability):** Servisler arasındaki isteklerin izlenmesini sağlar, böylece bir işlemin hangi aşamalardan geçtiği takip edilebilir.

### Mikroservisler'de Distributed Tracing'nin Önemi

Distributed tracing, bir loglama yöntemi değildir. Mikroservis mimarisinde, bir istemci tarafından yapılan isteğin farklı servisler ve bileşenlerde işlenme sürecini izlememizi sağlar. Bu kritik davranış sayesinde, büyük ve karmaşık sistemlerde isteklerin izlenmesini sağlayarak uygulamanın takip edilebilirliğini artırır ve süreçleri daha da atomik hale getiririz.

Distributed tracing, bir isteğin farklı servisler veya bileşenler arasındaki hareketini izleme ve kaydetme sürecidir. Bu izleme, büyük sistemlerde isteklerin hangi aşamalardan geçtiğini anlamamıza ve performans sorunlarını tespit etmemize yardımcı olur. Ancak, her servis bu izleme sürecinin dışında kendi loglama işlemlerini de gerçekleştirir.

### Bilgilendirme
Tüm bunların dışında, monitoring ve loglama ile elde edilen metrikler Prometheus, Grafana, ELK gibi araçlarla görselleştirilebilir. Bu sayede loglama süreçlerini kolaylaştırabilir, sorunları rahatlıkla tespit edebilir ve gerekli performans optimizasyonlarını gerçekleştirebilirsiniz.


# Mikroservislerin Güvenliği

## Kimlik Doğrulama ve Yetkilendirme
Mikroservislere erişim sağlayan kullanıcıların kimlik doğrulaması sağlanmalı, bunun için de kullanıcı bilgileri güvende tutulmalı ve sadece gerekli yetkilere sahip olanlar erişim elde etmelidir.

### Kimlik Doğrulama Yöntemleri
- **JWT Tabanlı:** Kullanıcı giriş yaptığında bir merkezi kimlik sağlayıcısı (identity provider) tarafından, içerisinde kullanıcının kimliği ve yetkilendirmesi hakkında bilgileri içeren bir JWT değeri üretilir ve bu değer kullanıcı tarafından elde edilir. Kullanıcı bu JWT değeri ile mikroservislere isteklerde bulunur ve servisler tarafından da token doğrulanarak, yetkisi doğrultusunda işlemler gerçekleştirebilir.

- **OAuth 2.0:** Mikroservis mimarisi çalışmalarında genellikle bu protokol kullanılır. Uygulamaların kaynak sahiplerinin verilerine güvenli bir erişim yapmasını sağlayan bir yetkilendirme protokolüdür. Tüm kimlik doğrulama ve yetkilendirme sorumluluğunu bir yetkilendirme sunucusu (Authorization Server) üstlenmektedir.

- **OpenID Connect:** OpenID Connect, OAuth 2.0 üzerine inşa edilmiş bir kimlik doğrulama protokolüdür. Kimlik sağlayıcısı tarafından kullanıcının kimlik bilgilerini doğrulamak için kullanılır ve kimlik doğrulama işlemi sonrasında bir ID token üretilir.

### Yetkilendirme Yöntemleri
- **Rol ve İzin Tabanlı Yetkilendirme:** Kullanıcıların rolleri ve bu rollere bağlı izinler doğrultusunda yetkilendirme sağlanır.
- **Merkeziyetçi Yetkilendirme Sunucusu (Authorization Server):** Tüm yetkilendirme işlemlerini merkezi bir sunucu üzerinden gerçekleştirir.
- **Mikroservis Düzeyindeki Yetkilendirme:** Her mikroservis kendi yetkilendirme mekanizmasını yönetir.
- **Çok Faktörlü Kimlik Doğrulama:** Ek bir güvenlik katmanı olarak kullanıcıların kimlik doğrulamasında birden fazla doğrulama yöntemi kullanılır.

## Veri Güvenliği
Mikroservisler arasında iletilen verilerin şifrelenmesi gerekmektedir. HTTPS gibi güvenli iletişim protokolleri kullanarak veri akışını şifreleyebilirsiniz. Message Broker gibi haberleşmelerde mesajları şifreleyerek güvenliği sağlayabilirsiniz.

## API Güvenliği
Mikroservislerin dış dünyayla iletişim kurduğu nokta API'lardır. API'ların güvenliği için JWT tabanlı doğrulama gibi yöntemler kullanılabilir.

## Ağ Güvenliği 
Mikroservisler arasındaki iletişim ağı da güvence altına alınmalı; sanal ağlar, güvenlik duvarları, ağ segmentasyonu gibi yöntemlerle siber saldırılara karşı koruma sağlanmalıdır.

## İzlenebilirlik ve Loglama
Mikroservislerde güvenliğin esas unsurlarından biri izlenebilirlik ve süreçteki problemlere dair anında veri toplamamızı sağlayacak olan log mekanizmasıdır. Bu yapı sayesinde anormal aktiviteler anında tespit edilebilir.

# Veri Senkronizasyonu Stratejileri

## Veri Senkronizasyonu Nedir? Neden Önemlidir?
Mikroservis mimarisinde uygulama farklı parçalara yani mikro servislere bölünmüş olduğundan bu servisler arasında veri senkronizasyonu kritik bir öneme sahiptir. Her servis, best practice olarak kendi veritabanına sahip olacağından servisler arasında bir verinin bütünsel olarak tutarlılık göstermesi gerekmektedir.

## API Çağrıları
Mikroservisler arasında veri senkronizasyonunu desteklemek için API çağrılarından istifade edeilirsiniz. Böylece bir servisten hedefteki farklı bir servisi API aracılığıyla tetikleyebilir ve veri tutarlılığını nokta atış sağlayabilirsiniz.