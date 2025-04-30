using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DBContext())
            {

                //Profile profile1 = new Profile
                //{
                //    Login = "admin",
                //    Password = "admin"
                //};

                //Profile profile2 = new Profile
                //{
                //    Login = "user",
                //    Password = "user"
                //};

                //var author1 = new Author
                //{
                //    Name = "Jon",
                //    Surname = "Skeet",
                //    Profile = profile1
                //};

                //var author2 = new Author
                //{
                //    Name = "Mark",
                //    Surname = "Miller",
                //    Profile = profile2
                //};

                //var book1 = new Book
                //{
                //    Title = "C# in Depth",
                //    Pages = 500,
                //    PublishDate = DateOnly.FromDateTime(DateTime.Now),
                //    Author = author1,
                //    Description = "Description 1"
                //};

                //var book2 = new Book
                //{
                //    Title = "C# in Depth 2",
                //    Pages = 500,
                //    PublishDate = DateOnly.FromDateTime(DateTime.Now),
                //    Author = author2,
                //    Description = "Description 2"
                //};

                //var book3 = new Book
                //{
                //    Title = "C# in Depth 3",
                //    Pages = 500,
                //    PublishDate = DateOnly.FromDateTime(DateTime.Now),
                //    Author = author1,
                //    Description = "Description 3"
                //};


                //db.Profiles.AddRange(profile1, profile2);
                //db.Books.AddRange(book1, book2, book3);
                //db.Authors.AddRange(author1, author2);
                //db.SaveChanges();


                //var books = db.Books
                //    .Include(b => b.Author)
                //    .ToList();  

                //foreach (var book in books)
                //{
                //    Console.WriteLine($"Book: {book.Title}, Pages: {book.Pages}, Author: {book.Author?.Name} {book.Author?.Surname}");
                //}


                //var authors = db.Authors
                //    .Include(a => a.Books)
                //    .Include(a => a.Profile)
                //    .ToList();

                //foreach (var author in authors)
                //{
                //    Console.WriteLine($"Author: {author.Name} {author.Surname} {author.Profile.Login}");
                //    foreach (var book in author.Books)
                //    {
                //        Console.WriteLine($" - Book: {book.Title}, Pages: {book.Pages}");
                //    }
                //}



                //Genre genre1 = new Genre
                //{
                //    Name = "Programming"
                //};
                //Genre genre2 = new Genre
                //{
                //    Name = "Science"
                //};
                //Genre genre3 = new Genre
                //{
                //    Name = "Fiction"
                //};

                //db.Genres.AddRange(genre1, genre2, genre3);

                //var book = db.Books
                //    .FirstOrDefault(b => b.Id == 1);

                //if (book != null)
                //{
                //    book.BookGenres.Add(new BookGenres
                //    {
                //        Book = book,
                //        Genre = genre1,
                //        Percent = 50
                //    });
                //    book.BookGenres.Add(new BookGenres
                //    {
                //        Book = book,
                //        Genre = genre2,
                //        Percent = 50
                //    });
                //}



                //var book2 = db.Books.Where(b => b.Id == 2).FirstOrDefault();
                //if (book2 != null)
                //{
                //    book2.BookGenres.Add(new BookGenres
                //    {
                //        Book = book2,
                //        Genre = genre1,
                //        Percent = 50
                //    });
                //    book2.BookGenres.Add(new BookGenres
                //    {
                //        Book = book2,
                //        Genre = genre3,
                //        Percent = 50
                //    });
                //}

                //db.SaveChanges();


                var books = db.Books
                    .Include(b => b.BookGenres)
                        .ThenInclude(bg => bg.Genre)
                    .Where(b => b.BookGenres.Any(bg => bg.Genre.Name == "Programming"))
                    .ToList();

                foreach (var book in books)
                {
                    Console.WriteLine($"Book: {book.Title}, Pages: {book.Pages}, PublishDate: {book.PublishDate}");
                    foreach (var bookGenre in book.BookGenres)
                    {
                        Console.WriteLine($" - Genre: {bookGenre.Genre.Name}, Percent: {bookGenre.Percent}");
                    }
                }

            }
        }
    }
}
