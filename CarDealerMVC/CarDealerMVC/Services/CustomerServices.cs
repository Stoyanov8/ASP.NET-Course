namespace CarDealerMVC.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using CarDealerMVC.Models.CustomerViewModels;
    using CarDealerMVC.Data;
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
    }
}
