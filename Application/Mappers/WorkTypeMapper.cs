using Domain.Entities;
using DTO.Works.WorkCategories;
using DTO.Works.WorkTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Mappers
{
    internal class WorkTypeMapper
    {
        public static WorkTypeDTO DomainToDto(WorkType workType)
        {
            if (workType == null) throw new ArgumentNullException(nameof(workType) + "not found!");

            return new WorkTypeDTO
            (
                 workType.ID,
                 workType.WorkCategory_ID,
                 workType.Parent_ID,
                 workType.Designation
            );
        }
    }
}
