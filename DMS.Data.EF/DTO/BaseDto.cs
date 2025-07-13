using System.Text.Json.Serialization;

namespace DMS.Data.EF.Query;

public class BaseDto
{
    public string Origin { get; set; } = null!;

    public int VesselId { get; set; }
    
    public DateTime CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime ModifiedBy { get; set; }

    public string? ModifiedDate { get; set; }

    public int IsDeleted { get; set; }
}
