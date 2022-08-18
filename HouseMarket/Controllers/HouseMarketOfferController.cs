using HouseMarket.Models.HouseMarketOffer;
using HouseMarket.OfferService.DataModel;
using Microsoft.AspNetCore.Mvc;
using HouseMarket.OfferService.Services.Interfaces;

namespace HouseMarket.Controllers
{
    public class HouseMarketOfferController : Controller
    {
        private readonly ITopBrokerService _topBrokerService;
        private readonly IHouseMarketOfferService _houseMarketOfferService;
        private readonly IHouseMarketDataSampleService _houseMarketDataSampleService;
        private readonly HttpClient _httpClient;
        private const int NumberOfTopBrokers = 10;

        public HouseMarketOfferController(ITopBrokerService topBrokerService, IHouseMarketOfferService houseMarketOfferService, IHouseMarketDataSampleService houseMarketDataSampleService)
        {
            _topBrokerService = topBrokerService;
            _houseMarketOfferService = houseMarketOfferService;
            _houseMarketDataSampleService = houseMarketDataSampleService;
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
                
                topBrokers = _topBrokerService.GetBrokers(houseMarketOffer, NumberOfTopBrokers);
                topBrokersWithGarden = _topBrokerService.GetBrokers(houseMarketOfferWithGarden, NumberOfTopBrokers);
                model.ApiCallSuccessful = true;
            }
            catch (Exception)
            {
                // in case the api doesn't work we show some dataSamples
                var dataSample1 = _houseMarketDataSampleService.GetDataSample(false);
                var dataSample2 = _houseMarketDataSampleService.GetDataSample(false);
                
                topBrokers = _topBrokerService.GetBrokers(dataSample1, NumberOfTopBrokers);
                topBrokersWithGarden = _topBrokerService.GetBrokers(dataSample2, NumberOfTopBrokers);
            }


            model.NumberOfTopBrokers = NumberOfTopBrokers;
            model.BuildModel(topBrokers, model.TopBrokerListViewModel1);
            model.BuildModel(topBrokersWithGarden, model.TopBrokerListViewModel2);
          

            return View(model);
        }
    }
}
