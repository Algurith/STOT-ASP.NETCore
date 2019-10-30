using CCR.Echo.MiniWeb.Persistence.Models;
using System.Linq;

namespace CCR.Echo.MiniWeb.Persistence.Abstractions
{
    public interface ICountryRepository
    {
        IQueryable<Country> All();

        Country Find(string code);

        IQueryable<Country> AllBy(string filter);
    }
}
