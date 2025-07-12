using System;
using System.Collections.Generic;

namespace DMS.Data.EF.Models;

public partial class HqUser
{
    public long HqUsersId { get; set; }

    public string Origin { get; set; } = null!;

    public int VesselId { get; set; }

    public string? Hqdept { get; set; }

    public string UserId { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? Designation { get; set; }

    public string? Email { get; set; }

    public string? EmpId { get; set; }

    public string? PhoneNo { get; set; }

    public int? IsDisabled { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? DateDisabled { get; set; }
}
