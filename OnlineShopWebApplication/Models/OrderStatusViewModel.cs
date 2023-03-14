using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApplication.Models
{
    public enum OrderStatusViewModel
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