using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.EF.Models;

[Keyless]
public class DmManual_Treeview
{
    public long Dm_ManualId { get; set; }

    public string Origin { get; set; } = null!;

    public int VesselId { get; set; }

    public string DmManualCategory { get; set; } = null!;

    public int ManualNo { get; set; }

    public string? ManualCode { get; set; }

    public string ManualName { get; set; } = null!;

    public string? TextContents { get; set; } = null!;

    public string StatusString { get; set; } = null!;

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
