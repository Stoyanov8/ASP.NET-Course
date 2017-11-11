
namespace CarDealerMVC.Models.CustomerViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public CustomerCarViewModel Cars {get;set;}
    }
}
