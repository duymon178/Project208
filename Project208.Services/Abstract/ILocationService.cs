using Project208.Domain.Entities;
using System.Threading.Tasks;

namespace Project208.Services.Abstract
{
    public interface ILocationService
    {
        Task<int> LocationsCountAsync();
        Task<Location> GetLocationByIdAsync(int locationId);
    }
}
