using Microsoft.EntityFrameworkCore;
using WTBackend.Activity.Models;
using WTBackend.Column.Models;


namespace WTBackend.DbHelper
{
    public class KanbanDbContext :DbContext
    {
        public KanbanDbContext(DbContextOptions<KanbanDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<ActivityModel> activities { get; set; }
        public DbSet<ColumnModel> columns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfiguration für die Tabelle mit den Aktivitäten in der Postgres Datenbank
            modelBuilder.Entity<ActivityModel>()
                .HasKey(c => c.Id); 

            modelBuilder.Entity<ActivityModel>()
                .Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<ActivityModel>()
                .Property(c => c.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<ActivityModel>()
                .Property(c => c.Category)
                .HasMaxLength(50);

            modelBuilder.Entity<ActivityModel>()
                .Property(c=> c.ColumnTitle)
                .HasMaxLength(50)
                .HasDefaultValue("New");

            // Konfiguration für die Tabelle mit den Spalten in der Postgres Datenbank
            modelBuilder.Entity<ColumnModel>()
                .HasKey(columns => columns.Title);

            modelBuilder.Entity<ColumnModel>()
                .Property (columns => columns.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<ColumnModel>()
                .HasMany(c => c.Activity) 
                .WithOne(a => a.Column)    
                .HasForeignKey(a => a.ColumnTitle) 
                .OnDelete(DeleteBehavior.Cascade); 
        }
        public static void Seed(KanbanDbContext context)
        {
            // Füge deine Column hinzu, wenn sie nicht existiert
            if (!context.columns.Any())
            {
                context.columns.Add(new ColumnModel
                {
                    Title = "New"
                });

                context.SaveChanges();
            }
        }

    }
}
