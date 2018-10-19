using System.Threading.Tasks;
using Harvest.Net.Models;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient
    {
        Account WhoAmI();

        Task<Account> WhoAmIAsync();
    }
}
