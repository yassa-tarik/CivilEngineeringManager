using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Works.WorkCategoryNames
{
    /// <summary>
    /// A data transfer object (DTO) used to create a new work category name.
    /// Inherits common properties from WorkCategoryNameBaseDto.
    /// </summary>
    internal class WorkCategoryNameCreateDTO : WorkCategoryNameBaseDTO
    {
        public WorkCategoryNameCreateDTO(string name) : base(name)
        {
        }
    }
}
