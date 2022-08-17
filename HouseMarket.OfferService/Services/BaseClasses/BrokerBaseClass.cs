using HouseMarket.OfferService.DataModel;
using Object = HouseMarket.OfferService.DataModel.InputData.GeneratedClasses.Object;

namespace HouseMarket.OfferService.Services.BaseClasses
{
    public class BrokerBaseClass
    {
        public List<Broker> GetBrokerList( IEnumerable<IGrouping<int, Object>>? groupedHouses)
        {
            var brokers = new List<Broker>();
            if (groupedHouses != null)
                brokers.AddRange(groupedHouses.Select(item => new Broker()
                {
                    Id = item.Select(x => x.MakelaarId).First(), Name = item.Select(x => x.MakelaarNaam).First(),
                    NumberOfHouses = item.Count()
                }));

            return brokers;
        }
    }
}
