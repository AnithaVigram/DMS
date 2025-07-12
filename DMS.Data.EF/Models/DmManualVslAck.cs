﻿using System;
using System.Collections.Generic;

namespace DMS.Data.EF.Models;

public partial class DmManualVslAck
{
    public long DmManualVslAckId { get; set; }

    public string Origin { get; set; } = null!;

    public int VesselId { get; set; }

    public long DmManualId { get; set; }

    public int Version { get; set; }

    public string? UserRank { get; set; }

    public string? UserName { get; set; }

    public string? UserId { get; set; }

    public DateTime? AckDate { get; set; }

    public string? Comments { get; set; }

    public int? IsActive { get; set; }
}
