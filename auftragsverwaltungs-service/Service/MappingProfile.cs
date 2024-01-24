using auftragsverwaltungs_service.Model.Entities.Dto;
using AutoMapper;

namespace auftragsverwaltungs_service.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model.Entities.Customer, CustomerDto>().ReverseMap();
            CreateMap<Model.Entities.Milestone, MilestoneDto>().ReverseMap();
            CreateMap<Model.Entities.Order, OrderDto>().ReverseMap();
            CreateMap<Model.Entities.Team, TeamDto>().ReverseMap();
        }
    }
}