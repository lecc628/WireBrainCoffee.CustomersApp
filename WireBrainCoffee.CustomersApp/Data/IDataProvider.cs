using System.Collections.Generic;
using System.Threading.Tasks;

namespace WireBrainCoffee.CustomersApp.Data
{
    public interface IDataProvider<TItem>
    {
        Task<IEnumerable<TItem>?> GetAllAsync();
    }
}
