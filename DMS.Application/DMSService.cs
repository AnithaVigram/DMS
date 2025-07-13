using Microsoft.EntityFrameworkCore;
using DMS.Application.Interface;
using DMS.Data.EF.Context;
using DMS.Data.EF.Models;
using DMS.Data.EF.Query;
using MediatR;

namespace DMS.Application;

public class DMSService : IDMSService
{
    private readonly DmsContext _dbContext;
    private readonly IMediator _mediator;
    private readonly GeneralQueries _queries;

    public DMSService(DmsContext context, IMediator mediator, GeneralQueries queries)
    {
        _dbContext = context;
        _mediator = mediator;
        _queries = queries;
    }

    public async Task<List<DmManual_Treeview>> GetTreeViewManualListAsync()
    {
        return await _queries.GetDmManualTreeviewAsync();
    }

    public async Task<List<DmManual>> GetDmManualsAsync()
    {
        return await _dbContext.DmManuals
            .ToListAsync();
    }

    public async Task<DmManual> GetDmManualDetailsAsync(int manualID)
    {
        var manual = await _dbContext.DmManuals.FirstOrDefaultAsync(m => m.DmManualId == manualID);
        if (manual == null)
            throw new ArgumentNullException(nameof(manualID), "The manualID provided does not exist.");
        return manual;
    }

    public async Task AddDmManualAsync(DmManualDto manual)
    {
        if (manual == null) throw new ArgumentNullException(nameof(manual));

      await  _mediator.Send(new CreateCommand(manual));
    }

    public async Task UpdateDmManualAsync(DmManual manual)
    {
        if (manual == null) throw new ArgumentNullException(nameof(manual));

        _dbContext.Update(manual);
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

}