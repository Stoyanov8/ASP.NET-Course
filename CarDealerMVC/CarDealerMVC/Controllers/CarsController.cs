namespace CarDealerMVC.Controllers
{
    using CarDealerMVC.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using CarDealerMVC;
    public class CarsController : Controller
    {
        private readonly ICarServices _services;
        public CarsController(ICarServices services)
        {
            this._services = services;
        }
        public IActionResult CarsByMake(string make)
        {
            var cars = _services.CarByMake(make);

            return this.View(cars);
        }
    }
}
