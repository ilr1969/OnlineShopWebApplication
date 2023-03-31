namespace OnlineShopWebApi.Areas.Admin.Models
{
    public class AddUserModel
    {
        public string? UserName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Description { get; set; }
    }
}
