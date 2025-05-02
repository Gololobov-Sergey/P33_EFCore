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
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }


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
            //modelBuilder.Entity<User>().UseTphMappingStrategy();
            //modelBuilder.Entity<User>().UseTptMappingStrategy();
            modelBuilder.Entity<User>().UseTpcMappingStrategy();

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

                //entity
                //    .HasMany(e => e.Genres)
                //    .WithMany(e => e.Books)
                //    .UsingEntity(j => j.ToTable("BookGenres"));


                entity
                    .HasMany(e => e.Genres)
                    .WithMany(e => e.Books)
                    .UsingEntity<BookGenres>(
                        j => j
                            .HasOne(e => e.Genre)
                            .WithMany(e => e.BookGenres)
                            .HasForeignKey(e => e.GenreId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("FK_BookGenres_Genre"),
                        j => j
                            .HasOne(e => e.Book)
                            .WithMany(e => e.BookGenres)
                            .HasForeignKey(e => e.BookId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("FK_BookGenres_Book"),
                        j =>
                        {
                            j.HasKey(e => new { e.BookId, e.GenreId });
                            j.Property(e => e.Percent).HasDefaultValue(0);
                            j.ToTable("BookGenres");
                            j.ToTable(t => t.HasCheckConstraint("CK_BookGenres_Percent", "[Percent] >= 0 AND [Percent] <= 100"));
                        });


                entity
                    .HasOne(e => e.Author)
                    .WithMany(e => e.Books)
                    .HasForeignKey(e => e.AuthorInfoKey)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Book_Author");

                entity.HasData(new Book
                {
                    Id = 1,
                    Title = "C# in Depth",
                    Pages = 500,
                    PublishDate = DateOnly.FromDateTime(DateTime.Now),
                    AuthorInfoKey = 1,
                    Description = "Description 1"
                },
                new Book
                {
                    Id = 2,
                    Title = "C# in Depth 2",
                    Pages = 500,
                    PublishDate = DateOnly.FromDateTime(DateTime.Now),
                    AuthorInfoKey = 2,
                    Description = "Description 2"
                },
                new Book
                {
                    Id = 3,
                    Title = "C# in Depth 3",
                    Pages = 500,
                    PublishDate = DateOnly.FromDateTime(DateTime.Now),
                    AuthorInfoKey = 1,
                    Description = "Description 3"
                });

            });


            modelBuilder.Entity<Author>(entity =>
            {
                //entity.Property(e => e.FullName).HasColumnType("nvarchar(100)").HasComputedColumnSql("Name + ' ' + Surname");

                //entity.Property(p => p.Name).HasMaxLength(50).IsRequired();

                entity.HasData(new Author
                {
                    Id = 1,
                    Name = "Jon",
                    Surname = "Skeet",
                    ProfileId = 1
                },
                new Author
                {
                    Id = 2,
                    Name = "Mark",
                    Surname = "Miller",
                    ProfileId = 2
                });
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasData(new Profile
                {
                    Id = 1,
                    Login = "admin",
                    Password = "admin"
                },
                new Profile
                {
                    Id = 2,
                    Login = "user",
                    Password = "user"
                });
            });
        }
    }
}
