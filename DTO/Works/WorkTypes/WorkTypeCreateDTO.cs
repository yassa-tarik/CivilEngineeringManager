using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Works.WorkTypes
{
    /// <summary>
    /// A data transfer object (DTO) used to create a new work type.
    /// Inherits common properties from WorkTypeBaseDTO.
    /// </summary>
    public class WorkTypeCreateDTO : WorkTypeBaseDTO
    {
        public WorkTypeCreateDTO(int? workCategoryID, int? parentID, string designation)
            : base(workCategoryID, parentID, designation)
        {
        }
    }
}
