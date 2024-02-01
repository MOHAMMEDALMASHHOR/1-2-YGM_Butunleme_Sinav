using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext :DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }

    public DbSet<Entity.Car> Cars { get; set; }
    
}
