namespace Mess.Core
{
    public interface IUnitOfWork
    {
         void Complete();
         void CompleteAsync();
    }
}