using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WepApp.Models;

namespace WepApp.Data
{

    public class AppUser : IdentityUser<int>
    {
        public string? Fullname { get; set; }
    }

    public class AppRole : IdentityRole<int>
    {

    }

    public class OkulContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public OkulContext(DbContextOptions options) : base(options) { }

        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Bolum> Bolumler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Seeding(modelBuilder);
        }

        private static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dil>().HasData(
                new Dil { Id = new Guid("C02AD632-FC80-4F24-B270-93CC9105C1CE"), Adi = "TR" },
                new Dil { Id = new Guid("A72FA537-B77B-4848-9D2D-738D3B1B8F7F"), Adi = "EN" });

            modelBuilder.Entity<Bolum>().HasData(
                new Bolum { Id = 1, Adi = "Bilgisayar" },
                new Bolum { Id = 2, Adi = "Matematik" },
                new Bolum { Id = 3, Adi = "Resim" }
                );
        }

        //public DbSet<WepApp.Models.RegisterUserModel> RegisterUserModel { get; set; } = default!;
    }
}
