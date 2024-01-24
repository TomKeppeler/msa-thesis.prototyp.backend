using buchhaltungs_service.Model.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace buchhaltungs_service.Model.Entities
{
    // ToDo: add attribute Iteration from abrechnungs-service
    public class Activity : BaseEntity
    {
        /// <summary>
        /// Die Rechnung zu der die Aktivität gehört
        /// </summary>
        public Guid? InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Der zu zahlende Preis für die Aktivität pro Stunde
        /// </summary>
        public double Price { get; set; }
    }
}
