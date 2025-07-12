using System;
using System.Collections.Generic;

namespace DMS.Data.EF.Models;

public partial class DmManualAttachment
{
    public long DmManualAttachmentsId { get; set; }

    public string Origin { get; set; } = null!;

    public int VesselId { get; set; }

    public long DmManualId { get; set; }

    public int? ImageRefNo { get; set; }

    public byte[]? BlobContents { get; set; }

    public int BlobSize { get; set; }

    public string FileType { get; set; } = null!;

    public DateTime? AddedOn { get; set; }
}
