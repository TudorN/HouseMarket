using System.Text.Json;
using HouseMarket.OfferService.DataModel.InputData.GeneratedClasses;
using HouseMarket.OfferService.Services.Interfaces;

namespace HouseMarket.OfferService.Services
{
    public class HouseMarketDataSampleService: IHouseMarketDataSampleService
    {
        private static readonly string DataSample1 = File.ReadAllText("..\\HouseMarket.OfferService\\bin\\Debug\\net6.0\\DataModel\\InputData\\Json\\Houses.json");
        private static readonly string DataSample2 = File.ReadAllText("..\\HouseMarket.OfferService\\bin\\Debug\\net6.0\\DataModel\\InputData\\Json\\HousesWithGarden.json");

        public HouseMarketOffer? GetDataSample(bool withGarden)
        {
            var dataSample = withGarden ? DataSample1 : DataSample2;
            return JsonSerializer.Deserialize<HouseMarketOffer>(dataSample);
        }
    }
}
