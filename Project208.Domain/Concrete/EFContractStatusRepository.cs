using Project208.Domain.Abstract;
using System.Collections.Generic;
using Project208.Domain.Entities;
using System.Linq;

namespace Project208.Domain.Concrete
{
    public class EFContractStatusRepository : IContractStatusRepository
    {
        private EFDbContext context;

        public EFContractStatusRepository(EFDbContext ctx)
        {
            context = ctx;
        }
    }
}
