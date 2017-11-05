namespace CarDealerMVC.Services.Contracts
{
    using CarDealerMVC.Models.CarViewModel;
    using System.Collections.Generic;

    public interface ICarServices
    {
        IEnumerable<CarViewModel> CarByMake(string make);
    }
}
