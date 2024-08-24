using Microsoft.EntityFrameworkCore;

public class RRHHContext : DbContext
{
    public RRHHContext(DbContextOptions<RRHHContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Colaborador> Colaboradores { get; set; }
}
