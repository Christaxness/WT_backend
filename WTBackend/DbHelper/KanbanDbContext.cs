using Microsoft.EntityFrameworkCore;
using WTBackend.Activity.Models; 


namespace WTBackend.DbHelper
{
    public class KanbanDbContext :DbContext
    {
        public KanbanDbContext(DbContextOptions<KanbanDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<ActivityModel> activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfiguration für die Tabelle mit den Aktivitäten in der Postgres Datenbank
            modelBuilder.Entity<ActivityModel>()
                .HasKey(c => c.Id); 

            
            modelBuilder.Entity<ActivityModel>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<ActivityModel>()
                .Property(c => c.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<ActivityModel>()
                .Property(c => c.Category)
                .HasMaxLength(50);
        }

    }
}
