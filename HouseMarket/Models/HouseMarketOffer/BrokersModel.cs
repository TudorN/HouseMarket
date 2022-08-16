namespace HouseMarket.Models.HouseMarketOffer
{
    public class BrokersModel
    {
        public string Name { get; set; }
        public OfferService.DataModel.HouseMarketOffer? HouseMarketOffer { get; set; }
        public IEnumerable<IGrouping<int, OfferService.DataModel.Object>>? TopBrokers { get; set; }
    }
}
