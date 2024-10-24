using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Database
{
    public class DatabaseContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DatabaseContext()
        { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=AspCoreUnitOfWorkEShopDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");            
        }
   
        //----------------------Entities
        public DbSet<Location> Location { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
            modelBuilder_Identity(modelBuilder);
            modelBuilder_Order(modelBuilder);
        }

        public void modelBuilder_Identity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable(name: "Users");
            });

            //modelBuilder.Entity<IdentityRole>(entity =>
            //{
            //    entity.ToTable(name: "Roles");
            //});

            modelBuilder.Entity<AppRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
                //in case you chagned the TKey type
                //  entity.HasKey(key => new { key.UserId, key.RoleId });
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

        }

        public void modelBuilder_Order(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasMany<OrderProduct>(g => g.OrderProducts)
            .WithOne(s => s.Order)
            .HasForeignKey(s => s.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
