using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApi.Models
{
    public enum OrderStatusModel
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