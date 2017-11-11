namespace CarDealerMVC.Controllers
{
    using CarDealerMVC.Models.PartViewModels;
    using CarDealerMVC.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    public class PartsController : Controller
    {
        private readonly IPartsServices _services;

        public PartsController(IPartsServices services)
        {
            this._services = services;
        }
        [Route("parts/all")]
        public IActionResult All()
        {
            var parts = this._services.SelectAllParts();
            return this.View(parts);
        }
        [Route("parts/create")]
        public IActionResult Create()
        {
            var suppliers = this._services.SelectSuppliers();
            return this.View(suppliers);
        }

        [HttpPost]
        [Route("parts/create")]
        public IActionResult Create(PartViewModel model)
        {
            if (!this.ModelState.IsValid || string.IsNullOrWhiteSpace(model.Name))
            {
                return this.Create();
            }
            this._services.CreatePart(model.Name, model.Price, model.Quantity, model.Supplier);

            return this.Redirect("/");
        }
        [Route("parts/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var part = this._services.SelectPart(id);

            return this.View(part);

        }
        [Route("parts/edit/{id}")]
        [HttpPost]
        public IActionResult Edit(PartViewModel model)
        {
            this._services.EditPart(model.Id, model.Price, model.Quantity);
            return this.Redirect("/");
        }

        [Route("parts/delete/{id}")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            this._services.DeletePart(id);
            return this.Redirect("/");
        }
    }
}
