using System;
using System.Collections.Generic;

namespace TUPApp.Models;

public partial class EducationalBackground
{
    public int Id { get; set; }

    public string? EducationalAttainment { get; set; }

    public string? School { get; set; }

    public string? YearStarted { get; set; }

    public string? YearGraduated { get; set; }

    public string? Address { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
