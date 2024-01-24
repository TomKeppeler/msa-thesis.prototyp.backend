using auftragsverwaltungs_service.Model.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace auftragsverwaltungs_service.Model.Entities;

public class Milestone : BaseEntity
{
    public Guid OrderId { get; set; }

    [ForeignKey("OrderId")]
    public Order Order { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    public double? Volume { get; set; }

    public Status State { get; set; }

    [Column(TypeName = "DATE")]
    public DateTime CompletedOn { get; set; }


    public enum Status
    {
        Billed,
        Open,
        Active
    }
}