using Project208.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Project208.Domain.Entities;
using System.Linq;

namespace Project208.Domain.Concrete
{
    public class EFT2PaymentDetailRepository : IT2PaymentDetailRepository
    {
        private EFDbContext context;

        public EFT2PaymentDetailRepository(EFDbContext ctx)
        {
            context = ctx;
        }
    }
}
