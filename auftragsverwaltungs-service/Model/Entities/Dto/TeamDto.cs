using System.Collections.ObjectModel;

namespace auftragsverwaltungs_service.Model.Entities.Dto;

public class TeamDto : BaseDto
{
    public string Name { get; set; }
    public Collection<Order> Orders { get; set; }
}