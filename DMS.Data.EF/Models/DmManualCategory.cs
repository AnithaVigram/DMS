using System;
using System.Collections.Generic;

namespace DMS.Data.EF.Models;

public partial class DmManualCategory
{
    public long DmManualCategoryId { get; set; }

    public string Origin { get; set; } = null!;

    public int VesselId { get; set; }

    public string? CategoryCode { get; set; }

    public string CategoryName { get; set; } = null!;

    public int? IsDisabled { get; set; }
}
