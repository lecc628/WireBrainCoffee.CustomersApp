using System.Collections.Generic;
using System.Threading.Tasks;
using WireBrainCoffee.CustomersApp.Model;

namespace WireBrainCoffee.CustomersApp.Data
{
    public class ProductDataProvider : IDataProvider<Product>
    {
        public async Task<IEnumerable<Product>?> GetAllAsync()
        {
            await Task.Delay(1000);  // Simulates a bit of server work. 

            return new List<Product>
            {
                new Product{ Name = "Cappuccino", Description = "Espresso with milk and milk foam" },
                new Product{ Name = "Doppio", Description = "Double espresso" },
                new Product{ Name = "Espresso", Description = "Pure coffee to keep you awake! :-)" },
                new Product{ Name = "Latte", Description = "Cappuccino with more streamed milk" },
                new Product{ Name = "Macchiato", Description = "Espresso with milk foam" },
                new Product{ Name = "Mocha", Description = "Espresso with hot chocolate and milk foam" }
            };
        }
    }
}
