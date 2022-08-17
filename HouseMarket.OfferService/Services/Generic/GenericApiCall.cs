using System.Net.Http.Json;
using HouseMarket.OfferService.Services.Interfaces;

namespace HouseMarket.OfferService.Services.Generic
{
    public class GenericApiCall<T>: IGenericApiCall<T>
    {
        private T? _object;
        public async Task<T?> GetResultAsync(HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                _object = await response.Content.ReadFromJsonAsync<T>();
            }
            return _object;
        }
    }
}
