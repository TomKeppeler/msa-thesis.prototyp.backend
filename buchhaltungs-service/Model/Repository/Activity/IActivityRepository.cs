


namespace buchhaltungs_service.Model.Repository.Activity
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Entities.Activity>> GetAllActivities();
        Task<Entities.Activity> CreateActivity(Entities.Activity activity);
        Task<Entities.Activity> GetActivityById(Guid id);
        Task<Entities.Activity> UpdateActivity(Entities.Activity activity);
        Task DeleteActivity(Entities.Activity activity);
    }
}
