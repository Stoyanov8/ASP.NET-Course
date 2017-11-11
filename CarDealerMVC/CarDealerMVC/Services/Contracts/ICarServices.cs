namespace CarDealerMVC.Services.Contracts
{
    using CarDealerMVC.Models.CarViewModels;
    using System.Collections.Generic;

    public interface ICarServices
    {
        IEnumerable<CarViewModel> CarByMake(string make);

        CarViewModel ShowParts(int id);

        List<CarViewModel> All();
        void AddCar(string make, string model, long travelledDistance);
    }
}
