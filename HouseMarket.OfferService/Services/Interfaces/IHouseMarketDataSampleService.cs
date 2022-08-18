using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseMarket.OfferService.DataModel.InputData.GeneratedClasses;

namespace HouseMarket.OfferService.Services.Interfaces
{
    public interface IHouseMarketDataSampleService
    {
        HouseMarketOffer? GetDataSample(bool withGarden);
    }
}
