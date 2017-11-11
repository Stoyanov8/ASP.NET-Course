namespace CarDealerMVC.Services.Contracts
{
    using System.Collections.Generic;
    using Models.SaleViewModels;

    public interface ISaleServices
    {
        List<SaleViewModel> SalesWithDiscount();

        List<SaleViewModel> SelectSale(int id);
        List<SaleViewModel> DiscountByPercentage(double percent);
        AddSaleViewModel AllCarsAndCustomers();
        void AddNewSale(string car, string customer, double discount);
    }
}
