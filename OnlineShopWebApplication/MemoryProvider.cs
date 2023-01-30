using System.IO;

namespace OnlineShopWebApplication
{
    public class MemoryProvider : IMemoryProvider
    {
        public ICartStorage cartStorage;
        public MemoryProvider(ICartStorage cartStorage)
        {
            this.cartStorage = cartStorage;
        }
        readonly string Path = "order.txt";

        public async void WriteOrderToFile()
        {
            var userOrder = cartStorage.TryGetByUserId(Constants.UserId).CartItems;
            var userOrderString = $"{string.Join("",userOrder)}";
            using StreamWriter writer = new StreamWriter(Path, false);
            await writer.WriteLineAsync($"{Constants.UserId}:\n{userOrderString}");
        }
    }
}
