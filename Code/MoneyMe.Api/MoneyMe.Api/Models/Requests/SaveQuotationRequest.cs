using MoneyMe.Api.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace MoneyMe.Api.Models.Requests
{
    public class SaveQuotationRequest
    {
        public decimal AmountRequired { get; set; }
        public decimal Term { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
