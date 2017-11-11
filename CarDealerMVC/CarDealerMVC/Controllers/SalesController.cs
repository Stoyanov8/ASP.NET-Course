namespace CarDealerMVC.Controllers
{
    using CarDealerMVC.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Models.SaleViewModels;
    public class SalesController : Controller
    {
        private readonly ISaleServices _services;

        public SalesController(ISaleServices services)
        {
            this._services = services;
        }

        public IActionResult SelectSale(int id)
        {
            var model = _services.SelectSale(id);

            return this.View(model);
        }
        public IActionResult SalesWithDiscount()
        {
            var sales = this._services.SalesWithDiscount();

            return this.View(sales);
        }
        public IActionResult DiscountByPercentage(double percent)
        {
            var sales = this._services.DiscountByPercentage(percent);

            return this.View(sales);
        }
        [Route("sales/add")]
        public IActionResult Add()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            var model = this._services.AllCarsAndCustomers();
            return this.View(model);
        }
        [Route("sales/add")]
        [HttpPost]
        public IActionResult Add(AddSaleViewModel saleModel)
        {
            this._services.AddNewSale(saleModel.Car, saleModel.Customer, saleModel.Discount);
            return this.SelectSale(0);
        }
    }
}
