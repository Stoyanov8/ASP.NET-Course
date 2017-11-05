namespace CarDealerMVC.Entities
{
    public class PartCars
    {
        public PartCars()
        {
        }
        public int? CarId { get; set; }

        public Car Car { get; set; }

        public int? PartId { get; set; }

        public Part Part { get; set; }
    }
}
