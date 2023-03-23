using System;
using System.Collections.Generic;

namespace TUPApp.Models;

public partial class TrainingsAttended
{
    public int Id { get; set; }

    public string? Training { get; set; }

    public string? YearAttended { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
