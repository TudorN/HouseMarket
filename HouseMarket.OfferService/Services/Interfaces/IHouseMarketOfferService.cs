using HouseMarket.OfferService.DataModel.InputData.GeneratedClasses;

namespace HouseMarket.OfferService.Services.Interfaces
{
    public interface IHouseMarketOfferService
    {
        HouseMarketOffer? GetHouseOffer(HttpClient client, bool hasGarden);
    }
}
