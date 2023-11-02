using Microsoft.EntityFrameworkCore;

namespace MvcCRUD.Models
{
    public partial class MvcCrudContext : DbContext
    {
        public MvcCrudContext()
        {
        }

        public MvcCrudContext(DbContextOptions<MvcCrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Commentez ou supprimez cette méthode si vous configurez votre base de données
            // à partir de la configuration de l'application (appsettings.json).
            // optionsBuilder.UseNpgsql("Host=localhost;Database=MVC_CRUD;Username=postgres;Password=yoba;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Date).HasColumnName("date");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
