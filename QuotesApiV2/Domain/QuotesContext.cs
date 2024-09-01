using Microsoft.EntityFrameworkCore;
using QuotesApiV2.Domain.Models;

namespace QuotesApiV2.Domain
{
    public class QuotesContext : DbContext
    {
        public QuotesContext(DbContextOptions<QuotesContext> options) : base(options)
        {
                
        }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
