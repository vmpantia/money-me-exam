using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoneyMe.Web.Models.Views
{
    public class QuotationViewModel
    {
        [DisplayName("Amount to Loan")]
        public decimal Amount { get; set; }
        [DisplayName("Term (in months)")]
        public decimal Term { get; set; }
        public string Title { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Mobile Number")]
        public string Mobile { get; set; }
        [DisplayName("Email Address")]
        public string Email { get; set; }
    }
}
