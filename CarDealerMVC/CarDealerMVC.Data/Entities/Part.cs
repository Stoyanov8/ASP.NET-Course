namespace CarDealerMVC.Entities
{
    using System.Collections.Generic;

    public class Part
    {
        public Part(string name,double price,int quantity, Supplier supplier,int supplierId)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Supplier = supplier;
            this.SuplierId = supplierId;
        }
        public Part()
        {

        }
        public int Id { get; private set; }

        public string Name { get; private set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public ICollection<PartCars> Cars { get; set; } = new List<PartCars>();

        public int? SuplierId { get; private set; }

        public Supplier Supplier { get; private set; }
    }
}
