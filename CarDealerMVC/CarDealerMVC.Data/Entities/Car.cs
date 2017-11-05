namespace CarDealerMVC.Entities
{
    using System.Collections.Generic;

    public class Car
    {
        public Car()
        {
        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public ICollection<PartCars> Parts { get; set; } = new List<PartCars>();

        public int? SaleId { get; set; }

        public Sale Sale { get; set; }
    }
}
