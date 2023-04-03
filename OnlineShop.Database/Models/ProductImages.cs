using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Database.Models
{
    public class ProductImages : Base
    {
        public string Name { get; set; }
        public Guid ProductId { get; set; }
        [Timestamp]
        public byte[] ConcurrencyToken { get; set; }
        public ProductImages(Guid id, string name, Guid productId)
        {
            Id = id;
            Name = name;
            ProductId = productId;
            CreationDateTime = DateTime.Now;
        }
        public ProductImages()
        {
            CreationDateTime = DateTime.Now;
        }
    }
}
