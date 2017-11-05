
namespace CarDealerMVC.Models.CarViewModel
{
    using CarDealerMVC.Entities;
    using System.Collections.Generic;

    public class CarViewModel
    {
        public double TravelledDistance { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public ICollection<PartCars> Parts { get; set; }

    }
}