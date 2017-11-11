namespace CarDealerMVC.Controllers
{
    using CarDealerMVC.Entities;
    using CarDealerMVC.Models.CarViewModels;
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
        [Route("cars/add")]
        public IActionResult CreateCar()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
              
                return RedirectToAction("Index", "Home", new { area = "" });

            }

            return this.View();
        }


        [Route("cars/add")]
        [HttpPost]
        public IActionResult CreateCar(CarViewModel car)
        {
            if (!this.ModelState.IsValid
                || string.IsNullOrEmpty(car.Make)
                || string.IsNullOrEmpty(car.Make))
            {
                return this.View();
            }
            this._services.AddCar(car.Make, car.Model, car.TravelledDistance);

            return this.Redirect("all");

        }
    }
}
