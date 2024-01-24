
using auftragsverwaltung_service.Model.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace auftragsverwaltung_service.Controllers.Milestone;

public interface IMilestoneService
{
    Task<MilestoneDto> CreateMilestone(MilestoneDto milestoneDto);
    Task DeleteMilestone(Guid id);
    Task<IEnumerable<MilestoneDto>> GetAllMilestones();
    Task<MilestoneDto> GetMilestoneById(Guid id);
    Task<MilestoneDto> UpdateMilestone(Guid id, MilestoneDto milestoneDto);
}