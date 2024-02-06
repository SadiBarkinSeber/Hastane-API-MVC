using HastaneAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace HastaneAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Hasta> Hastalar { get; set; }
        public DbSet<Hastane> Hastaneler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hastane>().HasData(

                new Hastane
                {
                    Id = 1,
                    HastaneAdi = "Medipol",
                    Adres = "Bagcilar"
                },
                new Hastane
                {
                    Id = 2,
                    HastaneAdi = "Acibadem",
                    Adres = "Kadikoy"
                });


            modelBuilder.Entity<Hasta>().HasData(
                new Hasta
                {
                    Id = 1,
                    Adi = "Ahmet",
                    Soyadi = "Yilmaz",
                    Klinik = "Dis",
                    MuayeneTarihi = DateTime.Now,
                    HastaneId = 1,
                },
                new Hasta
                {
                    Id = 2,
                    Adi = "Mehmet",
                    Soyadi = "Yilacak",
                    Klinik = "KBB",
                    MuayeneTarihi = DateTime.Now,
                    HastaneId = 2,
                },
                new Hasta
                {
                    Id = 3,
                    Adi = "Ali",
                    Soyadi = "Yildi",
                    Klinik = "Goz",
                    MuayeneTarihi = DateTime.Now,
                    HastaneId = 1,
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
