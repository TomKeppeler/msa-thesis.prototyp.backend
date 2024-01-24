


using buchhaltungs_service.Model.Entities.Dto;

namespace buchhaltungs_service.Model.Repository.Invoice
{
    public interface IInvoiceRepository
    {
        Task<Entities.Invoice> CreateInvoice(Entities.Invoice invoice);
        Task DeleteInvoice(Guid id);
        Task<IEnumerable<Entities.Invoice>> GetAllInvoices();
        Task<Entities.Invoice> GetInvoiceById(Guid id);
        Task<Entities.Invoice> UpdateInvoice(Guid id, Entities.Invoice invoice);
    }
}
