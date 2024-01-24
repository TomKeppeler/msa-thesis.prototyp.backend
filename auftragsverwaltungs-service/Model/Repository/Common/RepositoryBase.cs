namespace auftragsverwaltungs_service.Model.Repository.Common;

public class RepositoryBase : IRepositoryBase
{
    public AuftragsverwaltungsContext Context { get; set; }

    public RepositoryBase(AuftragsverwaltungsContext context)
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