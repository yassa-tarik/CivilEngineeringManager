using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Works.WorkCategories
{
    /// <summary>
    /// A data transfer object (DTO) used to update an existing work category.
    /// Inherits common properties from WorkCategoryBaseDto and adds an ID.
    /// </summary>
    internal class WorkCategoryUpdateDTO : WorkCategoryBaseDTO
    {
        public int ID { get; set; }

        public WorkCategoryUpdateDTO(int iD, int projectID, int workCategoryNameID, string workCategoryName) : base(projectID, workCategoryNameID, workCategoryName)
        {
            this.ID = iD;   
        }
    }
}
