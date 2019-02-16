using Mess.Core;

namespace Mess.Persistence
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly MessDbContext _context;

        public UnitOfWork(MessDbContext context)
        {
            _context = context;
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void CompleteAsync(){
            _context.SaveChangesAsync();
        }
    }
}