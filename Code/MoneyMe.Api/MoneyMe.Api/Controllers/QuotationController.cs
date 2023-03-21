using Microsoft.AspNetCore.Mvc;
using MoneyMe.Api.Contractors;
using MoneyMe.Api.Models.Requests;

namespace MoneyMe.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotationController : Controller
    {
        private readonly IQuotationService _quotation;
        public QuotationController(IQuotationService quotation)
        {
            _quotation = quotation;
        }

        [HttpGet("GetSGs")]
        public async Task<IActionResult> GetSGsAsync(SaveQuotationRequest request)
        {
            try
            {
                var result = await _quotation.SaveQuotationAsync(request);
                if (string.IsNullOrEmpty(result))
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
