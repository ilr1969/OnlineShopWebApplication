using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApplication.Models
{
    public class ProductViewModel
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}
