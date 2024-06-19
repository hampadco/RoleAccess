using Microsoft.EntityFrameworkCore;

public class Context:DbContext
{

    

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=annapurna.liara.cloud,32283;Initial Catalog=myDB;User Id=sa;Password=n4Y1f8SGacKsXvhfmu3eko3v;MultipleActiveResultSets=true;TrustServerCertificate=true;");
    }
    
}