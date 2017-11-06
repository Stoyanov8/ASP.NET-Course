namespace CarDealerMVC.Services
{
    using System.Collections.Generic;
    using Contracts;
    using CarDealerMVC.Data;
    using System.Linq;
    using CarDealerMVC.Models.SupplierViewModel;

    public class SupplierServices : ISupplierServices
    {
        private readonly CarDealerDbContext _context;
        public SupplierServices(CarDealerDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<SupplierViewModel> FilterSuppliers(string filter)
        {
            bool isLocal = true;

            if(filter == "importers")
            {
                isLocal = false;
            }

            return this._context.Suppliers
                .Where(s => s.IsImporter == isLocal)
                .Select(x => new SupplierViewModel
                {
                    Name = x.Name,
                    Id = x.Id,
                    PartsCount = x.Parts.Count()
            }).ToList();
        }
    }
}
