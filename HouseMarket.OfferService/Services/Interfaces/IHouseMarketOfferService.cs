using HouseMarket.OfferService.DataModel.InputData.GeneratedClasses;

namespace HouseMarket.OfferService.Services.Interfaces
{
    public interface IHouseMarketOfferService
    {
        public bool testWithGarden { get; set; }
        public bool testFlag { get; set; }
        HouseMarketOffer? GetHouseOffer(HttpClient client, bool hasGarden);
    }
}
