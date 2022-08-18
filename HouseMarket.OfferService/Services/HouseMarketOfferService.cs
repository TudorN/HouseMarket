using HouseMarket.OfferService.DataModel.InputData.GeneratedClasses;
using HouseMarket.OfferService.Services.Interfaces;

namespace HouseMarket.OfferService.Services
{
    public class HouseMarketOfferService: IHouseMarketOfferService
    {
        private readonly IGenericApiCall<HouseMarketOffer> _houseMarketApiService;
        private HouseMarketOffer? _houseMarketOffer;
        private string _url = string.Empty; 
        private const string UrlBase = "https://partnerapi.funda.nl/feeds/Aanbod.svc/json/";
        private const string Key = "ac1b0b1572524640a0ecc54de453ea9f";
        private const string UrlParam1 = "/?type=koop&zo=/amsterdam/&page=1&pagesize=25";
        private const string UrlParam2 = "/?type=koop&zo=/amsterdam/tuin/&page=1&pagesize=25";


        public HouseMarketOfferService(IGenericApiCall<HouseMarketOffer> houseMarketApiService)
        {
            _houseMarketApiService = houseMarketApiService;
        }
        
        private void BuildUrl(bool extraParam)
        {
           _url = UrlBase + Key + (extraParam ? UrlParam2 : UrlParam1);
        }

        public HouseMarketOffer? GetHouseOffer(HttpClient client, bool hasGarden)
        {
            try
            {
                BuildUrl(hasGarden);
                _houseMarketOffer = _houseMarketApiService.GetResultAsync(client, _url).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Retrieving the data via the Api Call failed.{e.Message}");
                throw;
            }

            return _houseMarketOffer;
        }
    }
}
