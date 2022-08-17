using HouseMarket.OfferService.DataModel;
using HouseMarket.OfferService.DataModel.InputData.GeneratedClasses;

namespace HouseMarket.OfferService.Services.Interfaces
{
    public interface ITopBrokerService
    {
        List<Broker> GetBrokers(HouseMarketOffer? houseMarketOffer, int numberOfBrokers);
    }
}
