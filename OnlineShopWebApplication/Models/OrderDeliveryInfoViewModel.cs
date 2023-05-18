using OnlineShopWebApplication.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApplication.Models
{
    public class OrderDeliveryInfoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Укажите имя получателя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите адрес доставки")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Укажите телефон для связи")]
        public string Phone { get; set; }

        [CheckBoxValidator(ErrorMessage = "Необходимо согласие")]
        public bool Agree { get; set; }

        public string Error { get; set; }
    }
}
