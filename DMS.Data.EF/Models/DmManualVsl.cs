using System;
using System.Collections.Generic;

namespace DMS.Data.EF.Models;

public partial class DmManualVsl
{
    public long DmManualVslId { get; set; }

    public string Origin { get; set; } = null!;

    public int VesselId { get; set; }

    public long DmManualId { get; set; }

    public string UserRank { get; set; } = null!;

    public int? IsActive { get; set; }
}
