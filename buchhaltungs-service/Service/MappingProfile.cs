using auftragsverwaltung_service.Model.Entities.Dto;
using AutoMapper;
using buchhaltungs_service.Model.Entities.Dto;

namespace buchhaltungs_service.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model.Entities.Activity, ActivityDto>().ReverseMap();
            CreateMap<Model.Entities.Employee, EmployeeDto>().ReverseMap();
            CreateMap<Model.Entities.Invoice, InvoiceDto>().ReverseMap();
        }
    }
}