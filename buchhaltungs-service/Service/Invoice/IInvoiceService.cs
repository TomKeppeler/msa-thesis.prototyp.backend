using buchhaltungs_service.Model.Entities.Dto;

namespace buchhaltungs_service.Service.Invoice
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> CreateInvoice(InvoiceDto invoiceDto);
        Task DeleteInvoice(Guid id);
        Task<IEnumerable<InvoiceDto>> GetAllInvoices();
        Task<InvoiceDto> GetInvoiceById(Guid id);
        Task<InvoiceDto> UpdateInvoice(Guid id, InvoiceDto invoiceDto);
    }
}
