
namespace CarDealerMVC.Controllers
{
    using CarDealerMVC.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    public class SuppliersController : Controller
    {
        private readonly ISupplierServices _services;
        public SuppliersController(ISupplierServices services)
        {
            this._services = services;
        }
        public IActionResult Filter(string type)
        {
           var filteredSuppliers = this._services.FilterSuppliers(type);

            return this.View(filteredSuppliers);
        }
    }
}
