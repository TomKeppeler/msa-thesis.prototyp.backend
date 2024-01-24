using auftragsverwaltung_service.Controllers.Team;
using auftragsverwaltung_service.Model.Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace auftragsverwaltungs_service.Controller;

[ApiController]
[Route("api/teams")]
public class TeamController : ControllerBase
{
    private readonly ITeamService _teamService;

    public TeamController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeamDto>>> GetAllTeams()
    {
        var teams = await _teamService.GetAllTeams();
        return Ok(teams);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TeamDto>> GetTeamById(Guid id)
    {
        var team = await _teamService.GetTeamById(id);
        return Ok(team);
    }

    [HttpPost]
    public async Task<ActionResult<TeamDto>> CreateTeam(TeamDto teamDto)
    {
        var team = await _teamService.CreateTeam(teamDto);
        return Ok(team);
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<TeamDto>> UpdateTeam(Guid id, TeamDto teamDto)
    {
        var team = await _teamService.UpdateTeam(id, teamDto);
        return Ok(team);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTeam(Guid id)
    {
        await _teamService.DeleteTeam(id);
        return Ok();
    }
}