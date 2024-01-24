using auftragsverwaltungs_service.Model.Entities.Dto;

namespace auftragsverwaltungs_service.Service.Milestone;

public interface IMilestoneService
{
    Task<MilestoneDto> CreateMilestone(MilestoneDto milestoneDto);
    Task DeleteMilestone(Guid id);
    Task<IEnumerable<MilestoneDto>> GetAllMilestones();
    Task<MilestoneDto> GetMilestoneById(Guid id);
    Task<MilestoneDto> UpdateMilestone(Guid id, MilestoneDto milestoneDto);
}