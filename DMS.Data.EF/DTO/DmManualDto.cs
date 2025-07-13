using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.EF.Query;

public class DmManualDto : BaseDto
{
    public long DmManualCategoryId { get; set; }

    public string? ManualCode { get; set; }

    public string ManualName { get; set; } = null!;

    public string TextContents { get; set; } = null!;

    public long ParentId { get; set; }

    public int ManualLevel { get; set; }

    public int? CanExport { get; set; }

    public string Comments { get; set; } = null!;
}
