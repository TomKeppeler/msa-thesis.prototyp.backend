using buchhaltungs_service.Model.Entities.Dto;
using buchhaltungs_service.Service.Invoice;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace buchhaltungs_service.Controller
{
    [ApiController]
    [Route("api/invoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetAllInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoices();
            return Ok(invoices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDto>> GetInvoiceById([FromRoute()] Guid id)
        {
            var invoice = await _invoiceService.GetInvoiceById(id);
            return Ok(invoice);
        }

        [HttpPost()]
        public async Task<ActionResult<InvoiceDto>> CreateInvoice([FromBody] InvoiceDto invoiceDto)
        {
            var invoice = await _invoiceService.CreateInvoice(invoiceDto);
            return Ok(invoice);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<InvoiceDto>> UpdateInvoice([FromRoute()] Guid id, [FromBody] InvoiceDto invoiceDto)
        {
            var invoice = await _invoiceService.UpdateInvoice(id, invoiceDto);
            return Ok(invoice);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInvoice([FromRoute()] Guid id)
        {
            await _invoiceService.DeleteInvoice(id);
            return Ok();
        }
    }
}
