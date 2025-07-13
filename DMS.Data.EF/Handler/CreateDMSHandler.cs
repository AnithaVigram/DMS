using AutoMapper;
using DMS.Data.EF.Context;
using DMS.Data.EF.Models;
using DMS.Data.EF.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.EF.Handler
{
    public class CreateDMSHandler : IRequestHandler<CreateCommand, long>
    {
        private readonly IMapper _mapper;
        DmsContext _dmsContext;

        public CreateDMSHandler(DmsContext dmsContext, IMapper mapper)
        {
            _dmsContext = dmsContext ?? throw new ArgumentNullException(nameof(dmsContext), "DmsContext cannot be null");
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper cannot be null");
        }

        public async Task<long> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            var dmManual = _mapper.Map<DmManual>(request.Manual);
         
            dmManual.Version = 1.0f; // Default version for new manuals
            dmManual.ManualNo = _dmsContext.DmManuals.Any() ? _dmsContext.DmManuals.Max(m => m.ManualNo) + 1 : 1; // Incremental manual number
            dmManual.DmManualStatusId = _dmsContext.DmManualStatuses.First(x => x.StatusName == "NEW")?.DmManualStatusId ?? 0;
            dmManual.ModifiedBy = null;
            dmManual.ModifiedDate = null;
            dmManual.IsDeleted = 0;
            var nextSortOrder = (_dmsContext.DmManuals
                                    .Where(x => x.ParentId == request.Manual.ParentId)
                                    .Select(m => (int?)m.SortOrder)
                                    .Max() ?? 0) + 1;
            dmManual.SortOrder = nextSortOrder; // Incremental sort order

            _dmsContext.DmManuals.Add(dmManual);
            await _dmsContext.SaveChangesAsync(cancellationToken);

            return dmManual.DmManualId;
        }
    }
}
