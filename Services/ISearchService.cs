using shoestore_listing_aspnetcore.Indexes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace shoestore_listing_aspnetcore.Services
{
    public interface ISearchService
    {
        Task<IEnumerable<Product>> SearchAsync(string query);
    }
}