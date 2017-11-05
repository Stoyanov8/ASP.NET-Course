namespace CarDealerMVC.Entities
{
    using System.Collections.Generic;

    public class Part
    {
        public Part()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double? Price { get; set; }

        public int Quantity { get; set; }

        public ICollection<PartCars> Cars { get; set; } = new List<PartCars>();

        public int? SuplierId { get; set; }

        public Supplier Supplier { get; set; }
    }
}
