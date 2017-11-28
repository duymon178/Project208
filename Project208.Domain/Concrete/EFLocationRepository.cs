using Project208.Domain.Abstract;
using Project208.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Project208.Domain.Concrete
{
    public class EFLocationRepository : ILocationRepository
    {
        private EFDbContext context;

        public EFLocationRepository(EFDbContext ctx)
        {
            context = ctx;
        }

        public async Task<int> LocationsCountAsync()
            => await context.Locations.CountAsync();

        public async Task<Location> GetLocationByIdAsync(int locationId)
            => await context.Locations.AsNoTracking().FirstOrDefaultAsync(l => l.LocationId == locationId);
    }
}
