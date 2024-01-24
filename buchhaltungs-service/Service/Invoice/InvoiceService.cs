using AutoMapper;
using buchhaltungs_service.Model.Entities.Dto;
using buchhaltungs_service.Model.Repository.Invoice;

namespace buchhaltungs_service.Service.Invoice
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IMapper _mappingProfile;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mappingProfile)
        {
            this.invoiceRepository = invoiceRepository;
            _mappingProfile = mappingProfile;
        }

        public async Task<InvoiceDto> CreateInvoice(InvoiceDto invoiceDto)
        {
            Model.Entities.Invoice invoice = await invoiceRepository.CreateInvoice(_mappingProfile.Map<Model.Entities.Invoice>(invoiceDto));
            return _mappingProfile.Map<InvoiceDto>(invoice);
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllInvoices()
        {
            return _mappingProfile.Map<IEnumerable<InvoiceDto>>(await invoiceRepository.GetAllInvoices());
        }

        public async Task<InvoiceDto> GetInvoiceById(Guid id)
        {
            return _mappingProfile.Map<InvoiceDto>(await invoiceRepository.GetInvoiceById(id));
        }

        public async Task<InvoiceDto> UpdateInvoice(Guid id, InvoiceDto invoiceDto)
        {
            Model.Entities.Invoice invoice = _mappingProfile.Map<Model.Entities.Invoice>(invoiceDto);
            return _mappingProfile.Map<InvoiceDto>(await invoiceRepository.UpdateInvoice(id, invoice));
        }

        public async Task DeleteInvoice(Guid id)
        {
            await invoiceRepository.DeleteInvoice(id);
        }
    }
}
