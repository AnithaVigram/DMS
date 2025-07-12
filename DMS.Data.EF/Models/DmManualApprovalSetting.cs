using System;
using System.Collections.Generic;

namespace DMS.Data.EF.Models;

public partial class DmManualApprovalSetting
{
    public long DmApprovalSettingsId { get; set; }

    public string Origin { get; set; } = null!;

    public int VesselId { get; set; }

    public long DmManualId { get; set; }

    public string Hqdept { get; set; } = null!;

    public string? UserRole { get; set; }

    public string? UserId { get; set; }

    public long DmStatusId { get; set; }

    public long? SendBackDmStatusId { get; set; }

    public int? CanAddEmailApprovalLink { get; set; }

    public int? IsDisabled { get; set; }
}
