namespace CarDealerMVC.Services
{
    using System.Collections.Generic;
    using CarDealerMVC.Models.SaleViewModels;
    using CarDealerMVC.Services.Contracts;
    using CarDealerMVC.Data;
    using System.Linq;
    using CarDealerMVC.Entities;

    public class SaleServices : ISaleServices
    {
        private readonly CarDealerDbContext _context;
        public SaleServices(CarDealerDbContext context)
        {
            this._context = context;
        }
        public List<SaleViewModel> SelectSale(int id)
        {
            List<SaleViewModel> sales = null;
            if (id == 0)
            {
                sales = this._context.Sales.Select(x => new SaleViewModel
                {
                    Id = x.Id,
                    Car = this._context.Cars.FirstOrDefault(a => a.Id == x.CarId),
                    Customer = x.Customer,
                }).ToList();
            }
            else
            {
                sales = this._context.Sales
                    .Where(s => s.Id == id)
                    .Select(x => new SaleViewModel
                    {
                        Id = x.Id,
                        Car = this._context.Cars.FirstOrDefault(a => a.Id == x.CarId),
                        Customer = x.Customer

                    }).ToList();
            }
            foreach (var sale in sales)
            {
                sale.Price = CalculatePrice(sale.Customer.Id);
            }
            return sales;
        }

        public List<SaleViewModel> SalesWithDiscount()
        {
            return
                this._context
                .Sales
                .Where(a => a.Discount != 0.0)
                .Select(a=> new SaleViewModel
                {
                   Discount= a.Discount

                }).ToList();
        }
        
        public List<SaleViewModel> DiscountByPercentage (double percent)
        {
           return this._context
               .Sales
               .Where(a => a.Discount == percent)
               .Select(a => new SaleViewModel
               {
                   Car = this._context.Cars.FirstOrDefault(c => c.Id == a.CarId),
                   Customer = a.Customer,
                   Discount = percent,
               }).ToList();
        }
        public double? CalculatePrice(int? customerId)
        {
            double? sum = 0.0;

            var sales = this._context
                .Sales
                .Where(s => s.CustomerId == customerId)
                .ToList();
            foreach (var sale in sales)
            {
                var partsPrice = this._context.Cars
                    .Where(c => c.Id == sale.CarId)
                    .Select(p => p.Parts.Sum(a => a.Part.Price))
                    .FirstOrDefault();

                if (partsPrice != null)
                {
                    sum += partsPrice;
                    sum -= sum * (sale.Discount / 10);
                }
            }
            return sum;
        }
    }

}
