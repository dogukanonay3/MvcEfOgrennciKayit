using Microsoft.EntityFrameworkCore;
using MvcEf.Models;

namespace MvcEf
{
    public class OkulContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=ANK1-YZLMORT-08\SQLEXPRESS;Database=OkulYonetimDb;User Id=sa;Password=sa;");
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-OR82PAL\SQLEXPRESS01;Database=OkulYönetimDb;Trusted_Connection=True;");
        }

        //entities

        public DbSet<Ders> Ders { get; set; }
        public DbSet<Ogrenci> Ogrenci { get; set; }
        public DbSet<Kurs> Kurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ders>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Ogrenci>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Kurs>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Kurs>()
            .HasMany(p => p.Ogrenciler)
            .WithMany(p => p.Kurslar)
            .UsingEntity(p => p.ToTable("KursOgrenci"));
        }
    }
}