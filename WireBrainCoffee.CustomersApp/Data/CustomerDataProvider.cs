using System.Collections.Generic;
using System.Threading.Tasks;
using WireBrainCoffee.CustomersApp.Model;

namespace WireBrainCoffee.CustomersApp.Data
{
    public class CustomerDataProvider : IDataProvider<Customer>
    {
        public async Task<IEnumerable<Customer>?> GetAllAsync()
        {
            await Task.Delay(1000);  // Simulates a bit of server work. 

            return new List<Customer>
            {
                new Customer{ Id = 1, FirstName = "Julia", LastName = "Developer", IsDeveloper = true },
                new Customer{ Id = 2, FirstName = "Alex", LastName = "Rider" },
                new Customer{ Id = 3, FirstName = "Thomas Claudius", LastName = "Huber", IsDeveloper = true },
                new Customer{ Id = 4, FirstName = "Anna", LastName = "Rockstar" },
                new Customer{ Id = 5, FirstName = "Sara", LastName = "Metroid" },
                new Customer{ Id = 6, FirstName = "Ben", LastName = "Ronaldo" }
            };
        }
    }
}
