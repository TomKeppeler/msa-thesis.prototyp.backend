using auftragsverwaltung_service.Controllers.Milestone;
using auftragsverwaltung_service.Model.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace auftragsverwaltung_service.Model;

public class AuftragsverwaltungsContext : DbContext
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
    public DbSet<Customer> Customer { get; set; }
    
    public DbSet<Team> Team { get; set; }
    
    public DbSet<Order> Order { get; set; }
    
    public DbSet<Milestone> Milestone { get; set; }

    public AuftragsverwaltungsContext()
    {
    }
    
    /// <summary>
    /// Constructor for the AuftragsverwaltungsContext when Testing
    /// </summary>
    /// <param name="options"></param>
    public AuftragsverwaltungsContext(DbContextOptions<AuftragsverwaltungsContext> options) : base(options)
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
        modelBuilder.Entity<Customer>();
        modelBuilder.Entity<Team>();
        modelBuilder.Entity<Order>();
        modelBuilder.Entity<Milestone>();
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