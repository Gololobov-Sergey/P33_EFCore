using DataBaseFirst.Model;

namespace DataBaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // select
            using (Hospital5Context db = new Hospital5Context())
            {
                var doctors = db.Doctors.Where(d => d.Salary > 20000).ToList();
                foreach (var doctor in doctors)
                {
                    Console.WriteLine(doctor);
                }
            }


            //// insert
            //using (Hospital5Context db = new Hospital5Context())
            //{
            //    Doctor doc = new Doctor
            //    {
            //        Name = "John",
            //        Surname = "Doe",
            //        Salary = 25000,
            //        Premium = 5000
            //    };

            //    Doctor doc2 = new Doctor
            //    {
            //        Name = "Jane",
            //        Surname = "Smith",
            //        Salary = 30000,
            //        Premium = 6000
            //    };

            //    db.Doctors.AddRange(doc, doc2);
            //    db.SaveChanges();

            //    foreach (var doctor in db.Doctors.ToList())
            //    {
            //        Console.WriteLine(doctor);
            //    }
            //}


            //// update
            //using (Hospital5Context db = new Hospital5Context())
            //{

            //    var doc = db.Doctors.Where(d => d.Id == 8).FirstOrDefault();
            //    doc.Name = "Serg";
            //    doc.Surname = "Sergiev";

            //    db.SaveChanges();

            //    foreach (var doctor in db.Doctors.ToList())
            //    {
            //        Console.WriteLine(doctor);
            //    }
            //}


            //// delete
            //using (Hospital5Context db = new Hospital5Context())
            //{

            //    var doc = db.Doctors.Where(d => d.Id == 8).FirstOrDefault();
            //    if (doc != null)
            //    {
            //        db.Doctors.Remove(doc);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Doctor not found");
            //    }

            //    db.SaveChanges();

            //    foreach (var doctor in db.Doctors.ToList())
            //    {
            //        Console.WriteLine(doctor);
            //    }
            //}
        }
    }
}
