using Microsoft.EntityFrameworkCore;

public class Connection : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=127.0.01;Database=product_challenge_db;User=sa;Password=123456";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}