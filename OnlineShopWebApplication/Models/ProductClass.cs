namespace OnlineShopWebApplication.Models
{
    public class ProductClass
    {
        private static int ID_counter = 1;
        public int ID;
        public string Name;
        public decimal Cost;
        public string Description;
        public string ImagePath;

        public ProductClass(string name, int cost, string descr, string imagePath)
        {
            ID = ID_counter;
            Name = name;
            Cost = cost;
            Description = descr;
            ID_counter++;
            ImagePath = imagePath;
        }

        public override string ToString()
        {
            return $"{ID}\n{Name}\n{Cost}\n{Description}".ToString();
        }
    }
}
