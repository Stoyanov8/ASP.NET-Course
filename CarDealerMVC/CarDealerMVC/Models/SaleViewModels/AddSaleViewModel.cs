using CarDealerMVC.Entities;
using CarDealerMVC.Models.CarViewModels;
using System.Collections.Generic;

namespace CarDealerMVC.Models.SaleViewModels
{
    public class AddSaleViewModel
    {
        public string Customer { get; set; }

        public string Car { get; set; }

        public double Discount { get; set; }

        public List<string> Customers { get; set; }

        public List<string> Cars { get; set; }
    }
}
