using auftragsverwaltungs_service.Model.Entities.Dto;
using auftragsverwaltungs_service.Model.Repository.Team;
using AutoMapper;

namespace auftragsverwaltungs_service.Service.Team;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;
    private readonly IMapper _mapper;

    public TeamService(ITeamRepository teamRepository, IMapper mapper)
    {
        _teamRepository = teamRepository;
        _mapper = mapper;
    }

    public async Task<TeamDto> CreateTeam(TeamDto teamDto)
    {
        var team = _mapper.Map<Model.Entities.Team>(teamDto);
        team = await _teamRepository.CreateTeam(team);
        return _mapper.Map<TeamDto>(team);
    }

    public async Task DeleteTeam(Guid id)
    {
        var team = await _teamRepository.GetTeamById(id);
        await _teamRepository.DeleteTeam(team);
    }

    public async Task<IEnumerable<TeamDto>> GetAllTeams()
    {
        var teams = await _teamRepository.GetAllTeams();
        return _mapper.Map<IEnumerable<TeamDto>>(teams);
    }

    public Task<TeamDto> GetTeamById(Guid id)
    {
        var team = _teamRepository.GetTeamById(id);
        return _mapper.Map<Task<TeamDto>>(team);
    }

    public Task<TeamDto> UpdateTeam(Guid id, TeamDto teamDto)
    {
        var team = _mapper.Map<Model.Entities.Team>(teamDto);
        var teamFromDb = _teamRepository.GetTeamById(id);
        if (teamFromDb == null)
        {
            throw new ArgumentException("Team: " + id + " not found");
        }
        var updatedTeam = _teamRepository.UpdateTeam(team);
        return _mapper.Map<Task<TeamDto>>(updatedTeam);
    }
}