using auftragsverwaltung_service.Model.Entities;
using auftragsverwaltung_service.Model.Entities.Dto;
using AutoMapper;

namespace auftragsverwaltung_service.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model.Entities.Customer, CustomerDto>().ReverseMap();
            CreateMap<Milestone, MilestoneDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Team, TeamDto>().ReverseMap();
        }
    }
}