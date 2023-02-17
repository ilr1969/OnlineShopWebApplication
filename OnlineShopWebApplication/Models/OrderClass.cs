﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApplication.Models
{
    public class OrderClass
    {
        public Guid Id { get; set; }
        public static int OrderCounter = 0;
        public int OrderNumber { get; set; }

        [Required(ErrorMessage = "Укажите имя получателя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите адрес доставки")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Укажите телефон для связи")]
        public string Phone { get; set; }
        public string Status { get; set; }
        public DateTime CreationDatetime { get; set; }

        [Required(ErrorMessage = "Необходимо согласие")]
        public bool Agree { get; set; }

        public CartClass userCart { get; set; }
        public OrderClass()
        {
            Id = Guid.NewGuid();
            OrderCounter++;
            OrderNumber = OrderCounter;
            Status = "Создан";
            CreationDatetime = DateTime.Now;
        }
    }
}
