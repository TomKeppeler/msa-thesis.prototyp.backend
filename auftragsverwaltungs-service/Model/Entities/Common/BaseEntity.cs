using System.ComponentModel.DataAnnotations.Schema;

namespace auftragsverwaltung_service.Model.Entities.Common;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Column(TypeName = "DATETIME")]
    public DateTime CreatedOn { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime ModifiedOn { get; set; }

}