using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();


            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                //entity.ToTable("books");
                //entity.Property(e => e.Id).HasColumnName("id_book");
                //entity.HasKey(e => e.Id).HasName("PK_Book");
                //entity.Ignore(e => e.Description);
                //entity.Property(e => e.Title).IsRequired();

                ////entity.HasKey(e => new {e.Id, e.Title}).HasName("PK_Book");

                //entity.HasAlternateKey(e => e.Title).HasName("UK_Book_Title");
                ////entity.HasAlternateKey(e => new { e.Title, e.Pages}).HasName("UK_Book_Title");

                //entity.HasIndex(e => e.Pages).HasDatabaseName("IX_Book_Pages").IsUnique().IsDescending();

                ////entity.Property(e=>e.Id).ValueGeneratedNever();

                //entity.Property(e => e.Pages).HasDefaultValue(0);

                //entity.ToTable(c => c.HasCheckConstraint("CK_Book_Pages", "Pages >= 0"));


                //entity.Property(e => e.PublishDate).HasColumnType("date").HasDefaultValueSql("getdate()");

                ////entity.Property(e => e.PublishDate).HasColumnType("date").HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));

                //entity.HasData(new Book[]
                //{
                //    new Book { Id = 1, AuthorId=1, Title = "Book 1", Description="Description 1", Pages = 100, PublishDate = DateOnly.FromDateTime(DateTime.Now) },
                //    new Book { Id = 2, AuthorId=2, Title = "Book 2", Description="Description 2", Pages = 200, PublishDate = DateOnly.FromDateTime(DateTime.Now) },
                //    new Book { Id = 3, AuthorId=1, Title = "Book 3", Description="Description 3", Pages = 300, PublishDate = DateOnly.FromDateTime(DateTime.Now) }
                //});


                entity
                    .HasOne(e => e.Author)
                    .WithMany(e => e.Books)
                    .HasForeignKey(e => e.AuthorInfoKey)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Book_Author");

            });


            modelBuilder.Entity<Author>(entity =>
            {
                //entity.Property(e => e.FullName).HasColumnType("nvarchar(100)").HasComputedColumnSql("Name + ' ' + Surname");

                //entity.Property(p => p.Name).HasMaxLength(50).IsRequired();

                //entity.HasData(new Author[]
                //{
                //    new Author { Id = 1, Name = "Author 1", Surname = "Surname 1" },
                //    new Author { Id = 2, Name = "Author 2", Surname = "Surname 2" },
                //    new Author { Id = 3, Name = "Author 3", Surname = "Surname 3" }
                //});
            });
        }
    }
}
