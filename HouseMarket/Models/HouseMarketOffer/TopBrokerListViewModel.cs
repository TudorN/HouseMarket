namespace HouseMarket.Models.HouseMarketOffer
{
    public class TopBrokerListViewModel
    {
        public TopBrokerListViewModel()
        {
            TopBrokers = new List<TopBrokerItemViewModel>();
        }

        public List<TopBrokerItemViewModel> TopBrokers { get; set; }
    }
}
