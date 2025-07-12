using System;
using System.Collections.Generic;

namespace DMS.Data.EF.Models;

public partial class VslStaff
{
    public long VslStaffId { get; set; }

    public string Origin { get; set; } = null!;

    public int VesselId { get; set; }

    public string UserId { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public byte[] UserRank { get; set; } = null!;

    public string? UserDept { get; set; }

    public int? IsDisabled { get; set; }
}
