using HouseMarket.OfferService.DataModel;

namespace HouseMarket.OfferService.Services.Interfaces
{
    public interface ITopBrokerService
    {
        List<Broker> GetTopBrokers(HttpClient httpClient, bool withGarden, int numberOfBrokers);
    }
}
