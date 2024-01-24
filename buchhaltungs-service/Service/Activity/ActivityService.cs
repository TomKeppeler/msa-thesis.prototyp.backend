using AutoMapper;
using buchhaltungs_service.Model.Entities.Dto;
using buchhaltungs_service.Model.Repository.Activity;

namespace buchhaltungs_service.Service.Activity
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository activityRepository;
        private readonly IMapper mapper;

        public ActivityService(IActivityRepository activityRepository, IMapper mapper)
        {
            this.activityRepository = activityRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ActivityDto>> GetAllActivities()
        {
            return mapper.Map<IEnumerable<ActivityDto>>(await activityRepository.GetAllActivities());
        }

        public async Task<ActivityDto> CreateActivity(ActivityDto activityDto)
        {
            var activity = mapper.Map<Model.Entities.Activity>(activityDto);
            activity = await activityRepository.CreateActivity(activity);
            return mapper.Map<ActivityDto>(activity);
        } 

        public async Task<ActivityDto> UpdateActivity(Guid id, ActivityDto activityDto)
        {
            var activity = mapper.Map<Model.Entities.Activity>(activityDto);
            var activityFromDb = await activityRepository.GetActivityById(id);
            if (activityFromDb == null)
            {
                throw new ArgumentException("Activity: " + id + " not found");
            }
            var updatedActivity = await activityRepository.UpdateActivity(activity);
            return mapper.Map<ActivityDto>(updatedActivity);
        }

        public async Task DeleteActivity(Guid id)
        {
            var activity = await activityRepository.GetActivityById(id);
            await this.activityRepository.DeleteActivity(activity);
        }

        public async Task<ActivityDto> GetActivityById(Guid id)
        {
            var activity = await activityRepository.GetActivityById(id);
            return mapper.Map<ActivityDto>(activity);
        }
    }
}
