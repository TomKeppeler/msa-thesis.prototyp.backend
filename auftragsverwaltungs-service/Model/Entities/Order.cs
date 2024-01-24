using auftragsverwaltungs_service.Model.Entities.Common;
using buchhaltungs_service.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace auftragsverwaltungs_service.Model.Entities
{

    public class Order : BaseEntity
    {

        [Required]
        public Guid TeamId { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }

        public Guid OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public Employee Owner { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [Required, MaxLength(250)]
        public string Name { get; set; }

        public double Volume { get; set; }

        public IEnumerable<Invoice> Invoices { get; set; }

        public IEnumerable<Milestone> Milestones { get; set; }


        [MaxLength(50)]
        public string Description { get; set; }

    }
}