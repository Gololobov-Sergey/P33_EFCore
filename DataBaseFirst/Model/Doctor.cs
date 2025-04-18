using System;
using System.Collections.Generic;
using System.Numerics;

namespace DataBaseFirst.Model;

public partial class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Premium { get; set; }

    public decimal Salary { get; set; }

    public string Surname { get; set; } = null!;

    public virtual ICollection<DoctorsExamination> DoctorsExaminations { get; set; } = new List<DoctorsExamination>();

    public override string ToString()
    {
        return $"{Id} {Name} {Surname} {Premium} {Salary}";
    }
}
