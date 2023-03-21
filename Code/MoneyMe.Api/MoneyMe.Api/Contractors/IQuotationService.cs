using MoneyMe.Api.Models.Requests;

namespace MoneyMe.Api.Contractors
{
    public interface IQuotationService
    {
        Task<string> SaveQuotationAsync(SaveQuotationRequest request);
    }
}