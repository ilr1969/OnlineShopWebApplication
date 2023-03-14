using System;

namespace OnlineShop.Database.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Image(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Image()
        {

        }
    }
}
