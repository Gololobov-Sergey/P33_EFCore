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

                var author1 = new Author
                {
                    Name = "Jon",
                    Surname = "Skeet"
                };

                var author2 = new Author
                {
                    Name = "Mark",
                    Surname = "Miller"
                };

                var book1 = new Book
                {
                    Title = "C# in Depth",
                    Pages = 500,
                    PublishDate = DateOnly.FromDateTime(DateTime.Now),
                    Author = author1,
                    Description = "Description 1"
                };

                var book2 = new Book
                {
                    Title = "C# in Depth 2",
                    Pages = 500,
                    PublishDate = DateOnly.FromDateTime(DateTime.Now),
                    Author = author2,
                    Description = "Description 2"
                };

                var book3 = new Book
                {
                    Title = "C# in Depth 3",
                    Pages = 500,
                    PublishDate = DateOnly.FromDateTime(DateTime.Now),
                    Author = author1,
                    Description = "Description 3"
                };

                

                db.Books.AddRange(book1, book2, book3);
                db.Authors.AddRange(author1, author2);
                db.SaveChanges();


                //var books = db.Books
                //    .Include(b => b.Author)
                //    .ToList();  

                //foreach (var book in books)
                //{
                //    Console.WriteLine($"Book: {book.Title}, Pages: {book.Pages}, Author: {book.Author?.Name} {book.Author?.Surname}");
                //}


                var authors = db.Authors
                    .Include(a => a.Books)
                    .ToList();

                foreach (var author in authors)
                {
                    Console.WriteLine($"Author: {author.Name} {author.Surname}");
                    foreach (var book in author.Books)
                    {
                        Console.WriteLine($" - Book: {book.Title}, Pages: {book.Pages}");
                    }
                }
            }
        }
    }
}
