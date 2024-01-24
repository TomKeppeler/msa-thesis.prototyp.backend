using buchhaltungs_service.Model.Entities.Dto;
using buchhaltungs_service.Service.Activity;
using Microsoft.AspNetCore.Mvc;

namespace buchhaltungs_service.Controller
{

    [ApiController]
    [Route("api/activities")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService activityService;

        public ActivityController(IActivityService activityService)
        {
            this.activityService = activityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityDto>>> GetAllActivities()
        {
            var activities = await activityService.GetAllActivities();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDto>> GetActivityById([FromRoute()] Guid id)
        {
            var activity = await activityService.GetActivityById(id);
            return Ok(activity);
        }

        [HttpPost]
        public async Task<ActionResult<ActivityDto>> CreateActivity([FromBody] ActivityDto activityDto)
        {
            var activity = await activityService.CreateActivity(activityDto);
            return Ok(activity);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ActivityDto>> UpdateActivity([FromRoute()] Guid id, [FromBody] ActivityDto activityDto)
        {
            var activity = await activityService.UpdateActivity(id, activityDto);
            return Ok(activity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity([FromRoute()] Guid id)
        {
            await activityService.DeleteActivity(id);
            return Ok();
        }
    }
}
