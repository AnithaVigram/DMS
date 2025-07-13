using DMS.Data.EF.Context;
using DMS.Data.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.EF.Query;

public class GeneralQueries
{
    private readonly DmsContext _dmsContext;

    public GeneralQueries(DmsContext dmsContext)
    {
        _dmsContext = dmsContext ?? throw new ArgumentNullException(nameof(_dmsContext));
    }

    public async Task<List<DmManual_Treeview>> GetDmManualTreeviewAsync()
    {
        var result = await _dmsContext.DmManual_Treeview
           .FromSqlRaw("EXEC GetTreeViewManualList")
           .ToListAsync();

        return result ?? new List<DmManual_Treeview>();
    }

    public async Task<bool> CheckDmManualAsync(int manualID)
    {
        return await _dmsContext.DmManuals.AnyAsync(e => e.DmManualId == manualID);
    }
}
