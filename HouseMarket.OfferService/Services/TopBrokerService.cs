using HouseMarket.OfferService.DataModel;
using HouseMarket.OfferService.DataModel.InputData.GeneratedClasses;
using HouseMarket.OfferService.Services.BaseClasses;
using HouseMarket.OfferService.Services.Interfaces;
using Object = HouseMarket.OfferService.DataModel.InputData.GeneratedClasses.Object;

namespace HouseMarket.OfferService.Services
{
    public class TopBrokerService:BrokerBaseClass, ITopBrokerService
    {
        private readonly IHouseMarketOfferService _houseMarketOfferService;
        public TopBrokerService(IHouseMarketOfferService houseMarketOfferService)
        {
            _houseMarketOfferService = houseMarketOfferService;
        }

        private HouseMarketOffer? GetHouseMarketOffer(HttpClient httpClient, bool withGarden)
        {
            return _houseMarketOfferService.GetHouseOffer(httpClient, withGarden);
        }

        private static IEnumerable<IGrouping<int, Object>>? GetTopGroupedBrokers(IEnumerable<Object>? objects, int numberOfBrokers)
        {
            return objects?.GroupBy(x => x.MakelaarId).OrderByDescending(x => x.Count()).Take(numberOfBrokers);
        }

        public List<Broker> GetTopBrokers(HttpClient httpClient, bool withGarden, int numberOfBrokers)
        {
            var objects = GetHouseMarketOffer(httpClient, withGarden)?.Objects;
            var topGroupedBrokers = GetTopGroupedBrokers(objects, numberOfBrokers);

            return GetBrokerList(topGroupedBrokers);
        }
    }
}
