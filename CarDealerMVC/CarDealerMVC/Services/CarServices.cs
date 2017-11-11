namespace CarDealerMVC.Services.Contracts
{
    using System.Collections.Generic;
    using CarDealerMVC.Models.CarViewModel;
    using CarDealerMVC.Data;
    using System.Linq;
    using CarDealerMVC.Entities;
    using CarDealerMVC.Models.PartViewModels;

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
                     Parts = x.Parts.Select(a => new PartViewModel
                     {
                         Id = a.Part.Id,
                         Name = a.Part.Name
                     }).ToList()
                 }).OrderBy(x => x.Model)
                 .ThenByDescending(x => x.TravelledDistance)
                 .ToList();
        }

        public CarViewModel ShowParts(int id)
        {
            return this._context
                .Cars
                .Where(x => x.Id == id)
                .Select(x => new CarViewModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.Parts.
                            Where(b => b.CarId == id)
                              .Select(a => new PartViewModel
                              {
                                  Id = a.Part.Id,
                                  Name = a.Part.Name
                              }).ToList()
                }).FirstOrDefault();
        }
        public List<CarViewModel> All()
        {
            return
                 this._context.Cars.Select(y => new CarViewModel
                 {
                     Make = y.Make,
                     Model = y.Model,
                     TravelledDistance = y.TravelledDistance
                 }).ToList();
        }

        public void AddCar(string make, string model, long travelledDistance)
        {
            this._context.Cars.Add(new Car()
            {
                Make = make,
                Model = model,
                TravelledDistance = travelledDistance
            });
            this._context.SaveChanges();
        }
    }
}
