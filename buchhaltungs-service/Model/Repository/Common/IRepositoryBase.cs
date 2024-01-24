namespace buchhaltungs_service.Model.Repository.Common;

public interface IRepositoryBase
{
    BuchhaltungsContext Context { get; set; }
    
    Task<int> SaveAsync();
    
    Task RunInTransaction(Func<Task> action);
}