namespace OnlineShopWebApi.Areas.Admin.Models
{
    public class EditProductModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public decimal Cost { get; set; }

        public string? Description { get; set; }
    }
}
