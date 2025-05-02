using Microsoft.Data.SqlClient;
using Dapper;
using Z.Dapper.Plus;

using Student_Dapper.Models;

namespace Student_Dapper
{
    internal class Program
    {

        static string connectionString = "Data Source=TAURUS\\SQLEXPRESS;Initial Catalog=Student-Dapper;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        static void Main(string[] args)
        {
            // CONNECTION
            var connection = new SqlConnection(connectionString);

            //// CREATE TABLE
            //connection.CreateTable<Student>();

            //var groups = new List<Group>
            //{
            //    new Group { Id = 1, Name = "Group A" },
            //    new Group { Id = 2, Name = "Group B" }
            //};
            //connection.BulkInsert(groups);

            //var students = new List<Student>
            //{
            //    new Student { Name = "Alice", BirthDay = new DateTime(2000, 1, 1), GroupId = 1 },
            //    new Student { Name = "Bob", BirthDay = new DateTime(2001, 2, 2), GroupId = 1 },
            //    new Student { Name = "Charlie", BirthDay = new DateTime(2002, 3, 3), GroupId = 2 }
            //};
            //connection.BulkInsert(students);

            // CODE
            //var sql = "SELECT [Id], [Name] FROM Student WHERE GroupId=@groupId";
            //var Id = 1;
            //var outputList = connection.Query(sql, new {groupId = Id}).ToList();

            //foreach (var student in outputList)
            //{
            //    Console.WriteLine(student.Id + " " + student.Name);
            //    //Console.WriteLine(student);
            //}

            //string sql = "SELECT COUNT(*) FROM Student WHERE GroupId=@groupId";
            //var Id = 1;
            //var count = connection.ExecuteScalar<int>(sql, new { groupId = Id });
            //Console.WriteLine($"Total number of students: {count}");


            //string sql = "INSERT INTO Student (Name, BirthDay, GroupId) VALUES (@Name, @BirthDay, @GroupId); SELECT CAST(SCOPE_IDENTITY() as int);";
            //var student = new Student
            //{
            //    Name = "David",
            //    BirthDay = new DateTime(2003, 4, 4),
            //    GroupId = 1
            //};

            //var row = connection.Execute(sql, student);
            //Console.WriteLine($"Inserted rows: {row}");



            string sql = "UPDATE Student SET GroupId = @groupId WHERE Id = @id";
            var row = connection.Execute(sql, new {groupId = 2, id = 4});
            Console.WriteLine($"Updated {row} rows");


        }
    }
}
