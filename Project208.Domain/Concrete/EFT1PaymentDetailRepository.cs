using Project208.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Project208.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Project208.Domain.Concrete
{
    public class EFT1PaymentDetailRepository : IT1PaymentDetailRepository
    {
        private EFDbContext context;

        public EFT1PaymentDetailRepository(EFDbContext ctx)
        {
            context = ctx;
        }
    }
}
