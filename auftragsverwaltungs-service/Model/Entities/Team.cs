using auftragsverwaltung_service.Model.Entities.Common;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace auftragsverwaltung_service.Model.Entities
{

    public class Team : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public Collection<Order> Orders { get; set; }
    }
}