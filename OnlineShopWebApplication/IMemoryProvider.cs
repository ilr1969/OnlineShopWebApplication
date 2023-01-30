namespace OnlineShopWebApplication
{
    public interface IMemoryProvider
    {
        static string Path;

        void WriteOrderToFile();
    }
}
