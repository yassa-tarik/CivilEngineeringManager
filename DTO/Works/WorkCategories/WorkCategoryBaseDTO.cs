using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Works.WorkCategories
{
    /// <summary>
    /// A base data transfer object (DTO) that contains common properties
    /// for creating and updating a work category.
    /// </summary>
    public abstract class WorkCategoryBaseDTO
    {
        public int ProjectID { get; set; }
        public int WorkCategoryNameID { get; set; }
        public string WorkCategoryName { get; set; }

        protected WorkCategoryBaseDTO(int projectID, int workCategoryNameID, string workCategoryName)
        {
            ProjectID = projectID;
            WorkCategoryNameID = workCategoryNameID;
            WorkCategoryName = workCategoryName;
        }
    }
}
