using Microsoft.EntityFrameworkCore;

public class Connection : DbContext
{
    
    public Connection(DbContextOptions<Connection> options) : base(options)
    {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = "Server=127.0.01;Database=product_challenge_db;User=sa;Password=123456";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}