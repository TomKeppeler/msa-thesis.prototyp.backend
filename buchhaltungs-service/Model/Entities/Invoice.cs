using buchhaltungs_service.Model.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace buchhaltungs_service.Model.Entities
{
    public class Invoice : BaseEntity
    {
        /*ToDo: Aus Auftragsverwaltungs-Service 
         * public Guid SalesorderId { get; set; }

              [ForeignKey("SalesorderId")]
              public Salesorder Salesorder { get; set; }
      */
        [Column(TypeName = "DATETIME")]
        public DateTime? InvoicedOn { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime? PlannedInvoicedOn { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime? PaidOn { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime? PaymentTarget { get; set; }

        [MaxLength(450), NotNull]
        public required string InvoiceText { get; set; }
    }
}
