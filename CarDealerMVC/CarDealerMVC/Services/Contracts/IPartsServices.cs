
namespace CarDealerMVC.Services.Contracts
{
    using CarDealerMVC.Entities;
    using CarDealerMVC.Models.PartViewModels;
    using System.Collections.Generic;

    public interface IPartsServices
    {
        PartViewModel SelectSuppliers();
        void CreatePart(string name, double price, int quantity, string supplier);
        PartViewModel SelectPart(int id);
        void EditPart(int id, double price, int quantity);
        void DeletePart(int id);
        IList<PartViewModel> SelectAllParts();
    }
}
