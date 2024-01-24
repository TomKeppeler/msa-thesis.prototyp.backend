
using auftragsverwaltung_service.Model.Entities;
using buchhaltungs_service.Model.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace buchhaltungs_service.Model;

public class BuchhaltungsContext : DbContext
{ 
    private static string connString = new SqlConnectionStringBuilder()
    {
        DataSource = "localhost",
        InitialCatalog = "prototyp",
        Password = "admin",
        UserID = "thesis",
        ConnectTimeout = 30,
        TrustServerCertificate= true
    }.ConnectionString;
  
    private static readonly string schema = "the";
    public DbSet<Activity> Activity { get; set; }
    
    public DbSet<Employee> Employee { get; set; }
    
    public DbSet<Invoice> Invoice { get; set; }
    

    public BuchhaltungsContext()
    {
    }
    
    /// <summary>
    /// Constructor for the AuftragsverwaltungsContext when Testing
    /// </summary>
    /// <param name="options"></param>
    public BuchhaltungsContext(DbContextOptions<BuchhaltungsContext> options) : base(options)
    {
    }
    
    /// <summary>
    /// Override the SaveChanges Method to add the CreatedAt and UpdatedAt Properties
    /// </summary>
    /// <param name="acceptChangesWhenScuccsided">accept all changes when Successful</param>
    /// <returns></returns>
    public override int SaveChanges(bool acceptChangesWhenScuccsided)
    {
       return base.SaveChanges(acceptChangesWhenScuccsided);
    }
    
    public override async Task<int> SaveChangesAsync(bool acceptChangesWhenScuccsided, CancellationToken cancellationToken = new CancellationToken())
    {
        return await base.SaveChangesAsync(acceptChangesWhenScuccsided, cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(schema);
        modelBuilder.Entity<Activity>();
        modelBuilder.Entity<Employee>();
        modelBuilder.Entity<Invoice>();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connString);
        }
    }
    public static string GetConnectionString() => connString;
}