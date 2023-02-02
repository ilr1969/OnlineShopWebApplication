﻿using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OnlineShopWebApplication.Models;

namespace OnlineShopWebApplication
{
    public class MemoryProvider : IMemoryProvider
    {
        public ICartStorage cartStorage;
        public IOrderStorage orderStorage;
        public MemoryProvider(ICartStorage cartStorage, IOrderStorage orderStorage)
        {
            this.cartStorage = cartStorage;
            this.orderStorage = orderStorage;
        }
        

        public async void WriteOrderToFile()
        {
            string orderPath = "order.txt";
            var orderData = orderStorage.GetOrderList();
            using StreamWriter writer = new StreamWriter(orderPath, false);
            await writer.WriteLineAsync(SerializeList(orderData));
        }

        private string SerializeList(object list)
        {
            return JsonConvert.SerializeObject(list);
        }
    }
}
