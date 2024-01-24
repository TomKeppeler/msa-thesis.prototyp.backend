using auftragsverwaltungs_service.Model.Entities.Dto;
using auftragsverwaltungs_service.Model.Repository.Milestone;
using AutoMapper;

namespace auftragsverwaltungs_service.Service.Milestone;

public class MilestoneService : IMilestoneService
{
    private readonly IMilestoneRepository _milestoneRepository;
    private readonly IMapper _mapper;

    public MilestoneService(IMilestoneRepository milestoneRepository, IMapper mapper)
    {
        _milestoneRepository = milestoneRepository;
        _mapper = mapper;
    }

    public async Task<MilestoneDto> CreateMilestone(MilestoneDto milestoneDto)
    {
        var milestone = _mapper.Map<Model.Entities.Milestone>(milestoneDto);
        milestone = await _milestoneRepository.CreateMilestone(milestone);
        return _mapper.Map<MilestoneDto>(milestone);
    }

    public async Task DeleteMilestone(Guid id)
    {
        var milestone = await _milestoneRepository.GetMilestoneById(id);
        await _milestoneRepository.DeleteMilestone(milestone);
    }

    public async Task<IEnumerable<MilestoneDto>> GetAllMilestones()
    {
        var milestones = await _milestoneRepository.GetAllMilestones();
        return _mapper.Map<IEnumerable<MilestoneDto>>(milestones);
    }

    public Task<MilestoneDto> GetMilestoneById(Guid id)
    {
        var milestone = _milestoneRepository.GetMilestoneById(id);
        return _mapper.Map<Task<MilestoneDto>>(milestone);
    }

    public Task<MilestoneDto> UpdateMilestone(Guid id, MilestoneDto milestoneDto)
    {
        var milestone = _mapper.Map<Model.Entities.Milestone>(milestoneDto);
        var milestoneFromDb = _milestoneRepository.GetMilestoneById(id);
        if (milestoneFromDb == null)
        {
            throw new ArgumentException("Milestone: " + id + " not found");
        }
        var updatedMilestone = _milestoneRepository.UpdateMilestone(milestone);
        return _mapper.Map<Task<MilestoneDto>>(updatedMilestone);
    }
}