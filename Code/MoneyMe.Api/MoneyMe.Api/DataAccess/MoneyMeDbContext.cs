using Microsoft.EntityFrameworkCore;
using MoneyMe.Api.DataAccess.Entities;

namespace MoneyMe.Api.DataAccess
{
    public class MoneyMeDbContext : DbContext
    {
        public MoneyMeDbContext(DbContextOptions<MoneyMeDbContext> options) : base(options) { } 

        public virtual DbSet<Quotation> Quotations { get; set; }
    }
}
