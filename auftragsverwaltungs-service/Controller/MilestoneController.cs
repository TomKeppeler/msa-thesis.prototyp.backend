using auftragsverwaltungs_service.Model.Entities.Dto;
using auftragsverwaltungs_service.Service.Milestone;
using Microsoft.AspNetCore.Mvc;

namespace auftragsverwaltungs_service.Controller;

[ApiController]
[Route("api/milestones")]
public class MilestoneController : ControllerBase
{
    private readonly IMilestoneService _milestoneService;

    public MilestoneController(IMilestoneService milestoneService)
    {
        _milestoneService = milestoneService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MilestoneDto>>> GetAlllMilestones()
    {
        var milestones = await _milestoneService.GetAllMilestones();
        return Ok(milestones);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MilestoneDto>> GetMilestoneById([FromRoute()] Guid id)
    {
        var milestone = await _milestoneService.GetMilestoneById(id);
        return Ok(milestone);
    }

    [HttpPost]
    public async Task<ActionResult<MilestoneDto>> CreateMilestone([FromBody()] MilestoneDto milestoneDto)
    {
        var milestone = await _milestoneService.CreateMilestone(milestoneDto);
        return Ok(milestone);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<MilestoneDto>> UpdateMilestone([FromRoute()] Guid id, [FromBody()] MilestoneDto milestoneDto)
    {
        var milestone = await _milestoneService.UpdateMilestone(id, milestoneDto);
        return Ok(milestone);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMilestone([FromRoute()] Guid id)
    {
        await _milestoneService.DeleteMilestone(id);
        return Ok();
    }
}