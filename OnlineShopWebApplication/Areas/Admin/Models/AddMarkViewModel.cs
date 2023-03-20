using Microsoft.Build.Framework;

namespace OnlineShopWebApplication.Areas.Admin.Models
{
    public class AddMarkViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
