using CodeFirst.Models;

namespace CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var db = new DBContext())
            {
                var student = new Student
                {
                    Name = "John",
                    Surname = "Doe",
                    BirthDay = new DateOnly(2000, 1, 1),
                    Address = "123 Main St"
                };
                db.Students.Add(student);
                db.SaveChanges();


                var students = db.Students.ToList();
                foreach (var item in students)
                {
                    Console.WriteLine($"{item.Id} {item.Name} {item.Surname} {item.BirthDay}");
                }
            }
        }
    }
}
