namespace HouseMarket.OfferService.DataModel
{
    public class HouseMarketOffer
    {
        public int AccountStatus { get; set; }
        public bool EmailNotConfirmed { get; set; }
        public bool ValidationFailed { get; set; }
        public object ValidationReport { get; set; }
        public int Website { get; set; }
        public Metadata Metadata { get; set; }
        public IList<Object> Objects { get; set; }
        public Paging Paging { get; set; }
        public int TotaalAantalObjecten { get; set; }
    }
}
