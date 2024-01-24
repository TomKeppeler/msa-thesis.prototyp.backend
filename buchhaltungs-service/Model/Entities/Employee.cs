using buchhaltungs_service.Model.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace buchhaltungs_service.Model.Entities
{
    public class Employee : BaseEntity
    {
        [Required, MaxLength(250)]
        public string Name { get; set; }

        [Required, MaxLength(450)]
        public string Email { get; set; }
        /*
         * ToDo: add attributes from abrechnungs-service und auftragsverwaltung-service
        public Collection<Capacity> Capacities { get; set; } -> Abrechnungsservice
        public Collection<Salesorder> Salesorders { get; set; } -> Auftragsverwaltungsservice
         */
    }
}
