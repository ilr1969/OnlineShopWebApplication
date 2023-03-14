using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Database.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Создан")]
        Created,
        [Display(Name = "Обработан")]
        Proceed,
        [Display(Name = "В доставке")]
        Delivery,
        [Display(Name = "Выполнен")]
        Completed,
        [Display(Name = "Отменён")]
        Cancelled
    }
}