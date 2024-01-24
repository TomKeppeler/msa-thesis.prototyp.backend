


namespace auftragsverwaltung_service.Model.Repository.Team;

public interface ITeamRepository
{
    Task<Entities.Team> CreateTeam(Entities.Team team);
    Task DeleteTeam(Entities.Team team);
    Task<IEnumerable<Entities.Team>> GetAllTeams();
    Task<Entities.Team> GetTeamById(Guid id);
    Task<Entities.Team> UpdateTeam(Entities.Team team);
}