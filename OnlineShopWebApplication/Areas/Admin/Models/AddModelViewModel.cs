using Microsoft.Build.Framework;
using OnlineShop.Database.Models;
using System.Collections.Generic;

namespace OnlineShopWebApplication.Areas.Admin.Models
{
    public class AddModelViewModel
    {
        [Required]
        public string Name { get; set; }

        public string MarkName { get; set; }
        public List<Mark> Marks { get; set; }
    }
}
