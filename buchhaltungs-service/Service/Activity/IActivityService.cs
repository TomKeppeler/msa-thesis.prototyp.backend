using buchhaltungs_service.Model.Entities.Dto;

namespace buchhaltungs_service.Service.Activity
{
    public interface IActivityService
    {
        Task<IEnumerable<ActivityDto>> GetAllActivities();
        Task<ActivityDto> CreateActivity(ActivityDto activityDto);
        Task<ActivityDto> UpdateActivity(Guid id, ActivityDto activityDto);
        Task DeleteActivity(Guid id);
        Task<ActivityDto> GetActivityById(Guid id);
    }
}
