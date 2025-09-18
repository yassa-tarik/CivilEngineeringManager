using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Works
{
    /// <summary>
    /// A base data transfer object (DTO) that contains common properties
    /// for creating and updating a work type.
    /// </summary>
    public abstract class WorkTypeBaseDTO
    {
        public int? WorkCategoryID { get; set; }
        public int? ParentID { get; set; }
        public string Designation { get; set; }

        public WorkTypeBaseDTO(int? workCategoryID, int? parentID, string designation)
        {
            WorkCategoryID = workCategoryID;
            ParentID = parentID;
            Designation = designation;
        }
    }
}
