using Microsoft.AspNetCore.Mvc;
using OnlineShop.Database.Interfaces;
using OnlineShop.Database.Models;

namespace OnlineShopWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrderController : Controller
    {
        public IOrderStorage orderStorage;

        public OrderController(IOrderStorage orderStorage)
        {
            this.orderStorage = orderStorage;
        }

        [HttpGet("GetOderDetails")]
        public Order Detail(int orderNumber)
        {
            return orderStorage.TryGetByNumber(orderNumber);
        }
    }
}
