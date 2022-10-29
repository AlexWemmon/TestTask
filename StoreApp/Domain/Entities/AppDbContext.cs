using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Domain.Entities
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _configuration;
        public AppDbContext()
        {

        }
        public DbSet<Book> Books { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(local); Database=BooksDb; Persist Security Info=False; MultipleActiveResultSets=True; Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(entity => 
            { 
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("id")
                    .IsConcurrencyToken();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("price");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("description");
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.NewGuid(),
                Name = "Сказка о царе Салтане",
                Description = @"Сказка о царе Салта́не, о сыне его славном и могучем богатыре князе 
                    Гвидо́не Салта́новиче и о прекрасной царевне Лебеди» — сказка в стихах Александра Пушкина, 
                    написанная в 1831 году и впервые изданная в следующем году в собрании стихотворений",
                Price = 127m
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = Guid.NewGuid(),
                Name = "Сказка о золотой рыбке",
                Description = @"Ска́зка о рыбаке́ и ры́бке» — сказка А. С. Пушкина. Написана 2 октября 1833 года.
                                Впервые напечатана в 1835 году в журнале «Библиотека для чтения»",
                Price = 201m
            });
           
        }
    }
}
