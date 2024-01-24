using buchhaltungs_service.Model.Entities.Dto;
using buchhaltungs_service.Model.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace buchhaltungs_service.Model.Repository.Invoice
{
    public class InvoiceRepository : RepositoryBase, IInvoiceRepository
    {
        public InvoiceRepository(BuchhaltungsContext context) : base(context)
        {
        }

        public async Task<Entities.Invoice> CreateInvoice(Entities.Invoice invoice)
        {
            Context.Invoice.Add(invoice);
            await Context.SaveChangesAsync();
            return invoice;
        }

        public async Task<IEnumerable<Entities.Invoice>> GetAllInvoices()
        {
            return await Context.Invoice.ToListAsync();
        }

        public async Task<Entities.Invoice> GetInvoiceById(Guid id)
        {
            return await Context.Invoice.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Entities.Invoice> UpdateInvoice(Guid id, Entities.Invoice invoice)
        {
            Context.Invoice.Update(invoice);
            await Context.SaveChangesAsync();
            return invoice;
        }

        public async Task DeleteInvoice(Guid id)
        {
            Entities.Invoice invoice = await Context.Invoice.FirstOrDefaultAsync(i => i.Id == id);
            Context.Invoice.Remove(invoice);
            await Context.SaveChangesAsync();
        }
    }
}
