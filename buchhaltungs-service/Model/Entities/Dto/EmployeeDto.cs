using auftragsverwaltung_service.Model.Entities.Dto;
using System.ComponentModel.DataAnnotations;

namespace buchhaltungs_service.Model.Entities.Dto
{
    public class EmployeeDto : BaseDto
    {
        public string Name { get; set; }

        public string Email { get; set; }
        /*
         * ToDo: add attributes from abrechnungs-service und auftragsverwaltung-service
        public Collection<Capacity> Capacities { get; set; } -> Abrechnungsservice
        public Collection<Salesorder> Salesorders { get; set; } -> Auftragsverwaltungsservice
         */
    }
}
