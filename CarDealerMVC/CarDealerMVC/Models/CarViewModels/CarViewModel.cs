
namespace CarDealerMVC.Models.CarViewModel
{
    using CarDealerMVC.Models.PartViewModels;
    using System.Collections.Generic;

    public class CarViewModel
    {
        public double TravelledDistance { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public ICollection<PartViewModel> Parts { get; set; }
    }
}