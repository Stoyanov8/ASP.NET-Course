namespace CarDealerMVC.Models.PartViewModels
{
    using CarDealerMVC.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PartViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please fill this.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please fill this.")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Please fill this.")]
        public int Quantity { get; set; }

        public List<Supplier> Suppliers { get; set; }
        [Required(ErrorMessage ="Please fill this.")]
        public string Supplier { get; set; }
    }
}
