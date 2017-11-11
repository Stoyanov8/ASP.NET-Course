
namespace CarDealerMVC.Services
{
    using CarDealerMVC.Models.CustomerViewModels;
    using System;
    using System.Collections.Generic;

    public interface ICustomerServices
    {
        IEnumerable<CustomerViewModel> OrderCustomers(string type);

        CustomerViewModel CustomerById(int id);

        void AddCustomer(string name, DateTime birthday);

        void EditCustomer(int id, string name, DateTime birthday);

        int FindCustomerId(string name);
    }
}
