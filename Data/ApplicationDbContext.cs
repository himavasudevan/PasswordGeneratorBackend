namespace PasswordGeneratorApi.Data
{
    using Microsoft.EntityFrameworkCore;
    using PasswordGeneratorApi.Models;
    
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<StoredPassword> StoredPasswords { get; init; }
    }
}
