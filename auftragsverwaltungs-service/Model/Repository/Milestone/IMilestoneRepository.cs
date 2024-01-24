
using auftragsverwaltung_service.Model.Entities.Dto;

namespace auftragsverwaltung_service.Model.Repository.Milestone;

public interface IMilestoneRepository
{
    Task<Entities.Milestone> CreateMilestone(Entities.Milestone milestone);
    Task DeleteMilestone(Entities.Milestone milestone);
    Task<IEnumerable<Entities.Milestone>> GetAllMilestones();
    Task<Entities.Milestone> GetMilestoneById(Guid id);
    Task<Entities.Milestone> UpdateMilestone(Entities.Milestone milestone);
}