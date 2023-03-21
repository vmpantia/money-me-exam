using MoneyMe.Api.DataAccess.Entities;

namespace MoneyMe.Api.Models.Requests
{
    public class SaveQuotationRequest
    {
        public Quotation inputQuotation { get; set; }
    }
}
