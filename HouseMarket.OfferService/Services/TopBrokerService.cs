using HouseMarket.OfferService.DataModel;
using HouseMarket.OfferService.DataModel.InputData.GeneratedClasses;
using HouseMarket.OfferService.Services.BaseClasses;
using HouseMarket.OfferService.Services.Interfaces;
using Object = HouseMarket.OfferService.DataModel.InputData.GeneratedClasses.Object;

namespace HouseMarket.OfferService.Services
{
    public class TopBrokerService:BrokerBaseClass, ITopBrokerService
    {
        private static IEnumerable<IGrouping<int, Object>>? GetTopGroupedBrokers(IEnumerable<Object>? objects, int numberOfBrokers)
        {
            return objects?.GroupBy(x => x.MakelaarId).OrderByDescending(x => x.Count()).Take(numberOfBrokers);
        }

        public List<Broker> GetTopBrokers(HouseMarketOffer? houseMarketOffer, int numberOfBrokers)
        {
            var objects = houseMarketOffer?.Objects;
            var topGroupedBrokers = GetTopGroupedBrokers(objects, numberOfBrokers);

            return GetBrokerList(topGroupedBrokers);
        }
    }
}
