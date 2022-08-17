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
        private const int NumberOfTopBrokers = 5;

        public HouseMarketOfferController(ITopBrokerService topBrokerService, IHouseMarketOfferService houseMarketOfferService)
        {
            _topBrokerService = topBrokerService;
            _houseMarketOfferService = houseMarketOfferService;
            _httpClient = new HttpClient();
        }
        public IActionResult Index()
        {
            var model = new BrokersViewModel();
            List<Broker> topBrokers;
            List<Broker> topBrokersWithGarden;

            try
            {
                var houseMarketOffer = _houseMarketOfferService.GetHouseOffer(_httpClient, false);
                var houseMarketOfferWithGarden = _houseMarketOfferService.GetHouseOffer(_httpClient, true);
                
                topBrokers = _topBrokerService.GetTopBrokers(houseMarketOffer, NumberOfTopBrokers);
                topBrokersWithGarden = _topBrokerService.GetTopBrokers(houseMarketOfferWithGarden, NumberOfTopBrokers);
            }
            catch (Exception)// in case the api doesn't work
            {
                var sampleDataString1 = System.IO.File.ReadAllText("..\\HouseMarket.OfferService\\bin\\Debug\\net6.0\\DataModel\\InputData\\Json\\Houses.json");
                var sampleDataObject1 = JsonSerializer.Deserialize<HouseMarketOffer>(sampleDataString1);

                var sampleDataString2 = System.IO.File.ReadAllText("..\\HouseMarket.OfferService\\bin\\Debug\\net6.0\\DataModel\\InputData\\Json\\HousesWithGarden.json");
                var sampleDataObject2 = JsonSerializer.Deserialize<HouseMarketOffer>(sampleDataString2);


                topBrokers = _topBrokerService.GetTopBrokers(sampleDataObject1, NumberOfTopBrokers);
                topBrokersWithGarden = _topBrokerService.GetTopBrokers(sampleDataObject2, NumberOfTopBrokers);
            }


            model.NumberOfTopBrokers = NumberOfTopBrokers;
            model.BuildModel(topBrokers, model.TopBrokerListViewModel1);
            model.BuildModel(topBrokersWithGarden, model.TopBrokerListViewModel2);
          

            return View(model);
        }
    }
}
