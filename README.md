**Müşteri Memnuniyeti Tahmin API Projesi**
Bu proje, kullanıcı incelemelerini analiz ederek müşteri memnuniyetini tahmin etmeyi amaçlayan bir API'yi içerir. ML.NET kullanarak inceleme metinlerinden tahminler yapmak için eğitilmiş bir model kullanır.
**Proje Yapısı**
**CustomerSatisfaction.Core:** Projede kullanılan temel varlıklar ve modelleri içerir.
****CustomerSatisfaction.MLModels:** Makine öğrenmesi modeli ve ilgili yapılandırmaları içerir.
**CustomerSatisfaction.Services:** Veri yükleme ve müşteri memnuniyeti tahmini için servisleri içerir.
**CustomerSatisfaction.Repositories:** Veri erişimi ve depolamayı yönetir.
**CustomerSatisfactionApi:** API denetleyicilerini içeren ASP.NET Core Web API projesi.
**Başlangıç Gereksinimler**
- .NET 6.0 SDK
-  ML.NET
-  Visual Studio veya Visual Studio Code
**Kurulum**
**1. Depoyu klonlayın:**
git clone https://github.com/yourusername/CustomerSatisfactionApi.git
cd CustomerSatisfactionApi
**2. Gerekli bağımlılıkları yükleyin:**
dotnet restore
**3. Veri dosyasını yerleştirin:**
Reviews.csv dosyasını CustomerSatisfaction.Core\bin\Debug\net6.0\ dizinine yerleştirin.

**Veri Hazırlığı**
CSV dosyası aşağıdaki sütunlara sahip olmalıdır:

- Id
- ProductId
- UserId
- ProfileName
- HelpfulnessNumerator
- HelpfulnessDenominator
- Score
- Time
- Summary
- ReviewText

