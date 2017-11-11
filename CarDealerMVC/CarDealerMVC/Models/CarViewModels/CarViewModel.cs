namespace CarDealerMVC.Models.CarViewModels
{
    using CarDealerMVC.Models.PartViewModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarViewModel
    {
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public long TravelledDistance { get; set; }

        public ICollection<PartViewModel> Parts { get; set; }
    }
}