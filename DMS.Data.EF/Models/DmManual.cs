using System;
using System.Collections.Generic;

namespace DMS.Data.EF.Models;

public partial class DmManual
{
    public long DmManualId { get; set; }

    public string Origin { get; set; } = null!;

    public int VesselId { get; set; }

    public long DmManualCategoryId { get; set; }

    public int ManualNo { get; set; }

    public string? ManualCode { get; set; }

    public string ManualName { get; set; } = null!;

    public int Version { get; set; }

    public byte[] TextContents { get; set; } = null!;

    public long DmManualStatusId { get; set; }

    public long ParentId { get; set; }

    public int ManualLevel { get; set; }

    public int? CanExport { get; set; }

    public int? SortOrder { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? FinalisedBy { get; set; }

    public DateTime? FinalisedDate { get; set; }

    public string? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Comments { get; set; }

    public int? IsDeleted { get; set; }
}
