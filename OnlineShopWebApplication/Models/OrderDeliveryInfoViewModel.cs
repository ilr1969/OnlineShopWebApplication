﻿using System;
using System.ComponentModel.DataAnnotations;
using OnlineShop.Database.Models;

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

        [Required(ErrorMessage = "Необходимо согласие")]
        public bool Agree { get; set; }

    }
}
