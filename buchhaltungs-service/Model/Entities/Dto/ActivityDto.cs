using auftragsverwaltung_service.Model.Entities.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace buchhaltungs_service.Model.Entities.Dto
{

    public class ActivityDto : BaseDto
    {
        public Guid InvoiceId { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
