using System.ComponentModel.DataAnnotations;

namespace MoneyMe.Api.DataAccess.Entities
{
    public class Quotation
    {
        [Key]
        public Guid QuotationID { get; set; }
        public decimal AmountRequired { get; set; }
        public decimal Term { get; set; }
        [Required, MaxLength(10)]
        public string Title { get; set; }
        [Required, MaxLength(30)]
        public string FirstName { get; set; }
        [Required, MaxLength(30)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required, MaxLength(15)]
        public string Mobile { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
    }
}
