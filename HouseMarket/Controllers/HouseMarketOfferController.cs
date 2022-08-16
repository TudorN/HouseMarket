using Microsoft.AspNetCore.Mvc;

namespace HouseMarket.Controllers
{
    public class HouseMarketOfferController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
