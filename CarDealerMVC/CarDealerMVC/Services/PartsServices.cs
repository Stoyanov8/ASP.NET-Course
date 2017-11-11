namespace CarDealerMVC.Services
{
    using CarDealerMVC.Data;
    using CarDealerMVC.Entities;
    using CarDealerMVC.Models.PartViewModels;
    using CarDealerMVC.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PartsServices : IPartsServices
    {
        private readonly CarDealerDbContext _context;

        public PartsServices(CarDealerDbContext context)
        {
            this._context = context;
        }

        public void CreatePart(string name, double price, int quantity, string supplierName)
        {
            if (quantity == 0)
            {
                quantity = 1;
            }
            var supplier = this._context.Suppliers.FirstOrDefault(a => a.Name == supplierName);
            this._context.Parts.Add(new Part(name, price, quantity, supplier, supplier.Id));
            this._context.SaveChanges();
        }
        public PartViewModel SelectSuppliers()
        {
            return new PartViewModel()
            {
                Suppliers = this._context.Suppliers.ToList()
            };
        }

        public PartViewModel SelectPart(int id)
        {
            return this._context.Parts.Where(a => a.Id == id)
                .Select(x => new PartViewModel
                {
                    Id = id,
                    Price = x.Price,
                    Quantity = x.Quantity
                }).FirstOrDefault();
        }

        public void EditPart(int id, double price, int quantity)
        {
            var part = this._context.Parts.FirstOrDefault(a => a.Id == id);

            part.Quantity = quantity;
            part.Price = price;
            this._context.SaveChanges();
        }

        public void DeletePart(int id)
        {
            var partToRemove = this._context.Parts.FirstOrDefault(x => x.Id == id);

            this._context.Parts.Remove(partToRemove);
            this._context.SaveChanges();
        }

        public IList<PartViewModel> SelectAllParts()
        {
            return this._context.Parts
                .Select(p => new PartViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Supplier = p.Supplier.Name
                }).ToList();
        }
    }
}