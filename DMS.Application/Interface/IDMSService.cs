using DMS.Data.EF.Models;

namespace DMS.Application.Interface;

public interface IDMSService
{
    public Task<List<DmManual>> GetDmManualsAsync();

    public Task<DmManual> GetDmManualDetailsAsync(int manualID);

    public Task AddDmManualAsync(DmManual manual);

    public Task UpdateDmManualAsync(DmManual manual);

    public Task DeleteDmManualAsync(int manualID);

    public Task<bool> CheckDmManualAsync(int manualID);
}
