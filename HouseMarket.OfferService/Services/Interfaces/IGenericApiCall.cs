namespace HouseMarket.OfferService.Services.Interfaces
{
    public interface IGenericApiCall<T>
    {
        Task<T?> GetResultAsync(HttpClient client, string url);
    }
}
