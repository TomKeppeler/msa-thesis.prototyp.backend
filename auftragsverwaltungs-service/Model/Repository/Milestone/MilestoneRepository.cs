using auftragsverwaltungs_service.Model.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace auftragsverwaltungs_service.Model.Repository.Milestone;

public class MilestoneRepository : RepositoryBase, IMilestoneRepository
{
    public MilestoneRepository(AuftragsverwaltungsContext context) : base(context)
    {
    }
    public async Task<Entities.Milestone> CreateMilestone(Entities.Milestone milestone)
    {
        Context.Milestone.Add(milestone);
        await SaveAsync();
        return milestone;
    }

    public async Task DeleteMilestone(Entities.Milestone milestone)
    {
        Context.Milestone.Remove(milestone);
        await SaveAsync();
    }

    public async Task<IEnumerable<Entities.Milestone>> GetAllMilestones()
    {
        return await Context.Milestone.ToListAsync();
    }

    public async Task<Entities.Milestone> GetMilestoneById(Guid id)
    {
        return await Context.Milestone.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Entities.Milestone> UpdateMilestone(Entities.Milestone milestone)
    {
        Context.Milestone.Update(milestone);
        await SaveAsync();
        return milestone;
    }
}