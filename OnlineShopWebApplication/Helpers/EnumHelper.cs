using OnlineShopWebApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace OnlineShopWebApplication.Helpers
{
    public class EnumHelper
    {
        public static string GetEnumDiaplayName(OrderStatusViewModel status)
        {
            return status.GetType().GetMember(status.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName();
        }
    }
}
