namespace BK.Result;

using System.Collections.Generic;
using System.Net;
using System.Text.Json.Serialization;

public class Result<T>
{
    // Döndürülecek veriyi tutar. Nullable olarak ayarlanmıştır.
    public T? Data { get; set; }

    // Hata mesajlarını tutar. Nullable olarak ayarlanmıştır.
    public List<string>? ErrorMessages { get; set; } = new List<string>();

    // İşlemin başarılı olup olmadığını belirler. Varsayılan olarak true.
    public bool IsSuccessful { get; set; } = true;

    // HTTP durum kodunu tutar. JSON  göz ardı edilir.
    [JsonIgnore]
    public int StatusCode { get; set; } = (int)HttpStatusCode.OK;

    // Başarılı bir sonuç döndürmek için statik bir metot.
    public static Result<T> Success(T data, int statusCode = (int)HttpStatusCode.OK)
    {
        return new Result<T>
        {
            Data = data,
            IsSuccessful = true,
            StatusCode = statusCode
        };
    }

    // Başarısız bir sonuç döndürmek için statik bir metot.
    public static Result<T> Failure(List<string> errorMessages, int statusCode = (int)HttpStatusCode.BadRequest)
    {
        return new Result<T>
        {
            ErrorMessages = errorMessages,
            IsSuccessful = false,
            StatusCode = statusCode
        };
    }

    // Tek hata mesajıyla başarısızlık döndürmek için bir metot.
    public static Result<T> Failure(string errorMessage, int statusCode = (int)HttpStatusCode.BadRequest)
    {
        return Failure(new List<string> { errorMessage }, statusCode);
    }

    // Durum kodları için statik metotlar

    public static Result<T> NotFound(string errorMessage = "Resource not found.")
    {
        return new Result<T>
        {
            ErrorMessages = new List<string> { errorMessage },
            IsSuccessful = false,
            StatusCode = (int)HttpStatusCode.NotFound
        };
    }

    public static Result<T> Unauthorized(string errorMessage = "Unauthorized access.")
    {
        return new Result<T>
        {
            ErrorMessages = new List<string> { errorMessage },
            IsSuccessful = false,
            StatusCode = (int)HttpStatusCode.Unauthorized
        };
    }

    public static Result<T> Forbidden(string errorMessage = "Access forbidden.")
    {
        return new Result<T>
        {
            ErrorMessages = new List<string> { errorMessage },
            IsSuccessful = false,
            StatusCode = (int)HttpStatusCode.Forbidden
        };
    }

    public static Result<T> InternalServerError(string errorMessage = "An unexpected error occurred.")
    {
        return new Result<T>
        {
            ErrorMessages = new List<string> { errorMessage },
            IsSuccessful = false,
            StatusCode = (int)HttpStatusCode.InternalServerError
        };
    }

    public static Result<T> BadRequest(string errorMessage = "Bad request.")
    {
        return new Result<T>
        {
            ErrorMessages = new List<string> { errorMessage },
            IsSuccessful = false,
            StatusCode = (int)HttpStatusCode.BadRequest
        };
    }

    public static Result<T> Conflict(string errorMessage = "Conflict.")
    {
        return new Result<T>
        {
            ErrorMessages = new List<string> { errorMessage },
            IsSuccessful = false,
            StatusCode = (int)HttpStatusCode.Conflict
        };
    }
}
