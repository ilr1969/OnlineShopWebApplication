using System;
using System.Collections.Generic;

namespace OnlineShopWebApplication.Models
{
    public class OrderClass
    {
        public Guid Id { get; set; }
        public static int OrderCounter = 0;
        public int OrderNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public DateTime CreationDatetime { get; set; }
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
