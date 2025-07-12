using System;
using System.Collections.Generic;

namespace DMS.Data.EF.Models;

public partial class DmManualLog
{
    public long DmManualLogId { get; set; }

    public string Origin { get; set; } = null!;

    public int VesselId { get; set; }

    public long DmManualId { get; set; }

    public string Activity { get; set; } = null!;

    public string Remarks { get; set; } = null!;

    public DateTime? Logdate { get; set; }

    public string? UserRank { get; set; }

    public string? UserName { get; set; }

    public string? MachineWinLoginName { get; set; }
}
