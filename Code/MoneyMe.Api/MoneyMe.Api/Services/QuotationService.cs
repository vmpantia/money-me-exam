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

        public async Task<Quotation> GetQuotationByIDAsync(Guid quotationID)
        {
            var data = await _db.Quotations.FindAsync(quotationID);
            if(data == null)
                throw new ServiceException("Quotation cannot be found in the database.");

            return data;
        }

        public async Task<string> SaveQuotationAsync(SaveQuotationRequest request)
        {
            try
            {
                Guid quotationId;

                if (request == null)
                    throw new ServiceException("Quotation request cannot be null or empty.");


                //Check if there's a existing quoatation of the requester
                var quotations = await _db.Quotations.Where(data => data.FirstName == request.FirstName &&
                                                                    data.LastName == request.LastName &&
                                                                    data.DateOfBirth == request.DateOfBirth)
                                                     .ToListAsync();

                if (!quotations.Any())
                    quotationId = await InsertQuotation(request);

                else
                    quotationId = await UpdateQuotation(request, quotations.First());

                var result = await _db.SaveChangesAsync();
                if (result == 0)
                    throw new ServiceException("Error in saving data in database.");

                return string.Format(Constants.QUOTE_CALCULATOR_SUFFIX_URL, quotationId);
            }
            catch(Exception ex) 
            {
                throw;
            }
        }

        private async Task<Guid> InsertQuotation(SaveQuotationRequest request)
        {
            var quotation = new Quotation
            {
                QuotationID = Guid.NewGuid(),
                AmountRequired = request.AmountRequired,
                Term = request.Term,
                Title = request.Title,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Mobile = request.Mobile,
                Email = request.Email,
            };
            await _db.Quotations.AddAsync(quotation);

            return quotation.QuotationID;
        }

        private async Task<Guid> UpdateQuotation(SaveQuotationRequest request, Quotation currentData)
        {
            currentData.AmountRequired = request.AmountRequired;
            currentData.Term = request.Term;
            currentData.Title = request.Title;
            //currentData.FirstName = request.FirstName;
            //currentData.LastName = request.LastName;
            //currentData.DateOfBirth = request.DateOfBirth;
            currentData.Mobile = request.Mobile;
            currentData.Email = request.Email;

            return currentData.QuotationID;
        }


    }
}
