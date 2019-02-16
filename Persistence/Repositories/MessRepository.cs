using Mess.Core.Repositories;
using Mess.Models;

namespace Mess.Persistence.Repositories
{
    public class MessRepository:BaseRepository<SmartMess>,IMessRepository
    {
        public MessRepository(MessDbContext context)
        :base(context)
        {}
    }
}