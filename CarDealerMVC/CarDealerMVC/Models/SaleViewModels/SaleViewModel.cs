using CarDealerMVC.Entities;

namespace CarDealerMVC.Models.SaleViewModels
{
    public class SaleViewModel
    {
        
        public int? Id { get; set; }

        public Car Car { get;  set; }
        
        public Customer Customer { get;set; }

        public double? Price { get; set; }

        public double Discount { get; set; }
    }
}