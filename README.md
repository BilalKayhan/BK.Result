BK.Result NuGet Package

## Genel Bakış
C#'ta işlem sonuçlarını yönetmek için basit ve genel bir sonuç sınıfı. Bu sınıf, başarılı ve başarısız sonuçları, 
ilgili veriler, hata mesajları ve HTTP durum kodlarıyla birlikte kapsamak üzere tasarlanmıştır.

## Özellikler
- Genel Veri Türü Desteği**: Herhangi bir veri türünü (`T`) işleyebilir.
- Hata Yönetimi**: Birden fazla hata mesajını kolayca yönetir.
- HTTP Durum Kodları**: API yanıtları için uygun HTTP durum kodlarını döndürür.
- Başarı ve Başarısızlık Metotları**: Başarı veya başarısızlık sonuçları oluşturmak için statik metotlar,yerleşik 
  HTTP durum kodları ile birlikte.


## Kurulum
1. Depoyu klonlayın veya `Result<T>` sınıfını indirin.
2. `Result.cs` dosyasını C# projenize dahil edin.

## Kullanım
--Varsayılan olarak bu, 200 OK HTTP durum kodu ile döner. Farklı bir durum kodu da belirtebilirsiniz:
```csharp
var successResult = Result<string>.Success("İşlem başarıyla tamamlandı.", (int)HttpStatusCode.Created);
```

--Başarısızlık durumları için, tek bir hata mesajı ile Failure metodunu kullanabilirsiniz:
```csharp
var failureResult = Result<string>.Failure("Bir hata oluştu.");
```

--Ya da birden fazla hata mesajı ile:
```csharp
var failureResult = Result<string>.Failure(new List<string> { "Hata 1", "Hata 2" });
```

Ön Tanımlı Başarısızlık Metotları 404 bulunamadı
```csharp
var notFoundResult = Result<string>.NotFound("İstenen kaynak bulunamadı.");
```


Ön Tanımlı Başarısızlık Metotları 401 bulunamadı
```csharp
var unauthorizedResult = Result<string>.Unauthorized("Bu kaynağa erişmek için giriş yapmalısınız.");
```


Ön Tanımlı Başarısızlık Metotları 403 bulunamadı
```csharp
var forbiddenResult = Result<string>.Forbidden("Bu kaynağa erişim izniniz yok.");
```

Ön Tanımlı Başarısızlık Metotları 500 sunucu hatası
```csharp
var serverErrorResult = Result<string>.InternalServerError("Beklenmedik bir hata oluştu.");
```

Ön Tanımlı Başarısızlık Metotları 400 Kötü İstek
```csharp
var badRequestResult = Result<string>.BadRequest("İstek Geçersiz.");
```

Ön Tanımlı Başarısızlık Metotları 409 Çakışma
```csharp
var conflictResult = Result<string>.Conflict("İstekle ilgili bir çakışma var.");
```

## ÖRNEK

`Result<T>` sınıfını bir API kontrolcüsünde nasıl kullanabileceğinize dair bir örnek:

```csharp
[HttpGet("GetResource/{id}")]
public IActionResult GetResource(int id)
{
    var resource = _resourceService.GetById(id);

    if (resource == null)
    {
        return NotFound(Result<string>.NotFound("Kaynak bulunamadı."));
    }

    return Ok(Result<object>.Success(resource));
}
```

## Katkıda Bulunma
Katkılarınızı bekliyoruz! Lütfen projeyi forklayın ve bir pull request gönderin.

## Lisans
Bu proje MIT Lisansı altında lisanslanmıştır - detaylar için LICENSE dosyasına bakabilirsiniz.

