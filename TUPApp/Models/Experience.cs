using System;
using System.Collections.Generic;

namespace TUPApp.Models;

public partial class Experience
{
    public int Id { get; set; }

    public string? Experience1 { get; set; }

    public string? YearStarted { get; set; }

    public string? YearEnded { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
