namespace buchhaltungs_service.Model.Repository.Common;

public class RepositoryBase : IRepositoryBase
{
    public BuchhaltungsContext Context { get; set; }
    
    public RepositoryBase(BuchhaltungsContext context)
    {
        Context = context;
    }
    
    public async Task<int> SaveAsync()
    {
        return await Context.SaveChangesAsync();
    }

    public async Task RunInTransaction(Func<Task> action)
    {
        await using var transaction = await Context.Database.BeginTransactionAsync();
        
    }
}