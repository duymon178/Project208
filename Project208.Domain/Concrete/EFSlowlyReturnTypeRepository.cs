using Project208.Domain.Abstract;

namespace Project208.Domain.Concrete
{
    public class EFSlowlyReturnTypeRepository : ISlowlyReturnTypeRepository
    {
        private EFDbContext context;

        public EFSlowlyReturnTypeRepository(EFDbContext ctx)
        {
            context = ctx;
        }
    }
}
