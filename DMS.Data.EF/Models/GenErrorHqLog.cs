using System;
using System.Collections.Generic;

namespace DMS.Data.EF.Models;

public partial class GenErrorHqLog
{
    public long GenErrorHqLogId { get; set; }

    public string Origin { get; set; } = null!;

    public int VesselId { get; set; }

    public string ApplicationName { get; set; } = null!;

    public string PageName { get; set; } = null!;

    public string FunctionName { get; set; } = null!;

    public string? TextContents { get; set; }

    public string LoggedInUserId { get; set; } = null!;

    public DateTime AddedOn { get; set; }

    public string? MachineWinLoginName { get; set; }
}
