using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.EF.Query
{
    public class CreateCommand : IRequest<long>
    {
        public DmManualDto Manual { get; set; }

        public CreateCommand(DmManualDto manualDto)
        {
            Manual = manualDto;
        }
    }
}
