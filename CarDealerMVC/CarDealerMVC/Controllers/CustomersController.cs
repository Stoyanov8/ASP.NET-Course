namespace CarDealerMVC.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using CarDealerMVC.Services;
    using CarDealerMVC.Models.CustomerViewModels;

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

        [Route("customers/create")]
        public IActionResult Create() => this.View();

        [HttpPost]
        [Route("customers/create")]
        public IActionResult Create(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }
            else
            {
                this._services.AddCustomer(model.Name, model.BirthDate);
                return this.Redirect("all/ascending");
            }
        }
        [Route("customers/edit")]
        public IActionResult Edit(int id)
        {
            var model = this._services.CustomerById(id);

            return this.View(model);
        }

        [HttpPost]
        [Route("customers/edit")]
        public IActionResult Edit(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            else
            {
                int id = this._services.FindCustomerId(model.Name);
                this._services.EditCustomer(id,model.Name, model.BirthDate);
                return this.Redirect("all/ascending");
            }
        }
    }
}