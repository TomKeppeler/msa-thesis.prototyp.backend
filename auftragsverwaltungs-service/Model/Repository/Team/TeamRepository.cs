using auftragsverwaltungs_service.Model.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace auftragsverwaltungs_service.Model.Repository.Team;

public class TeamRepository : RepositoryBase, ITeamRepository
{
    public TeamRepository(AuftragsverwaltungsContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Entities.Team>> GetAllTeams()
    {
        return await Context.Team.ToListAsync();
    }

    public async Task<Entities.Team> GetTeamById(Guid id)
    {
        return await Context.Team.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Entities.Team> CreateTeam(Entities.Team team)
    {
        await Context.Team.AddAsync(team);
        await SaveAsync();
        return team;
    }

    public async Task<Entities.Team> UpdateTeam(Entities.Team team)
    {
        Context.Team.Update(team);
        await SaveAsync();
        return team;
    }

    public async Task DeleteTeam(Entities.Team team)
    {
        Context.Team.Remove(team);
        await SaveAsync();
    }

}