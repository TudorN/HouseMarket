using HouseMarket.OfferService.DataModel.InputData.GeneratedClasses;
using HouseMarket.OfferService.Services;
using HouseMarket.OfferService.Services.Generic;
using HouseMarket.OfferService.Services.Interfaces;
using Ninject;
using Ninject.Modules;

namespace HouseMarket.OfferService.DependencyInjection
{
    public class HouseMarketNinjectModule: NinjectModule
    {
        private static IKernel _kernelInstance;

        public IKernel Kernel
        {
            get
            {
                if (_kernelInstance == null)
                {
                    var kernel = CreateKernel();
                    _kernelInstance = kernel;
                }

                return _kernelInstance;
            }
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            RegisterServices(kernel);
            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load(AppDomain.CurrentDomain.GetAssemblies().Where(asm => !asm.IsDynamic));
        }

        public override void Load()
        {
            Bind<IHouseMarketOfferService>().To<HouseMarketOfferService>();
            Bind<ITopBrokerService>().To<TopBrokerService>();
            Bind<IGenericApiCall<HouseMarketOffer>>().To<GenericApiCall<HouseMarketOffer>>();
        }
    }
}
