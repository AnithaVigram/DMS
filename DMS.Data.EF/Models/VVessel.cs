using System;
using System.Collections.Generic;

namespace DMS.Data.EF.Models;

public partial class VVessel
{
    public long VVesselId { get; set; }

    public string Origin { get; set; } = null!;

    public int VesselId { get; set; }

    public string VslCode { get; set; } = null!;

    public string VslName { get; set; } = null!;
}
