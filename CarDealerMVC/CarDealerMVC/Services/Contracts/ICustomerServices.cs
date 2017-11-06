
namespace CarDealerMVC.Services
{
    using CarDealerMVC.Models.CustomerViewModels;
    using System.Collections.Generic;

    public interface ICustomerServices
    {
        IEnumerable<CustomerViewModel> OrderCustomers(string type);

        CustomerViewModel CustomerById(int id);
    }
}
