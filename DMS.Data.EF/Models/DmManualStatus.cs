using System;
using System.Collections.Generic;

namespace DMS.Data.EF.Models;

public partial class DmManualStatus
{
    public long DmManualStatusId { get; set; }

    public string Origin { get; set; } = null!;

    public int VesselId { get; set; }

    public string? StatusCode { get; set; }

    public string StatusName { get; set; } = null!;

    public int? IsDisabled { get; set; }

    public int? SortOrder { get; set; }
}
