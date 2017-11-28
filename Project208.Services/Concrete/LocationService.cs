using Project208.Domain.Abstract;
using Project208.Domain.Entities;
using Project208.Services.Abstract;
using System.Threading.Tasks;

namespace Project208.Services.Concrete
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository locationRepository;

        public LocationService(ILocationRepository locationRepoParam)
        {
            locationRepository = locationRepoParam;
        }

        public async Task<int> LocationsCountAsync() => await locationRepository.LocationsCountAsync();

        public async Task<Location> GetLocationByIdAsync(int locationId) => await locationRepository.GetLocationByIdAsync(locationId);
    }
}
