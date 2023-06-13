namespace Formula_Api.Core
{
    public interface IUnitOfWork
    {
        IDriverRepository Drivers { get; }

        Task CompleteAsync();
    }
}