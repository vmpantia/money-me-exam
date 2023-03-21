using Microsoft.EntityFrameworkCore;
using MoneyMe.Api.Common;
using MoneyMe.Api.Contractors;
using MoneyMe.Api.DataAccess;
using MoneyMe.Api.DataAccess.Entities;
using MoneyMe.Api.Exceptions;
using MoneyMe.Api.Models.Requests;

namespace MoneyMe.Api.Services
{
    public class QuotationService : IQuotationService
    {
        private readonly MoneyMeDbContext _db;
        public QuotationService(MoneyMeDbContext db)
        {
            _db = db;
        }

        public async Task<string> SaveQuotationAsync(SaveQuotationRequest request)
        {
            if (request == null)
                throw new ServiceException("Quotation request cannot be null or empty.");


            //Check if there's a existing quoatation of the requester
            var quotations = await _db.Quotations.Where(data => data.FirstName == data.FirstName &&
                                                                data.LastName == data.LastName &&
                                                                data.DateOfBirth == data.DateOfBirth)
                                                 .ToListAsync();
            var isAdd = quotations.Any();

            if (isAdd)
                await InsertQuotation(request.inputQuotation);

            else
                await UpdateQuotation(quotations.First(), request.inputQuotation);

            var result = await _db.SaveChangesAsync();
            if (result == 0)
                throw new ServiceException("Error in saving data in database.");

            return string.Format(Constants.QUOTE_CALCULATOR_SUFFIX_URL, isAdd ?
                                        request.inputQuotation.QuotationID :
                                        quotations.First().QuotationID);
        }

        private async Task InsertQuotation(Quotation data)
        {
            data.QuotationID = Guid.NewGuid();
            await _db.Quotations.AddAsync(data);
        }

        private async Task UpdateQuotation(Quotation oldData, Quotation newData)
        {
            //oldData.QuotationID = newData.QuotationID;
            oldData.AmountRequired = newData.AmountRequired;
            oldData.Term = newData.Term;
            oldData.Title = newData.Title;
            //oldData.FirstName = newData.FirstName;
            //oldData.LastName = newData.LastName;
            //oldData.DateOfBirth = newData.DateOfBirth;
            oldData.Mobile = newData.Mobile;
            oldData.Email = newData.Email;
        }


    }
}
