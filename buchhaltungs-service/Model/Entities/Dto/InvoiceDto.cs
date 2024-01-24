using auftragsverwaltung_service.Model.Entities.Dto;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace buchhaltungs_service.Model.Entities.Dto
{
    public class InvoiceDto : BaseDto
    {
        /*ToDo: Aus Auftragsverwaltungs-Service 
 * public Guid SalesorderId { get; set; }

      [ForeignKey("SalesorderId")]
      public Salesorder Salesorder { get; set; }
*/
        public DateTime? InvoicedOn { get; set; }

        public DateTime? PlannedInvoicedOn { get; set; }

        public DateTime? PaidOn { get; set; }

        public DateTime? PaymentTarget { get; set; }

        public required string InvoiceText { get; set; }
    }
}
