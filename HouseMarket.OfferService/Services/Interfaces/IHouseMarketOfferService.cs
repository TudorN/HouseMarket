using HouseMarket.OfferService.DataModel;

namespace HouseMarket.OfferService.Services.Interfaces
{
    public interface  IHouseMarketOfferService
    {
        Task<HouseMarketOffer?> GetOfferAsync();
    }
}
