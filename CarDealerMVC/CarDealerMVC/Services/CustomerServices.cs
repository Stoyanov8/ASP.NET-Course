namespace CarDealerMVC.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using CarDealerMVC.Models.CustomerViewModels;
    using CarDealerMVC.Data;
    using CarDealerMVC.Entities;

    public class CustomerServices : ICustomerServices
    {
        private readonly CarDealerDbContext _context;
        public CustomerServices(CarDealerDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<CustomerViewModel> OrderCustomers(string type)
        {
            var customers = this._context.Customers.ToList();

            if (type == "ascending")
            {
                customers = customers
                    .OrderBy(x => x.BirthDate)
                    .ThenBy(x => x.IsYoungDriver)
                    .ToList();
            }
            else
            {
                customers = customers
                    .OrderByDescending(x => x.BirthDate)
                    .ThenBy(x => x.IsYoungDriver)
                    .ToList();
            }

            return
                   customers.Select(x => new CustomerViewModel
                   {
                       Name = x.Name,
                       BirthDate = x.BirthDate,
                       IsYoungDriver = x.IsYoungDriver
                   }).ToList();
        }

        public CustomerViewModel CustomerById(int id)
        {
            var caca = this._context.Customers
                .Where(x => x.Id == id)
                         .Select(x => new CustomerViewModel
                         {
                             Name = x.Name,
                             BirthDate = x.BirthDate,
                             IsYoungDriver = x.IsYoungDriver,
                             Cars = x.Sales.Where(c => c.CustomerId == id)
                            .Select(y => new CustomerCarViewModel
                            {
                                BoughtCars = x.Sales.Count(),
                                MoneySpended = CalculatePrice(id)
                            }).FirstOrDefault()

                         }).FirstOrDefault();
            return caca;
        }
        public double? CalculatePrice(int customerId)
        {
            double? sum = 0.0;

            var sales = this._context
                .Sales
                .Where(s => s.CustomerId == customerId)
                .ToList();

            var customer = this._context.Customers
                .FirstOrDefault(a => a.Id == customerId);

            foreach (var sale in sales)
            {
                var partsPrice = this._context.Cars
                    .Where(c => c.Id == sale.CarId)
                    .Select(p => p.Parts.Sum(a=> a.Part.Price)).FirstOrDefault();
                if(partsPrice != null)
                {
                    sum += partsPrice;
                    sum -= sum * (sale.Discount / 10);
                }
            }
            if (customer.IsYoungDriver)
            {
                sum -= sum * 0.05;
            }

            return sum;
        }
    }
}