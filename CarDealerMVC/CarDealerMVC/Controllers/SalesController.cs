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
           var sales= this._services.SalesWithDiscount();

            return this.View(sales);
        }
        public IActionResult DiscountByPercentage (double percent)
        {
            var sales = this._services.DiscountByPercentage(percent);

            return this.View(sales);
        }
    }
}
