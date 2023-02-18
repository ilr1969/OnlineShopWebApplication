using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication.Helpers
{
    public class EnumHelper
    {
        public static string GetEnumDiaplayName(OrderStatus status)
        {
            return status.GetType().GetMember(status.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName();
        }
    }
}
