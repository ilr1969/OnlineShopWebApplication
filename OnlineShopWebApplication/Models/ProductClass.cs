using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApplication.Models
{
    public class ProductClass
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Range(0, 100000000, ErrorMessage = "Укажите корректную сумму")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public ProductClass()
        {
            ID = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{ID}\n{Name}\n{Cost}\n{Description}".ToString();
        }
    }
}
