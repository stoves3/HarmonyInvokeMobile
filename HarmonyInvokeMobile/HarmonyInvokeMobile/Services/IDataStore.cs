using HarmonyInvokeMobile.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HarmonyInvokeMobile.Services
{
    public interface IDataStore<T>
    {
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh);
    }
}
