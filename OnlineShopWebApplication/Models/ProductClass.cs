namespace OnlineShopWebApplication.Models
{
    public class ProductClass
    {
        private static int ID_counter = 1;
        public int ID;
        public string Name;
        public decimal Cost;
        public string Description;

        public ProductClass(string name, int cost, string descr)
        {
            ID = ID_counter;
            Name = name;
            Cost = cost;
            Description = descr;
            ID_counter++;
        }

        public override string ToString()
        {
            return $"{ID}\n{Name}\n{Cost}\n{Description}".ToString();
        }
    }
}
