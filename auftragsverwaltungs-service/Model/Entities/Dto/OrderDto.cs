using buchhaltungs_service.Model.Entities;

namespace auftragsverwaltungs_service.Model.Entities.Dto;

public class OrderDto : BaseDto
{
    public Guid TeamId { get; set; }

    public Guid OwnerId { get; set; }

    public IEnumerable<Invoice> Invoices { get; set; }

    public IEnumerable<Milestone> Milestones { get; set; }

    public Guid CustomerId { get; set; }

    public string Name { get; set; }

    public double Volume { get; set; }

    public string Description { get; set; }
}