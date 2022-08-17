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
        public HouseMarketOfferController(ITopBrokerService topBrokerService, IHouseMarketOfferService houseMarketOfferService)
        {
            this._topBrokerService = topBrokerService;
            _houseMarketOfferService = houseMarketOfferService;
        }
        public IActionResult Index()
        {
            var httpClient = new HttpClient();
            var model = new BrokersModel();
            List<Broker> top10Brokers;

            try
            { 
                top10Brokers = _topBrokerService.GetTopBrokers(httpClient, false, 10);
            }
            catch (Exception)
            {
                _houseMarketOfferService.testFlag = true;
                top10Brokers = _topBrokerService.GetTopBrokers(httpClient, false, 10);
            }
          
            model.Top10Brokers = top10Brokers;
          

            return View(model);
        }
    }
}
