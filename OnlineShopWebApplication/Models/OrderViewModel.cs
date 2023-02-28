using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApplication.Models
{
    public class OrderViewModel
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
        public OrderStatusViewModel Status { get; set; }
        public DateTime CreationDatetime { get; set; }

        [Required(ErrorMessage = "Необходимо согласие")]
        public bool Agree { get; set; }

        public CartViewModel userCart { get; set; }
        public OrderViewModel()
        {
            Id = Guid.NewGuid();
            OrderCounter++;
            Status = OrderStatusViewModel.Created;
            OrderNumber = OrderCounter;
            CreationDatetime = DateTime.Now;
        }
    }
}
