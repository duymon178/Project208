using Project208.Domain.Abstract;

namespace Project208.Domain.Concrete
{
    public class EFNoteRepository : INoteRepository
    {
        private EFDbContext context;

        public EFNoteRepository(EFDbContext ctx)
        {
            context = ctx;
        }
    }
}
