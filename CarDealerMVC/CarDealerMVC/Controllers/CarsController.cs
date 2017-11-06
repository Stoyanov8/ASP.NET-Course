namespace CarDealerMVC.Controllers
{
    using CarDealerMVC.Data;
    using CarDealerMVC.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
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
        public IActionResult CarParts(int id)
        {
            var carAndParts = this._services.ShowParts(id);
            return this.View(carAndParts);
        }

        [Route("cars/all")]
        public IActionResult All()
        {
            var models = this._services.All();
            return this.View(models);
        }
    }
}
