using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace buchhaltungs_service.Model.Entities.Common;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Column(TypeName = "DATETIME")]
    public DateTime CreatedOn { get; set; }

    [Column(TypeName = "DATETIME")]
    public DateTime ModifiedOn { get; set; }

}