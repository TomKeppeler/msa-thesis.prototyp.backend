using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace auftragsverwaltung_service.Model.Entities.Dto;

public class TeamDto : BaseDto
{
    public string Name { get; set; }
    public Collection<Order> Orders { get; set; }
}