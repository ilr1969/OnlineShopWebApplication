using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApplication.Areas.Admin.Models
{
    public class AddProductViewModel
    {
        public Guid ID { get; set; }

        public string Mark { get; set; }

        public List<MarkViewModel> Marks { get; set; }

        public string Model { get; set; }

        public List<ModelViewModel> Models { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string Description { get; set; }

        public IFormFile FileToUpload { get; set; }
        public AddProductViewModel()
        {
            ID = Guid.NewGuid();
        }
    }
}
