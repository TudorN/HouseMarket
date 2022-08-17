using HouseMarket.OfferService.DataModel;

namespace HouseMarket.Models.HouseMarketOffer
{
    public class BrokersViewModel
    {
        public BrokersViewModel()
        {
             TopBrokerListViewModel1 = new TopBrokerListViewModel();
             TopBrokerListViewModel2 = new TopBrokerListViewModel();
        }

        public TopBrokerListViewModel TopBrokerListViewModel1 { get; set; }
        public TopBrokerListViewModel TopBrokerListViewModel2 { get; set; }

        public int NumberOfTopBrokers { get; set; }

        public void BuildModel(List<Broker> brokerList, TopBrokerListViewModel brokerViewModel)
        {
            foreach (var broker in brokerList)
            {
                brokerViewModel.TopBrokers.Add(
                    new TopBrokerItemViewModel
                    {
                        Id = broker.Id,
                        Name = broker.Name,
                        NumberOfHouses = broker.NumberOfHouses
                    });
            }
        }

    }
}
