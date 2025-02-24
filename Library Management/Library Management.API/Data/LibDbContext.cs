using Microsoft.EntityFrameworkCore;

namespace Library_Management.API.Data
{
    public class LibDbContext : DbContext
    {
        public LibDbContext(DbContextOptions<LibDbContext> options) : base(options)
        {
            
        }


        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}
