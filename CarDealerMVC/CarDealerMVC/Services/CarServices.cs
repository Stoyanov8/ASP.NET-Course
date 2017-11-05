namespace CarDealerMVC.Services.Contracts
{
    using System.Collections.Generic;
    using CarDealerMVC.Models.CarViewModel;
    using CarDealerMVC.Data;
    using System.Linq;

    public class CarServices : ICarServices
    {
        private readonly CarDealerDbContext _context;
        public CarServices(CarDealerDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<CarViewModel> CarByMake(string make)
        {

            return this._context
                 .Cars
                 .Where(x => x.Make.ToLower() == make.ToLower())
                 .Select(x => new CarViewModel
                 {
                     Make = x.Make,
                     Model = x.Model,
                     TravelledDistance = x.TravelledDistance,
                     Parts = x.Parts.Where(a => a.CarId == x.Id).ToList()
                 }).OrderBy(x => x.Model)
                 .ThenByDescending(x => x.TravelledDistance)
                 .ToList();
        }
    }
}
