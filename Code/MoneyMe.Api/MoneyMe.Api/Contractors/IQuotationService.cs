using MoneyMe.Api.DataAccess.Entities;
using MoneyMe.Api.Models.Requests;

namespace MoneyMe.Api.Contractors
{
    public interface IQuotationService
    {
        Task<string> SaveQuotationAsync(SaveQuotationRequest request);
        Task<Quotation> GetQuotationByIDAsync(Guid quotationID);
    }
}