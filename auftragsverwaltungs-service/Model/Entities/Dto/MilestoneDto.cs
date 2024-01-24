namespace auftragsverwaltungs_service.Model.Entities.Dto;

public class MilestoneDto : BaseDto
{
    public Guid OrderId { get; set; }

    public string Name { get; set; }

    public double? Volume { get; set; }

    public StatusDto State { get; set; }

    public DateTime CompletedOn { get; set; }
    public enum StatusDto
    {
        Billed,
        Open,
        Active
    }
}