﻿
namespace CarDealerMVC.Models.CustomerViewModels
{
    using System;

    public class CustomerViewModel
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public CustomerCarViewModel Cars {get;set;}
    }
}
