namespace auftragsverwaltungs_service.Model.Repository.Common;

public interface IRepositoryBase
{
    AuftragsverwaltungsContext Context { get; set; }

    Task<int> SaveAsync();

    Task RunInTransaction(Func<Task> action);
}