namespace CarDealerMVC.Services.Contracts
{
    using System.Collections.Generic;
    using Models.SaleViewModels;
    using CarDealerMVC.Entities;

    public interface ISaleServices
    {
        List<SaleViewModel> SalesWithDiscount();

        List<SaleViewModel> SelectSale(int id);
        List<SaleViewModel> DiscountByPercentage(double percent);
    }
}
