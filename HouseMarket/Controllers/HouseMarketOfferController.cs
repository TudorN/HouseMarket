using System.Text.Json;
using HouseMarket.Models.HouseMarketOffer;
using HouseMarket.OfferService.DataModel;
using HouseMarket.OfferService.DataModel.InputData.GeneratedClasses;
using Microsoft.AspNetCore.Mvc;
using HouseMarket.OfferService.Services.Interfaces;

namespace HouseMarket.Controllers
{
    public class HouseMarketOfferController : Controller
    {
        private readonly ITopBrokerService _topBrokerService;
        private readonly IHouseMarketOfferService _houseMarketOfferService;
        private readonly HttpClient _httpClient;
        public HouseMarketOfferController(ITopBrokerService topBrokerService, IHouseMarketOfferService houseMarketOfferService)
        {
            _topBrokerService = topBrokerService;
            _houseMarketOfferService = houseMarketOfferService;
            _httpClient = new HttpClient();
        }
        public IActionResult Index()
        {
            var model = new BrokersModel();
            List<Broker> top10Brokers;
            List<Broker> top10BrokersWithGarden;

            try
            {
                var houseMarketOffer = _houseMarketOfferService.GetHouseOffer(_httpClient, false);
                var houseMarketOfferWithGarden = _houseMarketOfferService.GetHouseOffer(_httpClient, true);
                
                top10Brokers = _topBrokerService.GetTopBrokers(houseMarketOffer, 10);
                top10BrokersWithGarden = _topBrokerService.GetTopBrokers(houseMarketOfferWithGarden, 10);
            }
            catch (Exception)// in case the api doesn't work
            {
                var sampleDataString1 = System.IO.File.ReadAllText("..\\HouseMarket.OfferService\\bin\\Debug\\net6.0\\DataModel\\InputData\\Json\\Houses.json");
                var sampleDataObject1 = JsonSerializer.Deserialize<HouseMarketOffer>(sampleDataString1);

                var sampleDataString2 = System.IO.File.ReadAllText("..\\HouseMarket.OfferService\\bin\\Debug\\net6.0\\DataModel\\InputData\\Json\\HousesWithGarden.json");
                var sampleDataObject2 = JsonSerializer.Deserialize<HouseMarketOffer>(sampleDataString2);


                top10Brokers = _topBrokerService.GetTopBrokers(sampleDataObject1, 10);
                top10BrokersWithGarden = _topBrokerService.GetTopBrokers(sampleDataObject2, 10);
            }
          
            model.Top10Brokers = top10Brokers;
            model.Top10BrokersHousesWithGarden = top10BrokersWithGarden;
          

            return View(model);
        }
    }
}
