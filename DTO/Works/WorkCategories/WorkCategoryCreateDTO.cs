using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Works.WorkCategories
{
    /// <summary>
    /// A data transfer object (DTO) used to create a new work category.
    /// Inherits common properties from WorkCategoryBaseDto.
    /// </summary>
    public class WorkCategoryCreateDTO : WorkCategoryBaseDTO
    {
        public WorkCategoryCreateDTO(int projectID, int workCategoryNameID, string workCategoryName) : base(projectID, workCategoryNameID, workCategoryName)
        {
        }
    }
}
