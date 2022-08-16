using System.Net.Http.Json;
using HouseMarket.OfferService.DataModel;
using HouseMarket.OfferService.Services.Interfaces;

namespace HouseMarket.OfferService.Services
{
    public class HouseWithGardenMarketOfferService: IHouseMarketOfferService
    {
        private readonly HttpClient _client;
        private readonly string _url = "https://partnerapi.funda.nl/feeds/Aanbod.svc/json/ac1b0b1572524640a0ecc54de453ea9f/?type=koop&zo=/amsterdam/tuin/&page=1&pagesize=25";
        private HouseMarketOffer? _houseMarketOffer;

        public HouseWithGardenMarketOfferService(HttpClient client, HouseMarketOffer houseMarketOffer)
        {
            _client = client;
            _houseMarketOffer = houseMarketOffer;
        }

        public async Task<HouseMarketOffer?> GetOfferAsync()
        {
            var response = await _client.GetAsync(_url);
            if (response.IsSuccessStatusCode)
            {
                _houseMarketOffer = await response.Content.ReadFromJsonAsync<HouseMarketOffer>();
            }
            return _houseMarketOffer;
        }
    }
}
