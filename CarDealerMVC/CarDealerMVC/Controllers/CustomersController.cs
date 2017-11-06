namespace CarDealerMVC.Controllers
{
    using CarDealerMVC.Data;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using CarDealerMVC.Entities;
    using CarDealerMVC.Services;

    public class CustomersController : Controller
    {
        private readonly ICustomerServices _services;

        public CustomersController(ICustomerServices services)
        {
            this._services = services;
        }

        public IActionResult All(string sort)
        {
           var customers = this._services.OrderCustomers(sort);

            return this.View(customers);
        }
        public IActionResult CustomerById(int id)
        {
            var model = this._services.CustomerById(id);

            return this.View(model);
        }
    }
}