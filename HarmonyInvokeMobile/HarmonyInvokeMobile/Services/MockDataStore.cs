using HarmonyInvokeMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarmonyInvokeMobile.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Rom = "1942 (HB)", ImageSource = "1942 (HB).png", Bankswitch = "F8" },
                new Item { Id = Guid.NewGuid().ToString(), Rom = "Acid Drop", ImageSource = "Acid Drop.png", Bankswitch = "F4" },
                new Item { Id = Guid.NewGuid().ToString(), Rom = "Amidar", ImageSource = "Amidar.png", Bankswitch = "FE" },
                new Item { Id = Guid.NewGuid().ToString(), Rom = "Amoeba Jump (HB)", ImageSource = "Amoeba Jump (HB).png", Bankswitch = "FE" },
                new Item { Id = Guid.NewGuid().ToString(), Rom = "Aquaventure", ImageSource = "Aquaventure.png", Bankswitch = "F8" },
                new Item { Id = Guid.NewGuid().ToString(), Rom = "Artillery Duel", ImageSource = "Artillery Duel.png", Bankswitch = "F4" }
            };
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}