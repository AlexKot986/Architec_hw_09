using CloudOrderApi.Contexts.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudOrderApi.Contexts
{
    public class CloudDBContext : DbContext
    {
        public virtual DbSet<Cloud> Clouds { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OS> OSs { get; set; }
        public string _connectionString;

        public CloudDBContext() 
        {
            _connectionString = "Host=localhost;Port=5433;Username=postgres;Password=example;Database=CloudOrderDb";
        }
        public CloudDBContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                //.LogTo(Console.WriteLine)
                          //.UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=example;Database=CloudOrderDb");
                          .UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.Id).HasName("client_pkey");
                entity.ToTable("clients");
                entity.Property(c => c.Id).HasColumnName("id");
                entity.Property(c => c.Name).HasMaxLength(26).HasColumnName("name");
                entity.HasIndex(c => c.Email).IsUnique();
                entity.Property(c => c.Email).HasMaxLength(26).HasColumnName("email");
            });

            modelBuilder.Entity<Cloud>(entity =>
            {
                entity.HasKey(c => c.Id).HasName("cloud_pkey");
                entity.ToTable("clouds");
                entity.Property(c => c.Id).HasColumnName("id");   

                entity.HasIndex(c => c.OrederId).IsUnique();
                entity.Property(c => c.OrederId).HasColumnName("order_id");
                
                entity.Property(c => c.OSId).HasColumnName("os");   
                entity.HasOne(c => c.OS).WithMany(os => os.Clouds);

                entity.Property(c => c.CoresNumber).HasColumnName("cores_number");
                entity.Property(c => c.RamVolume).HasColumnName("ram_volume");
                entity.Property(c => c.HddVolume).HasColumnName("hdd_volume");               
                entity.Property(c => c.Address).HasColumnName("address");

            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id).HasName("orser_pkey");
                entity.ToTable("orders");
                entity.Property(o => o.Id).HasColumnName("id");           

                entity.Property(o => o.ClientId).HasColumnName("client_id");
                entity.HasOne(o => o.Client).WithMany(c => c.Orders);

                entity.Property(o => o.IsPaid).HasColumnName("is_paid");
            });

            modelBuilder.Entity<OS>(entity =>
            {
                entity.HasKey(os => os.Id).HasName("os_pkey");
                entity.ToTable("os");
                entity.Property(os => os.Id).HasColumnName("id");

                entity.Property(o => o.Name).HasMaxLength(26).HasColumnName("title");
            });

            base.OnModelCreating(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
