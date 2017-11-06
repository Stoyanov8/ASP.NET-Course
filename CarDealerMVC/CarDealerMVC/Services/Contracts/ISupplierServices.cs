
namespace CarDealerMVC.Services.Contracts
{
    using CarDealerMVC.Models.SupplierViewModel;
    using System.Collections.Generic;

    public interface ISupplierServices
    {
        IEnumerable<SupplierViewModel> FilterSuppliers(string filter);
    }
}
