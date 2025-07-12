using Microsoft.EntityFrameworkCore;
using DMS.Application.Interface;
using DMS.Data.EF.Context;
using DMS.Data.EF.Models;

namespace DMS.Application;

public class DMSService : IDMSService
{
    private readonly DmsContext _dbContext;

    public DMSService(DmsContext context)
    {
        _dbContext = context;
    }

    public async Task<List<DmManual>> GetDmManualsAsync()
    {
        return await _dbContext.DmManuals
            .Select(p => new DmManual { DmManualId = p.DmManualId, ManualName = p.ManualName })
            .ToListAsync();
    }

    public async Task<DmManual> GetDmManualDetailsAsync(int manualID)
    {
        var manual = await _dbContext.DmManuals.FirstOrDefaultAsync(m => m.DmManualId == manualID);
        if (manual == null)
            throw new ArgumentNullException(nameof(manualID), "The manualID provided does not exist.");
        return manual;
    }

    public async Task AddDmManualAsync(DmManual manual)
    {
        if (manual == null) throw new ArgumentNullException(nameof(manual));
        await _dbContext.DmManuals.AddAsync(manual);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateDmManualAsync(DmManual manual)
    {
        if (manual == null) throw new ArgumentNullException(nameof(manual));
        _dbContext.Entry(manual).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteDmManualAsync(int manualID)
    {
        var manual = await _dbContext.DmManuals.FindAsync(manualID);
        if (manual == null)
            throw new ArgumentNullException(nameof(manualID), "The manualID provided does not exist.");
        _dbContext.DmManuals.Remove(manual);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> CheckDmManualAsync(int manualID)
    {
        return await _dbContext.DmManuals.AnyAsync(e => e.DmManualId == manualID);
    }
}