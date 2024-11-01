using DecentralizedErp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DecentralizedErp.Infrastructure;

public class DecentralizedErpDbContext : DbContext
{
    public DecentralizedErpDbContext(DbContextOptions<DecentralizedErpDbContext> options)
        : base(options) { }

    public DbSet<DepartmentDbModel> Departments { get; set; }

    public DbSet<OrganizationDbModel> Organizations { get; set; }

    public DbSet<FinanceDbModel> Finances { get; set; }

    public DbSet<ProjectDbModel> Projects { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
