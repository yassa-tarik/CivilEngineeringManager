using Domain.Entities;
using DTO.Works.WorkSpecs;
using DTO.Works.WorkTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Mappers
{
    internal static class WorkSpecMapper
    {
        public static WorkSpecDTO DomainToDto(WorkSpec workSpec)
        {
            if (workSpec == null) throw new ArgumentNullException(nameof(workSpec) + "not found!");

            return new WorkSpecDTO
            (
                 workSpec.ID,
                 workSpec.WorkCategory_ID,
                 workSpec.WorkType_ID,
                 workSpec.Designation,
                 workSpec.Unit,
                 workSpec.UnitPrice,
                 workSpec.Quantity,
                 workSpec.VAT
            );
        }
    }
}
