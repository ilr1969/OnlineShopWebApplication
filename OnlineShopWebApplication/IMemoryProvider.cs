namespace OnlineShopWebApplication
{
    public interface IMemoryProvider
    {
        static string Path;

        public void WriteOrderToFile();
    }
}
