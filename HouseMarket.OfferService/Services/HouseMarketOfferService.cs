using System.Text.Json;
using HouseMarket.OfferService.DataModel.InputData.GeneratedClasses;
using HouseMarket.OfferService.Services.Interfaces;

namespace HouseMarket.OfferService.Services
{
    public class HouseMarketOfferService: IHouseMarketOfferService
    {
        private readonly IGenericApiCall<HouseMarketOffer> _houseMarketApiService;
        private string _url = string.Empty; 
        private const string UrlBase = "https://partnerapi.funda.nl/feeds/Aanbod.svc/json/";
        private const string Key = "ac1b0b1572524640a0ecc54de453ea9f";
        private const string UrlParam1 = "/?type=koop&zo=/amsterdam/&page=1&pagesize=25";
        private const string UrlParam2 = "/?type=koop&zo=/amsterdam/tuin/&page=1&pagesize=25";


        public bool testFlag { get; set; }//in case the api doesn't work set this to true
        private static string DataSample1 => File.ReadAllText("C:\\Users\\Gebruiker\\source\\repos\\HouseMarket\\HouseMarket.OfferService\\bin\\Debug\\net6.0\\DataModel\\InputData\\Json\\Houses.json");
        private static string DataSample2 => File.ReadAllText("C:\\Users\\Gebruiker\\source\\repos\\HouseMarket\\HouseMarket.OfferService\\bin\\Debug\\net6.0\\DataModel\\InputData\\Json\\HousesWithGarden.json");
        public bool testWithGarden { get; set; }
        private string DataSample => testWithGarden ? DataSample2 : DataSample1;
        private HouseMarketOffer? DataSampleHouseMarketOffer => JsonSerializer.Deserialize<HouseMarketOffer>(DataSample);
        
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
            BuildUrl(hasGarden);
            return testFlag ? DataSampleHouseMarketOffer : _houseMarketApiService.GetResultAsync(client, _url).Result;
        }
    }
}
