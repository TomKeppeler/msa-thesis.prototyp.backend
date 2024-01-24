using auftragsverwaltungs_service.Model.Entities.Dto;

namespace auftragsverwaltungs_service.Service.Team;

public interface ITeamService
{
    Task<TeamDto> CreateTeam(TeamDto teamDto);
    Task DeleteTeam(Guid id);
    Task<IEnumerable<TeamDto>> GetAllTeams();
    Task<TeamDto> GetTeamById(Guid id);
    Task<TeamDto> UpdateTeam(Guid id, TeamDto teamDto);
}