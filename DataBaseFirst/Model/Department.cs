using System;
using System.Collections.Generic;

namespace DataBaseFirst.Model;

public partial class Department
{
    public int Id { get; set; }

    public int Building { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Ward> Wards { get; set; } = new List<Ward>();
}
