using System;
using System.Collections.Generic;

namespace DataBaseFirst.Model;

public partial class DoctorsExamination
{
    public int Id { get; set; }

    public TimeOnly EndTime { get; set; }

    public TimeOnly StartTime { get; set; }

    public int DoctorId { get; set; }

    public int ExaminationId { get; set; }

    public int WardId { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Examination Examination { get; set; } = null!;

    public virtual Ward Ward { get; set; } = null!;
}
