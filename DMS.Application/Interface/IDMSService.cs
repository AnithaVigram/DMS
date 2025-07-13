using DMS.Data.EF.Models;
using DMS.Data.EF.Query;

namespace DMS.Application.Interface;

public interface IDMSService
{
    public Task<List<DmManual_Treeview>> GetTreeViewManualListAsync();

    public Task<List<DmManual>> GetDmManualsAsync();

    public Task<DmManual> GetDmManualDetailsAsync(int manualID);

    public Task AddDmManualAsync(DmManualDto manual);

    public Task UpdateDmManualAsync(DmManual manual);

    public Task DeleteDmManualAsync(int manualID);
}
