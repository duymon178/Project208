using Project208.Domain.Entities;
using System.Threading.Tasks;

namespace Project208.Domain.Abstract
{
    public interface ILocationRepository
    {
        Task<int> LocationsCountAsync();
        Task<Location> GetLocationByIdAsync(int locationId);
    }
}
