using System;
using System.Collections.Generic;

namespace TUPApp.Models;

public partial class EmergencyContact
{
    public int Id { get; set; }

    public string? EmergencyName { get; set; }

    public string? EmergencyNumber { get; set; }

    public string? Relationship { get; set; }

    public int? StudentId { get; set; }

    public virtual Student? Student { get; set; }
}
